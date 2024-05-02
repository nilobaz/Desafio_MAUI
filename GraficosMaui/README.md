# Gráficos MAUI
### Teste técnico para GFT - BTG Pactual

A aplicação feita em .NET MAUI utiliza .NET 8 e a biblioteca SkiaSharp para criar gráficos gerados a partir de movimentos brownianos. O projeto utiliza MVVM.

O arquivo `MainPage.xaml` é o arquivo XAML que define a estrutura da página principal da aplicação. Ele contém um layout de grade com duas colunas. A primeira coluna contém um controle personalizado `SkiaGraphView` que exibe o gráfico. A segunda coluna contém uma série de controles de entrada para configurar os parâmetros do gráfico, como preço inicial, volatilidade média, retorno médio, tempo em dias e número de linhas. Também possui um botão para gerar a simulação do gráfico.

A classe `MainPageViewModel` é responsável por gerenciar os dados e a lógica da página principal da aplicação. Ela possui propriedades para armazenar os valores de `sigma` (volatilidade média), `mean` (retorno médio), `initialPrice` (preço inicial), `numDays` (tempo em dias) e `numberLines` (número de linhas para exibir no gráfico). Além disso, possui um método assíncrono `GenerateData` que gera os dados para o gráfico de movimentos brownianos.

A classe `SkiaGraphView` é uma classe personalizada que herda da classe `SKCanvasView` da biblioteca SkiaSharp. Ela é responsável por desenhar o gráfico na tela. Possui propriedades para armazenar os dados do gráfico (`SkiaGraphData`) e o número de linhas (`NumberLines`). O método `OnPaintSurface` é sobrescrito para desenhar o gráfico utilizando os dados fornecidos.

O arquivo `Usings.cs` contém os namespaces utilizados na aplicação, incluindo os namespaces das classes mencionadas acima, além de outros namespaces relacionados ao SkiaSharp, ao toolkit `CommunityToolkit.Mvvm`.

O código `GenerateBrownianMotion` fornecido foi levemente alterado visando sua extensão e melhoria de performance.

<img src="/GraficosMaui/img/tela1.png">

