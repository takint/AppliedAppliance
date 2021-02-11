using Application.Common.Models;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DropDownData
{
    /// <summary>
    /// This class should be removed for now as the enum for DocumentGroupList is defined in client side app.constant
    /// </summary>
    public class GetDocumentGroupListDropDownQuery : IRequest<IList<DropDownModel>>
    {
        public GetDocumentGroupListDropDownQuery() { }
    }

    public class GetDocumentGroupListDropDownQueryHandler : IRequestHandler<GetDocumentGroupListDropDownQuery, IList<DropDownModel>>
    {
        public async Task<IList<DropDownModel>> Handle(GetDocumentGroupListDropDownQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                return DocumentGroupList.EnumToDictionary<DocumentGroup>().Select(c => new DropDownModel
                {
                    Value = c.Key,
                    Label = c.Value,
                }).ToList();
            });
        }
    }

    public static class DocumentGroupList
    {
        public static Dictionary<int, string> EnumToDictionary<T>() where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T is not an Enum type");

            return Enum.GetValues(typeof(T))
              .Cast<object>()
              .ToDictionary(k => (int)k, v => v.ToString());
        }
    }
}
