using System.Collections.Generic;
using Abp.Auditing;

namespace PepperMintDemo.Auditing
{
    public interface IExpiredAndDeletedAuditLogBackupService
    {
        bool CanBackup();
        
        void Backup(List<AuditLog> auditLogs);
    }
}