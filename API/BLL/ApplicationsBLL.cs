﻿
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories;

namespace API.BLL
{
    public class ApplicationsBLL : BaseBLL
    {
        public ApplicationsBLL(UnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
        public async Task<IEnumerable<ApplicationModel>> GetAllAsync()
        {
            var applications = await _unitOfWork.ApplicationRepository.GetAllAsync(includeProperties: $"{nameof(ApplicationType)}");
            return _mapper.Map<IEnumerable<ApplicationModel>>(applications);
        }
        public async Task<ApplicationModel> GetAsync(int id)
        {
            var application = await _unitOfWork.ApplicationRepository
                .GetAsync(x => x.ID == id, includeProperties: $"{nameof(ApplicationType)}");
            return _mapper.Map<ApplicationModel>(application);
        }
        public async Task<ApplicationModel> GetByNameAsync(string name)
        {
            var application = await _unitOfWork.ApplicationRepository
                .GetAsync(x => x.Name.ToLower() == name.ToLower(), includeProperties: $"{nameof(ApplicationType)}");
            return _mapper.Map<ApplicationModel>(application);
        }
        public async Task<ApplicationModel> UpdateAsync(ApplicationModel model)
        {
            var application = await _unitOfWork.ApplicationRepository
                .GetAsync(x => x.ID == model.ID);
            if (application == null)
            {
                return null;
            }
            _mapper.Map(model, application);
            _unitOfWork.ApplicationRepository.Update(application);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<ApplicationModel>(application);
        }
        public async Task<ApplicationModel> AddAsync(ApplicationModel model)
        {
            var application = _mapper.Map<Application>(model);
            _unitOfWork.ApplicationRepository.Add(application);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<ApplicationModel>(application);
        }
        public async Task DeleteAsync(int id)
        {
            _unitOfWork.ApplicationRepository.Delete(id);
            await _unitOfWork.SaveAsync();
        }
    }
}
