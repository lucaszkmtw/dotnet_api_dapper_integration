using System;
using System.Collections.Generic;

namespace DataAccess.Helpers
{
    /// <summary>
    /// Clase que permite armar una consulta con filtros desde el cliente.
    /// </summary>
    public class Search
    {
        /// <summary>
        /// Clase que permite armar una consulta con filtros desde el cliente.
        /// </summary>
        /// <summary>
        /// Type del DTO de la entidad para la cual se va a realizar la busqueda
        /// </summary>
        public System.Type DtoType { get; set; }

        /// <summary>
        /// Orden (opcional)
        /// </summary>
        //public Order Order { get; set; }

        /// <summary>
        /// Orden (opcional)
        /// </summary>
        public int? MaxResult { get; set; }

        /// <summary>
        /// Alias (opcional)
        /// </summary>
        public Dictionary<string, object> Alias { get; set; }

        /// <summary>
        /// AliasLeftJoin (opcional)
        /// </summary>
        public Dictionary<string, string> AliasLeftJoin { get; set; }

        /// <summary>
        /// Lista de expressions para armar un criteria
        /// </summary>
 

        /// <summary>
        /// Setear en true para evitar valores repetidos en el target de la busqueda (opcional)
        /// </summary>
        public Boolean DistinctRootEntity { get; set; }

        /// <summary>
        /// Tipo de Join (opcional)
        /// </summary>
        public String JoinType { get; set; }

        public Search(System.Type DtoType)
        {
            this.DtoType = DtoType;
         
            this.Alias = new Dictionary<string, object>();
            this.AliasLeftJoin = new Dictionary<string, string>();
            this.DistinctRootEntity = false;
        }

        //public void AddOrder(Order order)
        //{
        //    this.Order = order;
        //}

        /// <summary>
        /// Agrega un Alias
        /// </summary>
        public void AddAlias(KeyValuePair<string, object> pair)
        {
            this.Alias.Add(pair.Key, pair.Value);
        }

        /// <summary>
        /// Agrega un Alias con type = LeftJoin
        /// </summary>
        public void AddAliasLeftJoin(KeyValuePair<string, string> pair)
        {
            this.AliasLeftJoin.Add(pair.Key, pair.Value);
        }

        /// <summary>
        /// Agrega una expression a la lista
        /// </summary>
        //public void AddExpression(ICriterion expression)
        //{
        //    this.Expressions.Add(expression);
        //}

    }
}
