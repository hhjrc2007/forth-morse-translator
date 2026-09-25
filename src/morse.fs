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

: to-morse ( "text<eol>" -- ) 0 parse bounds ?do i c@ .char loop cr ;
