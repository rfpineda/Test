function msgConfirmar(idBoton, script, mensaje, titulo, lblBtnConfirmar, lblBtnCancelar) {
    if (script) {
        $('<div><table border=0 width=100% height=100%><tr><td class="Label"><b>' + mensaje + '</b></td></tr></table></div>').dialog({
            title: '..:: ' + titulo + ' ::..',
            modal: true,
            height: 180,
            width: 400,
            autoOpen: true,
            closeOnEscape: true,
            show: { effect: 'bounce', duration: 300 },
            hide: 'explode',
            buttons: [
                {
                    text: lblBtnConfirmar,
                    click: function () {
                        if (idBoton.lenght > 0) {
                            __doPostBack(idBoton, '');
                        } else {
                            eval(script);
                        }
                        $(this).dialog("close");
                    }
                },
                {
                    text: lblBtnCancelar,
                    click: function () {
                        $(this).dialog("close");
                    }
                }
            ]
        });
    }
    return false;
}