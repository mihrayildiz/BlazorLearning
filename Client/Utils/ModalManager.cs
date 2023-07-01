using Blazored.Modal;
using Blazored.Modal.Services;
using BlazorLearaning.Client.CustomComponents.ModelComponents;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MealOrdering.Client.Utils
{
    public class ModalManager
    {
        private readonly IModalService modalService;

        public ModalManager(IModalService ModalService)
        {
            modalService = ModalService;
        }




        public async Task ShowMessageAsync(String Title, String Message, int Duration = 0) //title ve message parametreleri gidecek.
        {
            ModalParameters mParams = new ModalParameters();
            mParams.Add("Message", Message);

            var modalRef = modalService.Show<ShowMessagesPopupComponent>(Title, mParams);  //ShowMessagesPopupComponent.razoruna gidildi.

            if (Duration > 0)
            {
                await Task.Delay(Duration);
                modalRef.Close();
            }
        }

        public async Task<bool> ConfirmationAsync(String Title, String Message) 
        {
            ModalParameters mParams = new ModalParameters();
            mParams.Add("Message", Message);

            var modalRef = modalService.Show<ConfirmationPopupComponent>(Title, mParams);
            var modalResult = await modalRef.Result;

            return !modalResult.Cancelled;
        }


    }
}

//modalmanger neden oluşturuldu? 
//Sayfa içerisinde ki butonlara işlemler uygulandığında butonlardan dönen sonuçları tutmak için 
