using Application.Common.Mappings;
using Domain.Entities;
using Domain.Enums;
using System;

namespace Application.PandaDocs
{
    public class PandaDocDocumentDto //: IMapFrom<PandaDocDocument>
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Status { get; set; }

        public PandaDocProcess Process { get; set; } = PandaDocProcess.Init;

        public string StudentShareLink { get; set; }

        public DateTime StudentShareLinkExpiresAt { get; set; }

        public string ADOAShareLink { get; set; }

        public DateTime ADOAShareLinkExpiresAt { get; set; }

        public DateTime ExpiresAt { get; set; }

        public long? FileId { get; set; }
        public File File { get; set; }
    }
}
