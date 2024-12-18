﻿using MediatR;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.Response;

namespace TasksTrackingApp.Application.WorkspaceCQ.Commands
{
    public record CreateWorkspaceCommand : IRequest<ResponseBase<WorkspaceDto>>
    {
        public string? Title { get; set; }
        public Guid? UserId { get; set; }
    }
}
