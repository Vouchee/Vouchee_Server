using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Comment;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;
using Vouchee.Business.Services.Interfaces;
using Vouchee.Data.Models.Entities;
using AutoMapper;
using Vouchee.Data.Repositories.Interfaces;
using Vouchee.Data.Models.Constants;
using AutoMapper.QueryableExtensions;
using Vouchee.Business.Helpers;

namespace Vouchee.Business.Services.Impls
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepo _commentRepo;
        private readonly IMapper _mapper;

        public CommentService(IMapper mapper, ICommentRepo commentRepo)
        {
            _commentRepo = commentRepo;
            _mapper = mapper;
        }


        public async Task<ResponseResult<CommentResponse>> CreateComment(CreateCommentRequest request)
        {
            try
            {
                var entity = _mapper.Map<Comment>(request);
                await _commentRepo.AddAsync(_mapper.Map<Comment>(request));
                await _commentRepo.SaveAsync();
            }
            catch (Exception ex)
            {
                return new ResponseResult<CommentResponse>()
                {
                    Message = StringConstant.CREATE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_commentRepo) ;
            }
            return new ResponseResult<CommentResponse>()
            {
                Message = StringConstant.CREATE_INFO_SUCCESS,
                Result = true
            };
        }

        public async Task<ResponseResult<CommentResponse>> DeleteComment(Guid id)
        {
            try
            {
                var existedComment = _commentRepo.GetByIdAsync(id).Result;

                if (existedComment == null)
                {
                    return new ResponseResult<CommentResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                        Result = false
                    };
                }

                _commentRepo.Delete(existedComment);
                await _commentRepo.SaveAsync();

            }
            catch (Exception ex)
            {
                return new ResponseResult<CommentResponse>()
                {
                    Message = StringConstant.DELETE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_commentRepo) ;
            }

            return new ResponseResult<CommentResponse>()
            {
                Message = StringConstant.DELETE_INFO_SUCCESS,
                Result = true
            };
        }

        public async Task<ResponseResult<CommentResponse>> GetComment(Guid id)
        {
            CommentResponse result;

            try
            {
                result = _mapper.Map<CommentResponse>(_commentRepo.GetByIdAsync(id).Result);

                if (result == null)
                {
                    return new ResponseResult<CommentResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseResult<CommentResponse>()
                {
                    Message = StringConstant.LOAD_INFO_FAILED,
                };
            }
            finally
            {
                lock (_commentRepo) ;
            }

            return new ResponseResult<CommentResponse>()
            {
                Value = result,
            };
        }

        public async Task<DynamicModelResponse.DynamicModelsResponse<CommentResponse>> GetComments(CommentFilter request, PagingRequest paging)
        {
            (int, IQueryable<CommentResponse>) result;
            try
            {
                result = _commentRepo.GetAllAsync().Result
                    .ProjectTo<CommentResponse>(_mapper.ConfigurationProvider)
                    .DynamicFilter(_mapper.Map<CommentResponse>(request))
                    .PagingIQueryable(paging.Page, paging.PageSize, StringConstant.LimitPaging, StringConstant.DefaultPaging);

                if (result.Item2.ToList().Count() == 0)
                {
                    return new DynamicModelResponse.DynamicModelsResponse<CommentResponse>()
                    {
                        Message = StringConstant.EMPTY_INFO,
                    };
                }
            }
            catch (Exception ex)
            {
                return new DynamicModelResponse.DynamicModelsResponse<CommentResponse>()
                {
                    Message = StringConstant.LOAD_INFO_FAILED,
                };
            }
            finally
            {
                lock (_commentRepo) ;
            }
            return new DynamicModelResponse.DynamicModelsResponse<CommentResponse>()
            {
                Metadata = new DynamicModelResponse.PagingMetadata()
                {
                    Page = paging.Page,
                    Size = paging.PageSize
                },
                Results = result.Item2.ToList()
            };
        }

        public async Task<ResponseResult<CommentResponse>> UpdateComment(UpdateCommentRequest request, Guid id)
        {
            try
            {
                var existedComment = _commentRepo.GetByIdAsync(id).Result;

                if (existedComment == null)
                {
                    return new ResponseResult<CommentResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                        Result = false
                    };
                }

                var newComment = _mapper.Map<Comment>(request);

                _commentRepo.Update(newComment);
                await _commentRepo.SaveAsync();
            }
            catch (Exception ex)
            {
                return new ResponseResult<CommentResponse>()
                {
                    Message = StringConstant.UPDATE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_commentRepo) ;
            }

            return new ResponseResult<CommentResponse>()
            {
                Message = StringConstant.UPDATE_INFO_SUCCESS,
                Result = true
            };
        }
    }
}
