$(function () {
    function validateForm() {
        let isValid = true;
        let messages = [];

        const name = $('#CustomerName').val().trim();
        const procedure = $('#ProcedureId').val();
        const date = $('#appointmentDate').val();
        const email = $('#Email').val().trim();
        const phone = $('#Phone').val().trim();

        if (name === '') {
            isValid = false;
            messages.push('O nome é obrigatório.');
        }

        if (!procedure) {
            isValid = false;
            messages.push('Selecione um serviço.');
        }

        if (date === '') {
            isValid = false;
            messages.push('A data e hora são obrigatórias.');
        }

        if (email === '') {
            isValid = false;
            messages.push('O e-mail é obrigatório.');
        }

        if (phone === '') {
            isValid = false;
            messages.push('O telefone é obrigatório.');
        }

        if ($('#date-error').text() !== '') {
            isValid = false;
            messages.push('Escolha um horário válido.');
        }

        if (!isValid) {
            Swal.fire({
                icon: 'warning',
                title: 'Campos obrigatórios',
                html: messages.join('<br>')
            });
        }

        return isValid;
    }

    // Validação do horário
    $('#appointmentDate').on('blur change', function () {
        const dateInput = $(this).val();
        if (!dateInput) return;

        $.getJSON('/Appointment/IsTimeAvailable', { date: dateInput })
            .done(function (data) {
                if (!data) {
                    $('#date-error').text('Este horário já está ocupado.');
                } else {
                    $('#date-error').text('');
                }
            })
            .fail(function () {
                $('#date-error').text('Erro ao verificar o horário.');
            });
    });

    // Submissão com validação
    $('#appointmentForm').on('submit', function (e) {
        e.preventDefault();

        if (!validateForm()) {
            return;
        }

        $.ajax({
            url: $(this).attr('action'),
            type: 'POST',
            data: $(this).serialize(),
            success: function (response) {
                if (response.success) {
                    Swal.fire({
                        icon: 'success',
                        title: 'Pronto!',
                        html: response.message,
                        confirmButtonText: 'OK'
                    }).then(() => {
                        $('#appointmentForm')[0].reset();
                        $('#date-error').text('');
                    });
                } else {
                    Swal.fire({
                        icon: 'error',
                        title: 'Erro no agendamento',
                        html: response.message
                    });
                }
            },
            error: function () {
                Swal.fire({
                    icon: 'error',
                    title: 'Falha no servidor',
                    text: 'Tente novamente mais tarde.'
                });
            }
        });
    });
});
