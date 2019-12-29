$(function () {

    select2Complete('select2', 'home/GetCharactersByName');

$(".select2").on("change", function() {
    var id = $(this).val();

    $.getJSON('/home/GetCharactersById',
    {        
      characterId : id
    }).done(function( response ) {
     
        $('.character-name').text(response.Name);
        $('.character-description').text(response.Description);
        $('.character-thumbnail').attr('src', response.Thumbnail);
       
    });

    $.getJSON('home/GetStoriesByCharacterId',
    {        
      characterId : id
    }).done(function( response ) {
                        
        var length = response.length > 5 ? 5 : response.length;

        var items = '';

        $('.list-stories').html('');
        $('.title-list-stories').fadeIn();

        if (length == 0){
            items = '<li class="mb-2">Nenhuma história encontrada</li>';
        }else{
    
            for(var i = 0; i < length; i++){
                items += '<li class="mb-2">' + response[i].Title + '(Edição Original' + response[i].OriginalIssue + ')</li>';
            }
        }

        $('.list-stories').html(items);
       
    });

});

})

var loadingMonitor = function () {
    this.$('.js-loading-bar').modal({
        backdrop: 'static',
        show: false
    });

    var $modal = $('.js-loading-bar');
    $(document).ajaxSend(function () {
        requisicao = true;
        setTimeout(function () {
            verificarequisicao();
        }, 100);
    });

    $(document).ajaxComplete(function () {
        requisicao = false;
        $modal.modal('hide');
    });

    function verificarequisicao() {
        if (requisicao) {
            $modal.modal('show');
        }
    }
}

var select2Complete = function (cssClass, url) {

    $("." + cssClass).select2({        
        minimumInputLength: 3,        
        delay: 250,
        allowClear: true,
        placeholder: "selecione",
        language: "pt-BR",
        cache:false,
        ajax: {
            url: url,
            type: "POST",
            dataType: 'json',
            data: function(params) {
                return {
                    term: params.term, 
                };
            },
            processResults: function (response) {               
                return {                         
                    
                    results: response
                };
            },

        },
    });

}
