using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenParcialTotal.TagHelpers
{
    public class SemaforoEstadoDiv:TagHelper
    {
        public int estado { get; set; }
        public String DescripcionEstado { get; set; }


        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            string img = "";
            string title = "";
            if (this.estado == 2)
            {
                img = "circulo-verde.png";
                title = "Aprobado";
                this.DescripcionEstado = "Aprobado";
            }
            else if(this.estado == 1)
            {
                img = "circulo-amarillo.png";
                title = "Pendiente";
                this.DescripcionEstado = "Pendiente";
            }
            else 
            {
                img = "circulo-rojo.png";
                title = "Rechazado";
                this.DescripcionEstado = "Rechazado";
            }

            output.TagName = "div";
            img = $"images/{img}";
            StringBuilder sb = new StringBuilder();
            sb.Append("<img ");
            sb.Append(" src = \"");
            sb.Append(img);
            sb.Append(" \" ");
            sb.Append(" title = \"");
            sb.Append(title);
            sb.Append(" \" ");
            sb.Append(" />");
            sb.Append($"<span style='color:blue;'>{this.DescripcionEstado}</span>");


            output.Content.AppendHtml(sb.ToString());


            return base.ProcessAsync(context, output);
        }

    }
}
