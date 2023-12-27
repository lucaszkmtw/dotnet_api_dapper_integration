using System;
using System.Data;

namespace DataAccess.Infrastructure.Transactions
{
    public class Transaction 
    {
        private IDbTransaction _trx;

        protected IDbTransaction Trx
        {
            set { this._trx = value; }

            get { return this._trx; }
        }

        public bool IsActive
        {
            get
            {
                if (this.Trx != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void Commit()
        {
            if (this.Trx != null && this.IsActive )
            {
                this.Trx.Commit();
            }
        }

        public void Rollback()
        {
            if (this.Trx != null && this.IsActive)
            {
                this.Trx.Rollback();
            }
        }

        //public void BeginTransaction()
        //{
        //    this.Trx.Begin();
        //}

        //public void BeginTransaction(IsolationLevel isoLevel)
        //{
        //    this.Trx.Begin(isoLevel);
        //}

        public void BeginTransaction(IDbConnection session)
        {
            this.Trx = session.BeginTransaction();
        }

        public void BeginTransaction(IDbConnection session, IsolationLevel isoLevel)
        {
            this.Trx = session.BeginTransaction(isoLevel);
        }

        //public void Dispose()
        //{
        //    GC.Collect();
        //}
    }
}
