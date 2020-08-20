IF EXIST C:\SignLanguage (
    echo folder already exists
) ELSE (
    echo creat folder..
    mkdir C:\SignLanguage
)
echo copying files..
copy "%~dp0\DB.db" C:\SignLanguage