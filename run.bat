IF EXIST C:\SignLanguage (
    echo files already exists
) ELSE (
    echo copying files..
    mkdir C:\SignLanguage
    copy %~dp0\DB.db C:\SignLanguage
)