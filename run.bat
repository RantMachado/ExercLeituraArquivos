rem Author: Randolfo Machado
rem Data: 22/07/2019

@echo off
cls
:menu
cls 
color 71

echo Computador: %computername%  Usuario: %username%    %date% 
echo.
echo	Iniciar Programa In Out Arquivos
echo ==========================================
echo * 1. Rodar programa                      * 
echo * 2. Fechar terminal                     *
echo ==========================================

set /p opcao= Escolha uma opcao: 

echo ------------------------------

if %opcao% equ 1 goto opcao1
if %opcao% equ 2 goto opcao2
if %opcao% geq 3 goto opcao3

:opcao1
cls
echo =============================
echo *     Abrindo programa      *
echo =============================
cd "C:\Users\%username%\source\repos\ExercInOutArquivo\ExercInOutArquivo"
dotnet run "C:\temp\MyFolder\Arquivo\INPUT.csv"
pause
goto menu

:opcao2
cls
exit

:opcao3
cls
echo ===============================================
echo * Opcao Invalida! Escolha outra opcao do menu *
echo ===============================================
pause
goto menu

