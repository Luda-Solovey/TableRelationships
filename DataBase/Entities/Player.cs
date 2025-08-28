
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Entities
{
    [PrimaryKey(nameof(Id))]
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

       // [ForeignKey(nameof(Team))]
        public int? TeamId { get; set; }// зовнішній ключ. У зв'язку "один до багатьох" це поле обов'язкове
                                        // прописується  в дочірньому класі     (в батьківському не прописується)
                                        //в VS воно для швидкого доступу з гравця до команди (без join-а, просто через крапочку)

        public Team? Team { get; set; }//навігаційна властивість
    }
}
