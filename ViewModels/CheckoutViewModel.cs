using System;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MonAmourKiosk.Services;
using QRCoder;

namespace MonAmourKiosk.ViewModels;

public partial class CheckoutViewModel : ObservableObject
{
    public ICartService CartService { get; }
    private readonly INavigationService _navigationService;

    [ObservableProperty] private bool _isCashMethodSelected;
    [ObservableProperty] private bool _isSuccessScreenVisible;
    [ObservableProperty] private BitmapImage? _cashPaymentQrCode;
    [ObservableProperty] private string _orderNumber = string.Empty;

    public CheckoutViewModel(ICartService cartService, INavigationService navigationService)
    {
        CartService = cartService;
        _navigationService = navigationService;
    }

    [RelayCommand]
    public void SelectPaymentMethod(string method)
    {
        if (method == "Espèces")
        {
            OrderNumber = $"M-{new Random().Next(100, 999)}";
            GenerateCashReceiptQr(OrderNumber);
            IsCashMethodSelected = true;
        }
        else
        {
            ExecuteSuccessFlow();
        }
    }

    private void GenerateCashReceiptQr(string orderNum)
    {
        using QRCodeGenerator qrGenerator = new QRCodeGenerator();
        using QRCodeData qrCodeData = qrGenerator.CreateQrCode($"MON-AMOUR-CAFE:{orderNum}:TOTAL:{CartService.Total:F2}", QRCodeGenerator.ECCLevel.Q);
        using QRCode qrCode = new QRCode(qrCodeData);
        using Bitmap qrCodeImage = qrCode.GetGraphic(20);

        using MemoryStream ms = new MemoryStream();
        qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        ms.Position = 0;

        BitmapImage bi = new BitmapImage();
        bi.BeginInit();
        bi.CacheOption = BitmapCacheOption.OnLoad;
        bi.StreamSource = ms;
        bi.EndInit();
        bi.Freeze();

        CashPaymentQrCode = bi;
    }

    [RelayCommand]
    public void ExecuteSuccessFlow()
    {
        if (string.IsNullOrEmpty(OrderNumber)) OrderNumber = $"M-{new Random().Next(100, 999)}";
        IsCashMethodSelected = false;
        IsSuccessScreenVisible = true;
    }

    [RelayCommand]
    public void ResetKiosk()
    {
        CartService.ClearCart();
        _navigationService.NavigateTo<AccueilViewModel>();
    }
}