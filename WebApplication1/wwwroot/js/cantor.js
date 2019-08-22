
function CreateEdit(data) { 
      
    var body = document.getElementsByTagName("main")[0];

    //H4
    var TituloH4 = document.createElement("h4");
    var TituloH4Text = document.createTextNode("Cantor");

    TituloH4.appendChild(TituloH4Text);

    body.appendChild(TituloH4);

    var linha = document.createElement("hr");
    body.appendChild(linha);


    var divGeral = document.createElement("div");
    divGeral.setAttribute('class', 'col-md-10');
    body.appendChild(divGeral);



    var form = document.createElement("FORM");
    divGeral.appendChild(form);

    var divRow = document.createElement("div");
    divRow.setAttribute('class', 'row');
    form.appendChild(divRow);

    var inputHidden = document.createElement("INPUT");
    inputHidden.setAttribute("type", "hidden");
    inputHidden.id = "input-id";

    //inputHidden.value = data.cantorID;
    divRow.appendChild(inputHidden);

    var divCantor = document.createElement("div");
    divCantor.setAttribute('class', 'form-group col-md-4');
    divRow.appendChild(divCantor);

    var lblCantor = document.createElement("LABEL")
    lblCantor.innerHTML = "Nome";
    lblCantor.setAttribute('class', 'form-label');

    divCantor.appendChild(lblCantor);

    var inputCantor = document.createElement("INPUT");
    inputCantor.setAttribute("type", "text");
    inputCantor.className = "form-control";
    inputCantor.id = "input-nome";

    divCantor.appendChild(inputCantor);

    var quebra = document.createElement("br");
    divCantor.appendChild(quebra);

    var divBTN = document.createElement("div");
    divBTN.setAttribute('class', 'form-group');
    divCantor.appendChild(divBTN);

    var inputBTN = document.createElement("INPUT");
    inputBTN.setAttribute("type", "submit");
    inputBTN.className = "btn btn-primary";
    divBTN.appendChild(inputBTN);


    //link para voltar para lista
    var p_link = document.createElement("p");
    var temp_link = document.createElement("a");
    temp_link.innerHTML = "<< Voltar";

    temp_link.href = "http://localhost:54054/Cantor/Index";

    p_link.appendChild(temp_link);

    divCantor.appendChild(p_link);



    //File
    var divDesc = document.createElement("div");
    divDesc.setAttribute('class', 'form-group col-md-6');
    divRow.appendChild(divDesc);

    var lblDesc = document.createElement("LABEL")
    lblDesc.innerHTML = "Selecione Foto";
    lblDesc.setAttribute('class', 'form-label');

    divDesc.appendChild(lblDesc);

    var inputForm = document.createElement("INPUT");
    inputForm.setAttribute("type", "file");
    inputForm.className = "file";
    inputForm.id = "input-file";
    divDesc.appendChild(inputForm);

    body.appendChild(divGeral);


    $.ajax({
        type: "GET",
        url: "/Cantor/GetDados/" + data,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log(data);

            $('#input-nome').val(data.nome);
            $('#input-id').val(data.cantorID);

            if (data.imgCantor != null) {
                    //var base64 = Base64.decode(data.imgCantor);
                    //var imgsrc = string.format("data:image/png;base64,{0}", data.imgCantor);               

                $("#input-file").fileinput({
                        'showUpload': false,
                        'showPreview': true,
                        'initialPreview': [
                            '<img src="data:image/png;base64,' + data.imgCantor + '" style="width: 200px; height: 200px;" />'
                        ]
                    });

            } else {
                $("#input-file").fileinput({
                        'showUpload': false,
                        'showPreview': true

                 });
            }
        }
    }).fail(function (jqxhr, status, error) {
        console.log(error);
    });
            
 }
        
        
        
        
//$(function () {
//    $.ajax({
//        type: "GET",
//        url: "/Cantor/GetDados/" + data,
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (data) {
//            console.log(data);
//            var s = '';

//            s += '<h4>Cantor</h4>'
//            s += '<hr />'
//            s += '<div class="row">'
//            s += '<div class="col-md-6">'
//            s += '<form asp-action="Create" enctype="multipart/form-data">'
//            s += '<div asp-validation-summary="ModelOnly" class="text-danger"></div>'
//            s += '<input  type="hidden" value="' + data.cantorID + '" asp-for="CantorID" />'
//            s += '<div class="form-group col-md-8">'
//            s += '<label asp-for="Nome" class="control-label"></label>'
//            s += '<input asp-for="Nome" value="' + data.nome + '" class="form-control" />'
//            s += '<span asp-validation-for="Nome" class="text-danger"></span>'
//            s += '</div>'

//            s += '<div class="form-group col-md-8">'
//            s += '<label class="control-label">Selecione Foto</label>'
//            s += '<input id="input-id" type="file" asp-for="imgMusica" class="file" data-preview-file-type="text">'
//            s += '</div>'

//            s += '<div class="form-group col-md-8">'
//            s += '<input type="submit" value="Submit" class="btn btn-primary" />'
//            s += '</div>'
//            s += '</form>'
//            s += '</div>'
//            s += '</div>'
//            s += '<div>'
//            s += '<a asp-action="Index">Back to List</a>'
//            s += '</div>'

//            $('#result4').html(s);


//        }
//    }).fail(function (jqxhr, status, error) {
//        console.log(error);
//    });
//});

//if (data.imgCantor != null) {
                //    //var base64 = Base64.decode(data.imgCantor);
                //    //var imgsrc = string.format("data:image/png;base64,{0}", data.imgCantor);               

                //    $("#input-id").fileinput({
                //        'showUpload': false,
                //        'showPreview': true,
                //        'initialPreview': [
                //            '<img src="data:image/png;base64,' + data.imgCantor + ' style="width: 200px; height: 200px;" />'
                //        ]
                //    });

                //} else {
                //    $("#input-id").fileinput({
                //        'showUpload': false,
                //        'showPreview': true

                //    });
                //}