﻿using AutoMapper;
using MediatR;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.Response;
using TasksTrackingApp.Application.WorkspaceCQ.Commands;
using TasksTrackingApp.Infrastructure.Repository.UnitOfWork;

namespace TasksTrackingApp.Application.WorkspaceCQ.Handlers
{
    public class GetWorkspaceCommandHandler : IRequestHandler<GetWorkspaceCommand, ResponseBase<WorkspaceDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetWorkspaceCommandHandler(IUnitOfWork unitOfWork,
                                          IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseBase<WorkspaceDto>> Handle(GetWorkspaceCommand request, CancellationToken cancellationToken)
        {
            var workspace = await _unitOfWork.WorkspaceRepository.GetAsync(x => x.Id == request.Id);

            if (workspace == null)
            {
                return new ResponseBase<WorkspaceDto>
                {
                    Title = "Workspace não encontrado",
                    HttpStatus = 404,
                    Value = null
                };
            }

            var workspaceDto = _mapper.Map<WorkspaceDto>(workspace);

            return new ResponseBase<WorkspaceDto>
            {
                Title = "Workspace encontrado com sucesso",
                HttpStatus = 201,
                Value = workspaceDto
            };
        }
    }
}