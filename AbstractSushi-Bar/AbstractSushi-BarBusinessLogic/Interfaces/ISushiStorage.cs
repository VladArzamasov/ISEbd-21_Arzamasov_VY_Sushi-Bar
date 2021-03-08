using AbstractSushi_BarBusinessLogic.BindingModels;
using AbstractSushi_BarBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace AbstractSushi_BarBusinessLogic.Interfaces
{
    public interface ISushiStorage
    {
        List<SushiViewModel> GetFullList();
        List<SushiViewModel> GetFilteredList(SushiBindingModel model);
        SushiViewModel GetElement(SushiBindingModel model);
        void Insert(SushiBindingModel model);
        void Update(SushiBindingModel model);
        void Delete(SushiBindingModel model);
    }
}
