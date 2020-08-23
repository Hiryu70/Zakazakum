using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Users.Queries.GetUsers
{
	public class GetUsersQueryHandler : IRequestHandler<GetUsersListQuery, UsersListVm>
	{
		private readonly IZakazakumContext _context;
		private readonly IMapper _mapper;

		public GetUsersQueryHandler(IZakazakumContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<UsersListVm> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
		{
			List<UserVm> users = await _context.Users
				.ProjectTo<UserVm>(_mapper.ConfigurationProvider)
				.ToListAsync(cancellationToken);

			var vm = new UsersListVm
			{
				Users = users
			};

			return vm;
		}
	}
} 