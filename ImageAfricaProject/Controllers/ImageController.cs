using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using ImageAfricaProject.Dto;
using ImageAfricaProject.Dto.color;
using ImageAfricaProject.Dto.contentCollection;
using ImageAfricaProject.Dto.fileInfo;
using ImageAfricaProject.Dto.image;
using ImageAfricaProject.Dto.ImageTag;
using ImageAfricaProject.Dto.like;
using ImageAfricaProject.Entities;
using ImageAfricaProject.Helpers;
using ImageAfricaProject.Repository;
using ImageAfricaProject.Services;
using ImageAfricaProject.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FileInfo = ImageAfricaProject.Entities.FileInfo;

namespace ImageAfricaProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ValidateModel]
    [Authorize]
    public class ImageController : ControllerBase
    {
        private IImageRepository _imageRepository;
        private ITagRepository _tagRepository;
        private IImageTagRepository _imagetagRepository;
        private IContentCollectionRepository _contentCollectionRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private IFileInfoRepository _fileInfoRepository;
        private IImageColorRepository _imageColorRepository;
        private IColorRepository _colorRepository;
        
        public ImageController(IImageRepository imageRepository, IMapper mapper, ITagRepository tagRepository, IImageTagRepository imagetagRepository, IUserRepository userRepository, IContentCollectionRepository contentCollectionRepository, IFileInfoRepository fileInfoRepository, 
            IImageColorRepository imageColorRepository, 
            IColorRepository colorRepository)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
            _tagRepository = tagRepository;
            _imagetagRepository = imagetagRepository;
            _userRepository = userRepository;
            _contentCollectionRepository = contentCollectionRepository;
            _fileInfoRepository = fileInfoRepository;
            _imageColorRepository = imageColorRepository;
            _colorRepository = colorRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var images = await _imageRepository.GetAll().Include(a=>a.Category)
                .Include(a=>a.User)
                .Include(a=>a.ImageTag).
                    ThenInclude(tg=>tg.Tag)
                .ToListAsync();
            var mapped = _mapper.Map<List<GetImageDto>>(images);
            return Ok(mapped);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id)
        {
            var images = _imageRepository.Query().Where(a=>a.Id == id)
                                            .Include(a=>a.Category)
                                            .Include(a=>a.User)
                                            .Include(a=>a.ImageTag).
                                            ThenInclude(tg=>tg.Tag)
                                            .FirstOrDefault();
            if (images == null)
            {
               return NotFound("No images Found");
            }
            var mapped = _mapper.Map<GetImageDto>(images);
          await  _imageRepository.AddImageViews(new ImageView()
            {
                ImageId = mapped.Id
            });

          await _imageRepository.Save();
          var colors = _imageColorRepository.Query()
                                .Where(a => a.ImageId == mapped.Id)
                                .Select(a => a.Color)
                                .ToList();
          var fileInfo = await _fileInfoRepository.Query().FirstOrDefaultAsync(a => a.ImageId == mapped.Id);

          mapped.Colors = _mapper.Map<List<ColorDto>>(colors);
          mapped.FileInfo = _mapper.Map<GetFileInfoDto>(fileInfo);
          return Ok(mapped);
        }
       
        [HttpPost]
        [AllowAnonymous]
      
        public async Task<IActionResult> UploadFiles()
        {
            var file = Request.Form.Files[0];
            //if (files.Count <= 0) return BadRequest("No Files Found");
            
                //foreach (var file in files)
                //{
                    //string mimeType = file.ContentType;
                    //byte[] fileData = new byte[file.Length];
                    BlobStorageService objBlobService = new BlobStorageService();
                    var url = await  objBlobService.UploadFileStreamToBlobAsync(file.FileName, file);
                    //fileUrls.Add(url);
                //}
                var obj = new
                {
                    url = url,
                    uploadURL = url
                };
                return Ok(obj);
        }
        [HttpGet]
        [AllowAnonymous]

        public async Task<IActionResult> GetTags()
        {
            var tags = await _tagRepository.GetAll().ToListAsync();
            var mapped = _mapper.Map<List<TagDto>>(tags);
            return Ok(mapped);
        }

        [HttpPost]
        
        public async Task<IActionResult> Create([FromBody] List<CreateImageDto> createImageDto)
        {
            foreach (var i in createImageDto)
            {
                var mapped = _mapper.Map<Images>(i);
                await _imageRepository.Create(mapped);
                await _imageRepository.Save();
                var tag = createImageDto.FirstOrDefault(a => a.ImageUrl.ToLower() == i.ImageUrl.ToLower());
                if (tag != null)
                {
                    foreach (var t in tag.Tag)
                    {
                        var findTag = await _tagRepository.Query().FirstOrDefaultAsync(a => a.Name.ToLower() == t.ToString().ToLower());
                       
                        if (findTag == null)
                        {
                            var newTag = new Tag
                            {
                                Name = t
                            };
                            await _tagRepository.Create(newTag);
                            await _tagRepository.Save();
                          await  _imagetagRepository.Create(new ImageTag()
                            {
                                TagId = newTag.Id,
                                ImageId = mapped.Id
                            });
                          await _imagetagRepository.Save();
                        }
                        else
                        {
                            await  _imagetagRepository.Create(new ImageTag()
                            {
                                TagId = findTag.Id,
                                ImageId = mapped.Id
                            });
                            await _imagetagRepository.Save();

                        }
                    }
                }
                //find tag by name  
                //create file info 
                var fileInfo = _mapper.Map<FileInfo>(i.FileInfo);
                if (fileInfo != null)
                {
                    fileInfo.ImageId = mapped.Id;

                    await _fileInfoRepository.Create(fileInfo);
                    await _fileInfoRepository.Save();
                }
               

                //create color 
                //find if color does not exist 
                foreach (var color in i.Colors)
                {
                    var mappedColor = _mapper.Map<Color>(color);
                    var findcolor = await _colorRepository.Query().FirstOrDefaultAsync(a => a.Code == mappedColor.Code);
                    var imageColor = new ImageColor()
                    {
                        ImageId = mapped.Id,
                        Level = color.Level
                    };
                    if (findcolor == null)
                    {
                        //create that color 
                       await _colorRepository.Create(mappedColor);
                       await _colorRepository.Save();
                       imageColor.ColorId = mappedColor.Id;
                    }
                    else
                    {
                        imageColor.ColorId = findcolor.Id;
                    }
                    //add color to ImageColorTable 
                   await _imageColorRepository.Create(imageColor);
                   await _imageColorRepository.Save();

                }

            }
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var image = await _imageRepository.GetById(id);
            if(image == null)
            {
                return NotFound(new ResponseDto
                {
                    Status = ResponseStatus.Fail,
                    Message = "No Record found"
                });
            }

            await _imageRepository.SoftDelete(image);
            await _imageRepository.Save();
            return NotFound(new ResponseDto
            {
                Status = ResponseStatus.Success
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateCollection([FromBody] ContentCollectionDto collectionDto)
        {

            var mapped = _mapper.Map<ContentCollection>(collectionDto);
            var hasAny = await _contentCollectionRepository.Query()
                .AnyAsync(a => a.ImageId == collectionDto.ImageId && a.UserId == collectionDto.UserId);
                
            if(hasAny) 
            {
                return  BadRequest("Content already added to collection");
            }
            await _contentCollectionRepository.Create(mapped);
            await _contentCollectionRepository.Save();
            return Ok(mapped);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollection(int id)
        {
            var collection = await _contentCollectionRepository.Get(a=>a.ImageId == id);
            if(collection == null)
            {
                return NotFound(new ResponseDto
                {
                    Status = ResponseStatus.Fail,
                    Message = "No Record found"
                });
            }

           await _contentCollectionRepository.Delete(collection);
           await _contentCollectionRepository.Save();
           return NotFound(new ResponseDto
           {
               Status = ResponseStatus.Success
           });
        }

        [HttpPost]
        public async Task<IActionResult> Like([FromBody] ImageLike like)
        {
            var hasAny = await _imageRepository.QueryLikes()
                .AnyAsync(a=>a.ImageId == like.ImageId
                             && a.UserId == like.UserId);
          
            if(hasAny) 
            {
                return  Ok(new ResponseDto()
                {
                    Message = "content liked already",
                    Status = ResponseStatus.Success
                });
            }

            await _imageRepository.AddImageLike(like);
            await _imageRepository.Save();
            return Ok(
                new ResponseDto()
                {
                    Status = ResponseStatus.Success,
                    Data =   like
                });
        } 

        [HttpPost]
        public async Task<IActionResult> LikeToggle([FromBody] CreateLikeDto like)
        {
            var hasAny = await _imageRepository.QueryLikes()
                .FirstOrDefaultAsync(a=>a.ImageId == like.ImageId
                             && a.UserId == like.UserId);
          
            if(hasAny != null)
            {
                await _imageRepository.RemoveImageLike(hasAny);
                await _imageRepository.Save();
                return  Ok(new ResponseDto()
                {
                    Message = "unliked",
                    Status = ResponseStatus.Success,
                    Data = new
                    {
                        liked = false
                    }
                });
             
            }

            await _imageRepository.AddImageLike(new ImageLike()
            {
                UserId =  like.UserId,
                ImageId = like.ImageId
            });
            await _imageRepository.Save();
            return Ok(new ResponseDto()
            {
                Message = "liked",
                Status = ResponseStatus.Success,
                Data = new
                {
                    liked = true
                }
            });
        } 

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllImageGeoJSON()
        {
            var images = await _imageRepository.GetAll().Where(a=>a.GeoLog != 0 && a.GeoLat != 0).Select(a => new
            {
                type= "Feature",
                geometry = new {
                  type = "Point",
                  coordinates= new double[] { a.GeoLog, a.GeoLat,}
                 },
                properties = new {
                            title = a.Name,
                            url= a.ImageUrl,
                            id = a.Id
               }
                }).ToListAsync();
            var obj = new
            {
                type = "FeatureCollection",
                features = images
            };
            return Ok(obj);
        }

        
        [AllowAnonymous]
        [HttpGet ("{id}")]
        public async Task<IActionResult> CountViews(int id)
        {
            var count = await _imageRepository.QueryViews().CountAsync(a => a.ImageId == id);
            return Ok(count);
        }

        [AllowAnonymous]
        [HttpGet ("{id}")]
        public async Task<IActionResult> CountLikes(int id)
        {
            var count = await _imageRepository.QueryLikes().CountAsync(a => a.ImageId == id);
            return Ok(count);
        }

        
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> CountContributorsViews(string id)
        {
            var count = await _imageRepository.QueryViews().CountAsync(a => a.Image.UserId == id);
            return Ok(count);
        }

        [HttpGet]
        public async Task<IActionResult> GetCollections()
        {
            var user = await _userRepository.GetCurrentUserAsync();
            if (user == null) return Unauthorized("user not authorized to access this"); 
            var userId = user.Id;

            var collection = await _contentCollectionRepository.GetAll()
                .Where(a=>a.UserId == userId)
                .Include(a => a.Image)
                .Include(a => a.Image.Category)
                .Include(a=>a.Image.User)
                .Select(a=>a.Image).ToListAsync();

            var mapped = _mapper.Map<List<GetImageDto>>(collection);
            return Ok(mapped);
        }

        [HttpGet]
        public async Task<IActionResult> GetMyUploads()
        {
           
            var user = await _userRepository.GetCurrentUserAsync();
            if (user == null) return Unauthorized("user not authorized to access this");

            var userId = user.Id;
            var images = await _imageRepository.GetAll()
                .Where(a=>a.UserId == userId)
                .Include(a=>a.Category)
                .Include(a=>a.User)
                .Include(a=>a.ImageTag).
                 ThenInclude(tg=>tg.Tag)
                .ToListAsync();
            var mapped = _mapper.Map<List<GetImageDto>>(images);
            return Ok(mapped);
        }

    }
}