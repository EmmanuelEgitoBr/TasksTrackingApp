﻿using AutoMapper;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Domain.Entities;

namespace TasksTrackingApp.Application.Mappings
{
    public class WorkspaceMappings : Profile
    {
        public WorkspaceMappings() 
        {
            CreateMap<Workspace, WorkspaceDto>()
                .ForMember(x => x.UserId, x => x.MapFrom(x => x.User!.Id));
        }
    }
}