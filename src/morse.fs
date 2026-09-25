5 constant width

: letters ( -- c-addr u )
    s" .-   -... -.-. -..  .    ..-. --.  .... ..   .--- -.-  .-.. --   -.   ---  .--. --.- .-.  ...  -    ..-  ...- .--  -..- -.-- --.. " ;

: digits ( -- c-addr u )
    s" -----.----..---...--....-.....-....--...---..----." ;

: morse ( n -- c-addr u -- c-addr u ) drop swap width * + width -trailing ;

: letter? ( c -- flag ) toupper [char] A [char] Z 1+ within ;
: >index ( c -- n ) toupper [char] A - ;
: .letter ( c -- ) >index letters morse type ;

: numeral? ( c -- flag ) [char] 0 [char] 9 1+ within ;
: .digit ( c -- ) [char] 0 - digits morse type ;

: .char ( c -- )
    dup bl = if drop ." / " exit then
    dup letter? if .letter space exit then
    dup numeral? if .digit space exit then
    drop ;

: find-code ( table-addr table-u c-addr u -- n | -1 )
    2over nip width / 0 ?do
        2over i -rot morse 2over compare 0=
        if 2drop 2drop i unloop exit then
    loop 2drop 2drop -1 ;

: .code ( c-addr u -- )
    2dup s" /" compare 0= if 2drop space exit then
    2dup letters 2swap find-code
    dup 0>= if nip nip [char] A + emit exit then drop
    digits 2swap find-code
    dup 0>= if [char] 0 + emit exit then drop
    [char] ? emit ;

: from-morse ( "morse<eol>" -- ) begin parse-name dup while .code repeat 2drop cr ;
