﻿using Core.Persistence.Repositories;
using MessagePersistenceService.Domain.Entities;

namespace MessagePersistenceService.Application.Services.Repositories;

public interface IOnlineInChatRepository : IReadRepository<OnlineInChat>, IWriteRepository<OnlineInChat>
{
}