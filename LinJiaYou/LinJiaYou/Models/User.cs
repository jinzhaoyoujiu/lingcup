namespace LinJiaYou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public User()
        //{
        //    Pictures = new HashSet<Pictures>();
        //    Pictures1 = new HashSet<Pictures>();
        //    Pictures2 = new HashSet<Pictures>();
        //}

        public int Id { get; set; }
        [DisplayName("�û�")]
        public string Name { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }
        [DisplayName("������Ʒ����")]
        [InverseProperty("FromUsed")]
        /// <summary>
        /// ������ƷͼƬ
        /// </summary>
        public virtual List<Picture> Used { get; set; }
        [InverseProperty("FromHeadshot")]
        /// <summary>
        /// �û�ͷ��
        /// </summary>
        public virtual List<Picture> Headshot { get; set; }
        [InverseProperty("FromDealshot")]
        /// <summary>
        /// ũ��
        /// </summary>
        public virtual List<Picture> Deal { get; set; }
        /// <summary>
        /// ��Ʒ
        /// </summary>
        public virtual List<Product> Products { get; set; }

    }
}
