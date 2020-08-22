using AutoMapper;

namespace Zakazakum.Application.Common.Mapping
{
	public interface IMapFrom<T>
	{
		void Mapping(Profile profile);
	}
}
