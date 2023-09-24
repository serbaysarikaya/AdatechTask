$(document).ready(function () {
    console.log("start-index");   
    /* DataTables start here. */
    $('#booksTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: [
            {
                text: 'Ekle',
                attr: {
                    id: "btnAdd",
                },
                className: 'btn btn-success',
                action: function (e, dt, node, config) {
                }
            },
            {
                text: 'Yenile',
                className: 'btn btn-warning',
                action: function (e, dt, node, config) {
                    $.ajax({
                        type: 'GET',
                        url: '/Admin/Book/GetAllBooks/',
                        contentType: "application/json",
                        beforeSend: function () {
                            $('#booksTable').hide();
                            $('.spinner-border').show();
                        },
                        success: function (data) {
                            const bookListDto = jQuery.parseJSON(data);
                            console.log(bookListDto);
                            if (bookListDto.ResultStatus === 0) {
                                let tableBody = "";
                                $.each(bookListDto.Books.$values,
                                    function (index, book) {
                                        tableBody += `
                                                <tr name=${book.Id}>
                                    <td>
                                <button class="btn btn-primary btn-sm btn-update" data-id="${book.Id}"><span class="fas fa-edit"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${book.Id}"><span class="fas fa-minus-circle"></span></button>
                                    </td>
                                    <td>${book.Id}</td>
                                    <td>${book.Title}</td>
                                    <td>${book.Author}</td>
                                    <td>${convertToShortDate(book.PublicationDate)}</td>
                                    <td>${book.ISBN}</td>
                                    <td>${book.Category}</td>
                                    <td>${book.PageCount}</td>
                                    <td>${book.Publisher}</td>
                                    <td>${book.IsActive ? "Evet" : "Hayır"}</td>
                                    <td>${book.IsDeleted ? "Evet" : "Hayır"}</td>
                                    <td>${convertToShortDate(book.CreatedDate)}</td>
                                    <td>${book.CreatedByName}</td>
                                    <td>${convertToShortDate(book.ModifiedDate)}</td>
                                    <td>${book.ModifiedByName}</td>
                                     </tr>`;
                                    });
                                $('#booksTable > tbody').replaceWith(tableBody);
                                $('.spinner-border').hide();
                                $('#booksTable').fadeIn(1400);
                            } else {
                                toastr.error(`${bookListDto.Message}`, 'İşlem Başarısız!');
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            $('.spinner-border').hide();
                            $('#booksdTable').fadeIn(1000);
                            toastr.error(`${err.responseText}`, 'Hata!');
                        }
                    });
                }
            }
        ],
        language: {
            "sDecimal": ",",
            "sEmptyTable": "Tabloda herhangi bir veri mevcut değil",
            "sInfo": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
            "sInfoEmpty": "Kayıt yok",
            "sInfoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Sayfada _MENU_ kayıt göster",
            "sLoadingRecords": "Yükleniyor...",
            "sProcessing": "İşleniyor...",
            "sSearch": "Ara:",
            "sZeroRecords": "Eşleşen kayıt bulunamadı",
            "oPaginate": {
                "sFirst": "İlk",
                "sLast": "Son",
                "sNext": "Sonraki",
                "sPrevious": "Önceki"
            },
            "oAria": {
                "sSortAscending": ": artan sütun sıralamasını aktifleştir",
                "sSortDescending": ": azalan sütun sıralamasını aktifleştir"
            },
            "select": {
                "rows": {
                    "_": "%d kayıt seçildi",
                    "0": "",
                    "1": "1 kayıt seçildi"
                }
            }
        }
    });

    /* DataTables end here */

    /* Ajax GET / Getting the _CategoryAddPartial as Modal Form starts from here. */
    $("#datepicker").datepicker({
        closeText: "kapat",
        prevText: "&#x3C;geri",
        nextText: "ileri&#x3e",
        currentText: "bugün",
        monthNames: ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran",
            "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"],
        monthNamesShort: ["Oca", "Şub", "Mar", "Nis", "May", "Haz",
            "Tem", "Ağu", "Eyl", "Eki", "Kas", "Ara"],
        dayNames: ["Pazar", "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi"],
        dayNamesShort: ["Pz", "Pt", "Sa", "Ça", "Pe", "Cu", "Ct"],
        dayNamesMin: ["Pz", "Pt", "Sa", "Ça", "Pe", "Cu", "Ct"],
        weekHeader: "Hf",
        dateFormat: "dd.mm.yy",
        firstDay: 1,
        isRTL: false,
        showMonthAfterYear: false,
        yearSuffix: "",
        duration: 500,
        showAnim: "fold",
        showOptions: { direction: "down" },
        minDate: -3,
        maxDate: +3
    });
    $(function () {
        const url = '/Admin/Book/Add/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $('#btnAdd').click(function () {
            $.get(url).done(function (data) {
                placeHolderDiv.html(data);
                placeHolderDiv.find(".modal").modal('show');
            });
        });

        /* Ajax GET / Getting the _CategoryAddPartial as Modal Form ends here. */
        /* Ajax POST / Posting the FormData as CategoryAddDto starts from here. */
        placeHolderDiv.on('click',
            '#btnSave',
            function (event) {
                event.preventDefault();
                const form = $('#form-book-add');
                const actionUrl = form.attr('action');
                const dataToSend = form.serialize();
                $.post(actionUrl, dataToSend).done(function (data) {
                    console.log(data);
                    const bookAddAjaxModel = jQuery.parseJSON(data);
                    console.log(bookAddAjaxModel);
                    const newFormBody = $('.modal-body', bookAddAjaxModel.BookAddPartial);
                    placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                    const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        placeHolderDiv.find('.modal').modal('hide');
                        const newTableRow = `
                                <tr name="${bookAddAjaxModel.BookDto.Book.Id}">
                                                     <td>
                            <button class="btn btn-primary btn-sm btn-update" data-id="${bookAddAjaxModel.BookDto.Book.Id}"><span class="fas fa-edit"></span></button>
                            <button class="btn btn-danger btn-sm btn-delete" data-id="${bookAddAjaxModel.BookDto.Book.Id}"><span class="fas fa-minus-circle"></span></button>
                                                    </td>
                                                    <td>${bookAddAjaxModel.BookDto.Book.Id}</td>
                                                    <td>${bookAddAjaxModel.BookDto.Book.Title}</td>
                                                    <td>${bookAddAjaxModel.BookDto.Book.Author}</td>
                                                    <td>${convertToShortDate(bookAddAjaxModel.BookDto.Book.PublicationDate)}</td>
                                                    <td>${bookAddAjaxModel.BookDto.Book.ISBN}</td>
                                                    <td>${bookAddAjaxModel.BookDto.Book.Category}</td>
                                                    <td>${bookAddAjaxModel.BookDto.Book.PageCount}</td>
                                                    <td>${bookAddAjaxModel.BookDto.Book.Publisher}</td>
                                                    <td>${bookAddAjaxModel.BookDto.Book.IsActive ? "Evet" : "Hayır"}</td>
                                                    <td>${bookAddAjaxModel.BookDto.Book.IsDeleted ? "Evet" : "Hayır"}</td>
                                                    <td>${convertToShortDate(bookAddAjaxModel.BookDto.Book.CreatedDate)}</td>
                                                    <td>${bookAddAjaxModel.BookDto.Book.CreatedByName}</td>
                                                    <td>${convertToShortDate(bookAddAjaxModel.BookDto.Book.ModifiedDate)}</td>
                                                    <td>${bookAddAjaxModel.BookDto.Book.ModifiedByName}</td>
                                                  
                                                </tr>`;
                        const newTableRowObject = $(newTableRow);
                        newTableRowObject.hide();
                        $('#booksTable').append(newTableRowObject);
                        newTableRowObject.fadeIn(3500);
                        toastr.success(`${bookAddAjaxModel.BookDto.Message}`, 'Başarılı İşlem!');
                    } else {
                        let summaryText = "";
                        $('#validation-summary > ul > li').each(function () {
                            let text = $(this).text();
                            summaryText = `*${text}\n`;
                        });
                        toastr.warning(summaryText);
                    }
                });
            });
    });

    /* Ajax POST / Posting the FormData as CategoryAddDto ends here. */

    /* Ajax POST / Deleting a Category starts from here */
    $(document).on('click',
        '.btn-delete',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
            const bookTitle = tableRow.find('td:eq(1)').text();
            Swal.fire({
                title: 'Silmek istediğinize emin misiniz?',
                text: `${bookTitle} adlı kategori silinicektir!`,
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Evet, silmek istiyorum.',
                cancelButtonText: 'Hayır, silmek istemiyorum.'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        data: { bookId: id },
                        url: '/Admin/Book/Delete/',
                        success: function (data) {
                            const bookDto = jQuery.parseJSON(data);
                            if (bookDto.ResultStatus === 0) {
                                Swal.fire(
                                    'Silindi!',
                                    `${bookDto.Book.Title} adlı kategori başarıyla silinmiştir.`,
                                    'success'
                                );

                                tableRow.fadeOut(3500);
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `${bookDto.Message}`,
                                });
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            toastr.error(`${err.responseText}`, "Hata!")
                        }
                    });
                }
            });
        });

    /* Ajax GET / Getting the _CategoryUpdatePartial as Modal Form starts from here. */

    $(function () {
        const url = '/Admin/Book/Update/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click',
            '.btn-update',
            function (event) {
                event.preventDefault();
                const id = $(this).attr('data-id');
                $.get(url, { bookId: id }).done(function (data) {
                    placeHolderDiv.html(data);
                    placeHolderDiv.find('.modal').modal('show');
                }).fail(function () {
                    toastr.error("Bir hata oluştu.");
                });
            });

        /* Ajax POST / Updating a Category starts from here */

        placeHolderDiv.on('click',
            '#btnUpdate',
            function (event) {
                event.preventDefault();

                const form = $('#form-book-update');
                const actionUrl = form.attr('action');
                const dataToSend = form.serialize();
                $.post(actionUrl, dataToSend).done(function (data) {
                    const bookUpdateAjaxModel = jQuery.parseJSON(data);
                    console.log(bookUpdateAjaxModel);
                    const newFormBody = $('.modal-body', bookUpdateAjaxModel.BookUpdatePartial);
                    placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                    const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        placeHolderDiv.find('.modal').modal('hide');
                        const newTableRow = `
                                <tr name="${bookUpdateAjaxModel.BookDto.Book.Id}">
                                             <td>
                         <button class="btn btn-primary btn-sm btn-update" data-id="${bookUpdateAjaxModel.BookDto.Book.Id}"><span class="fas fa-edit"></span></button>
                         <button class="btn btn-danger btn-sm btn-delete" data-id="${bookUpdateAjaxModel.BookDto.Book.Id}"><span class="fas fa-minus-circle"></span></button>
                                                    </td>
                                                    <td>${bookUpdateAjaxModel.BookDto.Book.Id}</td>
                                                    <td>${bookUpdateAjaxModel.BookDto.Book.Title}</td>
                                                    <td>${bookUpdateAjaxModel.BookDto.Book.Author}</td>
                                                    <td>${convertToShortDate(bookUpdateAjaxModel.BookDto.Book.PublicationDate)}</td>
                                                    <td>${bookUpdateAjaxModel.BookDto.Book.ISBN}</td>
                                                    <td>${bookUpdateAjaxModel.BookDto.Book.Category}</td>
                                                    <td>${bookUpdateAjaxModel.BookDto.Book.PageCount}</td>
                                                    <td>${bookUpdateAjaxModel.BookDto.Book.Publisher}</td>
                                                    <td>${bookUpdateAjaxModel.BookDto.Book.IsActive ? "Evet" : "Hayır"}</td>
                                                    <td>${bookUpdateAjaxModel.BookDto.Book.IsDeleted ? "Evet" : "Hayır"}</td>
                                                    <td>${convertToShortDate(bookUpdateAjaxModel.BookDto.Book.CreatedDate)}</td>
                                                    <td>${bookUpdateAjaxModel.BookDto.Book.CreatedByName}</td>
                                                    <td>${convertToShortDate(bookUpdateAjaxModel.BookDto.Book.ModifiedDate)}</td>
                                                    <td>${bookUpdateAjaxModel.BookDto.Book.ModifiedByName}</td>
                                                </tr>`;
                        const newTableRowObject = $(newTableRow);
                        const bookTableRow = $(`[name="${bookUpdateAjaxModel.BookDto.Book.Id}"]`);
                        newTableRowObject.hide();
                        bookTableRow.replaceWith(newTableRowObject);
                        newTableRowObject.fadeIn(3500);
                        toastr.success(`${bookUpdateAjaxModel.BookDto.Message}`, "Başarılı İşlem!");
                    } else {
                        let summaryText = "";
                        $('#validation-summary > ul > li').each(function () {
                            let text = $(this).text();
                            summaryText = `*${text}\n`;
                        });
                        toastr.warning(summaryText);
                    }
                }).fail(function (response) {
                    console.log(response);
                });
            });

    });

   

});