namespace Implanta.WebFormsCRUD.IView.Base
{
    public interface IViewEdicaoSimple : Common.IViewEdicaoSimple, IViewImplanta
    {
        bool Erro { get; set; }
    }
}
