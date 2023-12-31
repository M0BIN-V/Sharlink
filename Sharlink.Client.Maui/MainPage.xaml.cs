﻿using Microsoft.Maui.Controls.Shapes;
using Sharlink.Client.Hub;
using Sharlink.Client.Hub.Models;
using Sharlink.Client.Maui.Data;
using Sharlink.Client.Maui.Models;
using Sharlink.Client.Maui.Utilities;

namespace Sharlink.Client.Maui;

public partial class MainPage : ContentPage
{
    readonly ClientChatHub _chathub = new();

    string _userName = "MAUI APP";

    public MainPage()
    {
        InitializeComponent();

        _ = _chathub.StartAsync((message) =>
        {
            MainThread.BeginInvokeOnMainThread(() =>
            AddMessage(message, message.UserName == _userName ? FlowDirection.RightToLeft : FlowDirection.LeftToRight));
        });
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(MessageBox.Text))
        {
            _chathub.SendMessage(new Message()
            {
                UserName = _userName,
                Content = MessageBox.Text
            });

            MessageBox.Text = "";
        }
    }

    private async void AddMessage(Message message, FlowDirection align)
    {
        if (!TmpDb.UserColors.Any(uc => uc.UserName == message.UserName))
        {
            TmpDb.UserColors.Add(new UserColor { UserName = message.UserName, Color = UserColorGenerator.GetNewColor() });
        }

        var messageColor = TmpDb.UserColors.Single(uc => uc.UserName == message.UserName).Color;

        var header = new Label
        {
            Text = $"{DateTime.Now.Hour}:{DateTime.Now.Minute} | {message.UserName}",
            FontSize = 12,
            HeightRequest = 20,
            TextColor = messageColor,
            Padding = 3,
            Margin = new Thickness(20, 0, 0, -10)
        };

        var cornerRadius = new CornerRadius(
            topLeft: 10,
            topRight: 10,
            bottomLeft: align == FlowDirection.LeftToRight ? 0 : 10,
            bottomRight: align == FlowDirection.LeftToRight ? 10 : 0
            );

        var bodyBorder = new Border
        {
            Stroke = messageColor,
            StrokeShape = new RoundRectangle
            {
                CornerRadius = cornerRadius
            },
            Content = new Label
            {
                Text = message.Content,
                Margin = new Thickness(20, 7, 20, 0),
                FontSize = 15,
                TextColor = Colors.White,
            },
            BackgroundColor = Color.FromArgb("#2E323A")
        };

        var messageBody = new HorizontalStackLayout
        {
            FlowDirection = align,
            HeightRequest = 50,
            Padding = new Thickness(20, 12, 0, 0)
        };
        messageBody.Add(bodyBorder);

        var messageView = new VerticalStackLayout
        {
            header,
            messageBody
        };

        messageView.Padding = new Thickness(0, 10, 0, 0);
        messageView.FlowDirection = align;

        MessageViewer.Add(messageView);

        await Scroller.ScrollToAsync(MessageViewer, ScrollToPosition.End, false);
    }

    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
        do
        {
            _userName = await DisplayPromptAsync("Welcome !", "What's your name?", cancel: "");
        }
        while (string.IsNullOrWhiteSpace(_userName));

        TmpDb.UserColors.Add(new UserColor { UserName = _userName, Color = Colors.Aqua });
    }
}
