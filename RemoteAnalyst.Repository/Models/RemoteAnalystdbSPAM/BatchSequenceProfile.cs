using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteAnalyst.Repository.Models
{
    public class BatchSequenceProfile
    {
        public virtual int BatchSequenceProfileId { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime StartWindowStart { get; set; }
        public virtual DateTime StartWindowEnd { get; set; }
        public virtual string StartWindowDoW { get; set; }
        public virtual DateTime ExpectedFinishBy { get; set; }
        public virtual bool AlertIfDoesNotStartOnTime { get; set; }
        public virtual bool AlertIfOrderNotFollowed { get; set; }
        public virtual bool AlertIfDoesNotFinishOnTime { get; set; }
        public virtual string EmailList { get; set; }
        public virtual string ProgramFiles { get; set; }
        public virtual ICollection<BatchSequenceAlertRecipient> AlertRecipients { get; set; }
        public virtual ICollection<BatchSequenceAlertProgram> AlertPrograms { get; set; }
    }

    public class BatchSequenceProfileMap : ClassMap<BatchSequenceProfile>
    {
        public BatchSequenceProfileMap()
        {
            Table("BatchSequenceProfile");
            Id(x => x.BatchSequenceProfileId).GeneratedBy.Identity();
            Map(x => x.Name).Unique().Not.Nullable();
            Map(x => x.StartWindowStart).Not.Nullable();
            Map(x => x.StartWindowEnd).Not.Nullable();
            Map(x => x.StartWindowDoW).Not.Nullable();
            Map(x => x.ExpectedFinishBy).Not.Nullable();
            Map(x => x.AlertIfDoesNotStartOnTime).Not.Nullable();
            Map(x => x.AlertIfOrderNotFollowed).Not.Nullable();
            Map(x => x.AlertIfDoesNotFinishOnTime).Not.Nullable();
            Map(x => x.EmailList).Nullable();
            Map(x => x.ProgramFiles).Nullable();
            HasMany(x => x.AlertRecipients)
                .KeyColumn("BatchSequenceProfileId")
                .Cascade.All()
                .Inverse();
            HasMany(x => x.AlertPrograms)
                .KeyColumn("BatchSequenceProfileId")
                .Cascade.All()
                .Inverse();
        }
    }
}
