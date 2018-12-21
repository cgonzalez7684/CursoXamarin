# Curso de Xamarin

## Contacto
Esteban Solano @stvansolano 
Email: stvansolano@outlook.com 
Blog: http://stvansolano.github.io/blog

## Links de Xamarin (Sesion 1)

http://stvansolano.github.io/2018/08/30/Guia-de-instalacion-Xamarin-y-herramientas-recomendadas/

http://stvansolano.github.io/2016/10/31/Como-desplegar-apps-para-Android-en-tu-dispositivo-fisico/

http://vysor.io/

https://docs.microsoft.com/en-us/xamarin/tools/live-player/

https://www.android.com/history/#/marshmallow

## Comandos de Git (Sesion 2)

http://rogerdudler.github.io/git-guide/

1) cd [carpeta del proyecto]
2) git init (iniciar Git en la carpeta)
3) git status (ver el estado de los archivos)
4) git add -A (agregar todos los archivos)
5) git commit -m "Primer commit"
6) git remote add origin https://github.com/stvansolano/curso-xamarin.git
7) git push origin master -f

Xamarin.Forms en Git: https://github.com/xamarin/Xamarin.Forms

## Xamarin.Forms Intro (Sesion 3)

* Comandos vrs eventos
* XAML vrs C#
* ContentPage vrs Content (`View`)
* Bindings => `{Binding Text, Source={x:Reference entryNombre}}` No necesita C#!
* Material de referencia: [Xamarin.Forms](https://docs.microsoft.com/es-ES/xamarin/xamarin-forms/xaml/xaml-basics/)
* XAML-C (Xaml compilation)

`[assembly: XamlCompilation (XamlCompilationOptions.Compile)]`

## ListView (Sin Forms)

iOS - https://docs.microsoft.com/en-us/xamarin/ios/user-interface/controls/tables/populating-a-table-with-data
Android - https://docs.microsoft.com/en-us/xamarin/android/user-interface/layouts/list-view/