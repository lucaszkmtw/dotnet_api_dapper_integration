using System;
using System.Data;

namespace ECO.RCF.DataAccess.Infrastructure.Transactions
{
    public class Transaction
    {
        private IDbTransaction _trx;

        protected IDbTransaction Trx
        {
            set { this._trx = value; }

            get { return this._trx; }
        }



        public void Commit()
        {
            if (this.Trx != null && this.IsActive && !this.Trx.WasCommitted && !this.Trx.WasRolledBack)
            {
                this.Trx.Commit();
            }
        }

        public void Rollback()
        {
            if (this.Trx != null && this.IsActive && !this.Trx.WasCommitted && !this.Trx.WasRolledBack)
            {
                this.Trx.Rollback();
            }
        }

        public void BeginTransaction()
        {
            this.Trx..BeginTransaction();
        }

        public void BeginTransaction(IsolationLevel isoLevel)
        {
            this.Trx.Begin(isoLevel);
        }

        public void BeginTransaction(ISession session)
        {
            this.Trx = session.BeginTransaction();
        }

        public void BeginTransaction(ISession session, IsolationLevel isoLevel)
        {
            this.Trx = session.BeginTransaction(isoLevel);
        }

        public void Dispose()
        {
            GC.Collect();
        }
    }
}
