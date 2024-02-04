﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace SistemaDeNumeracao
{
    public enum Controls
    {
        None = 0,
        txtBin = 1,
        txtDec = 2,
        txtOct = 3,
        txtHex = 4,
    }
    public class Logic
    {
        #region Construtor
        private frmMain formulario;
        public Logic(frmMain frm)
        {
            formulario = frm;

            // Ativa o binário por padrão.
            controlActive = Controls.txtBin;

        }
        #endregion

        #region Binário
        // Adicionado esta abordagem, por conta de não estar apagando o caractere de espaço, pois o tratamento
        // dentro do método de processamento de formato binário, retira todos os espaços e quebra de linha no início
        // do algarítmo, foi adaptado também para apagar quebras de linha apenas no binário é necessário!
        bool txtBin_BackSpace = false;

        private string FormatBinaryToLayout(string txtBin)
        {
            // Limites de caracteres por linha e caracteres para adicionar uma quebra de linha
            int characterLimit = 8;
            int characterToSpace = 4;

            StringBuilder novoTexto = new StringBuilder();

            txtBin = txtBin.Replace(" ", "").Replace(Environment.NewLine, "");

            int charIndex = 0;
            foreach (char c in txtBin)
            {
                novoTexto.Append(c);
                charIndex++;

                if (charIndex % characterToSpace == 0 && charIndex % characterLimit != 0)
                    novoTexto.Append(" ");

                if (charIndex % characterLimit == 0)
                    novoTexto.Append(Environment.NewLine);
            }

            return novoTexto.ToString();
        }
        public void txtBin_Change(object sender, EventArgs e)
        {
            var text = ((TextBox)sender).Text;

            // Remova o manipulador de eventos temporariamente
            formulario.txtBin.TextChanged -= txtBin_Change;

            // Verifique se o controle atual está ativo.
            if (controlActive == Controls.txtBin)
            {
                if (txtBin_BackSpace)
                {
                    txtBin_BackSpace = false;
                }
                else
                {
                    UpdateValues();

                    formulario.txtBin.SelectionStart = formulario.txtBin.TextLength;
                }
            }

            // Acione o manipulador de eventos.
            formulario.txtBin.TextChanged += txtBin_Change;
        }
        public void txtBin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                var sstring = formulario.txtBin.Text;

                if (formulario.txtBin.SelectionLength == 0 && formulario.txtBin.SelectionStart > 0)
                {
                    int positionBeforeBackspace = formulario.txtBin.SelectionStart - 1;

                    if (formulario.txtBin.Text[positionBeforeBackspace] == ' ' ||
                        (positionBeforeBackspace >= Environment.NewLine.Length &&
                         formulario.txtBin.Text.Substring(positionBeforeBackspace + 1 - Environment.NewLine.Length, Environment.NewLine.Length) == Environment.NewLine))
                    {
                        // Pode prosseguir com a exclusão
                        txtBin_BackSpace = true;
                    }
                }
            }
        }
        private bool IsBin(string bin)
        {
            return bin.All(c => c == '0' || c == '1');
        }
        #endregion

        #region Decimal
        public void txtDec_Change(object sender, EventArgs e)
        {
            // Desative o manipulador de eventos temporariamente.
            formulario.txtBin.TextChanged -= txtDec_Change;

            if (controlActive == Controls.txtDec)
                UpdateValues();

            // Ative o manipulador de eventos.
            formulario.txtBin.TextChanged += txtDec_Change;
        }
        #endregion

        #region AtivacaoControles

        public Controls controlActive;
        public void SetControlActive(object sender, EventArgs e)
        {
            var tipo = sender.GetType();

            if (tipo == null) { return; }

            if (tipo == typeof(TextBox))
            {
                var textBox = (TextBox)sender;

                for (int i = 1; i <= Enum.GetValues(typeof(Controls)).Length; i++)
                {
                    var controlName = Enum.GetName(typeof(Controls), i);

                    if (textBox.Name == controlName)
                    {
                        controlActive = (Controls)i;
                        return;
                    }
                }
            }
        }

        public void UnSetControlActive(object sender, EventArgs e)
        {
            controlActive = Controls.None;
        }
        #endregion

        #region AtualizacaoDados
        public void UpdateValues()
        {
            switch (controlActive)
            {
                case Controls.None: break;
                case Controls.txtBin:
                    var txtBin = formulario.txtBin.Text.Replace(" ", "").Replace(Environment.NewLine, "");

                    if (string.IsNullOrWhiteSpace(txtBin))
                    {
                        formulario.txtDec.Text = "";
                        formulario.txtOct.Text = "";
                        formulario.txtHex.Text = "";
                        return;
                    }
                    if (IsBin(txtBin))
                    {
                        int valorDecimal = Convert.ToInt32(txtBin, 2);

                        formulario.txtBin.Text = FormatBinaryToLayout(txtBin);
                        formulario.txtDec.Text = valorDecimal.ToString();
                        formulario.txtOct.Text = Convert.ToString(valorDecimal, 8);
                        formulario.txtHex.Text = Convert.ToString(valorDecimal, 16).ToUpper();
                    }
                    else
                    {
                        formulario.txtDec.Text = "Invalido";
                        formulario.txtOct.Text = "Invalido";
                        formulario.txtHex.Text = "Invalido";
                    }
                    break;
                case Controls.txtDec:
                    if (int.TryParse(formulario.txtDec.Text, out int txtDec))
                    {
                        formulario.txtBin.Text = FormatBinaryToLayout(Convert.ToString(txtDec, 2));
                        formulario.txtDec.Text = Convert.ToString(txtDec, 10);
                        formulario.txtOct.Text = Convert.ToString(txtDec, 8);
                        formulario.txtHex.Text = txtDec >= 0
                            ? Convert.ToString(txtDec, 16).ToUpper()
                            : "-" + Convert.ToString(Math.Abs(txtDec), 16).ToUpper();
                    }
                    else
                    {
                        formulario.txtBin.Text = "Invalido";
                        formulario.txtOct.Text = "Invalido";
                        formulario.txtHex.Text = "Invalido";
                    }

                    break;
                case Controls.txtOct: break;
                case Controls.txtHex: break;

                default: break;
            }
        }
        #endregion
    }
}
