5 constant width

: letters ( -- c-addr u )
    s" .-   -... -.-. -..  .    ..-. --.  .... ..   .--- -.-  .-.. --   -.   ---  .--. --.- .-.  ...  -    ..-  ...- .--  -..- -.-- --.. " ;

: morse ( n -- c-addr u ) width * letters drop + width -trailing ;

: letter? ( c -- flag ) toupper [char] A [char] Z 1+ within ;
: >index ( c -- n ) toupper [char] A - ;
: .letter ( c -- ) >index morse type ;
