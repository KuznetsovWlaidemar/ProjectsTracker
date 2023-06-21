﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsTracker.Domain
{
    /// <summary>
    /// Роли сотрудников
    /// </summary>
    public class Role
    {
        #region Fields
        /// <summary>
        /// Идентификатор роли
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование роли
        /// </summary>
        public string Name { get; set; }
        #endregion

        #region Relationshipss
        /// <summary>
        /// Сотрудники с ролью
        /// </summary>
        public ICollection<Employee> Employees { get; set; }
        #endregion

    }
}
