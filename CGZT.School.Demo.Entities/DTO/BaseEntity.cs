using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.Entities.DTO
{

    /// <summary>
    /// BaseEntity
    /// </summary>
    public class BaseEntity
    {

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>

        public DateTime CreatedAt
        {
            get
            {
                return this.createdAt.HasValue
                   ? this.createdAt.Value
                   : DateTime.Now;
            }

            set { this.createdAt = value; }
        }

        private DateTime? createdAt = null;

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>
        /// The updated date.
        /// </value>
        public DateTime? UpdatedAt { get; set; }

    }

}
