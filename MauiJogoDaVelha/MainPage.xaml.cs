using System;

namespace MauiJogoDaVelha;

public partial class MainPage : ContentPage
{
    string vez = "X";
    Button[,] botoes;

#pragma warning disable CS8618
    public MainPage()
#pragma warning restore CS8618
    {
        InitializeComponent();
#pragma warning disable CS8622 
        Loaded += MainPage_Loaded;
#pragma warning restore CS8622 
    }

    private void MainPage_Loaded(object sender, EventArgs e)
    {
        botoes = new Button[,]
        {
            { btn10, btn11, btn12 },
            { btn20, btn21, btn22 },
            { btn30, btn31, btn32 }
        };
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Button btn = (Button)sender;

        btn.Text = vez;
        btn.IsEnabled = false;

        if (VerificarVitoria(vez))
        {
            DisplayAlert("Parabéns!", $"O {vez} ganhou!", "OK");
            Zerar();
            return;
        }

        if (VerificarEmpate())
        {
            DisplayAlert("Empate!", "Deu velha!", "OK");
            Zerar();
            return;
        }

        vez = (vez == "X") ? "O" : "X";
    }

    private bool VerificarVitoria(string jogador)
    {
        for (int i = 0; i < 3; i++)
        {
            // Verifica linhas
            if (botoes[i, 0].Text == jogador && botoes[i, 1].Text == jogador && botoes[i, 2].Text == jogador)
                return true;

            // Verifica colunas
            if (botoes[0, i].Text == jogador && botoes[1, i].Text == jogador && botoes[2, i].Text == jogador)
                return true;
        }

        // Verifica diagonais
        if (botoes[0, 0].Text == jogador && botoes[1, 1].Text == jogador && botoes[2, 2].Text == jogador)
            return true;

        if (botoes[0, 2].Text == jogador && botoes[1, 1].Text == jogador && botoes[2, 0].Text == jogador)
            return true;

        return false;
    }

    private bool VerificarEmpate()
    {
        foreach (var btn in botoes)
        {
            if (string.IsNullOrEmpty(btn.Text))
                return false;
        }
        return true;
    }

    private void Zerar()
    {
        foreach (var btn in botoes)
        {
            btn.Text = "";
            btn.IsEnabled = true;
        }
        vez = "X";
    }
}


