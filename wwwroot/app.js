var LoadTodos = function () {
    $('#todos').empty();
    $.ajax({
        url: "/todos",
        dataType: "json",
        success: function (response) {
            response.forEach(function (todo) {
                var todoEl = $('<li/>').addClass('collection-item').html(
                    "<div class='row' style='margin-bottom:0'>" +
                    "<div class='col s11'>" +
                    "<input type='checkbox' id='" + todo.id + "' " + (todo.complete ? "checked='checked'" : "") + " />" +
                    "<label for='" + todo.id + "'>" + (todo.complete ? "<del>" : '') + todo.title + (todo.complete ? "</del>" : '') + "</label>" +
                    "</div>" +
                    "<div class='col s1'><a href='#!' class='secondary-content delete-item' style='float:right;'><i class='material-icons'>delete</i></a></div>" +
                    "</div>"
                );
                $(todoEl).find('input[type=checkbox]').on('click', function () {
                    if (!todo.complete) {
                        CompleteTodo(todo.id).always(function () { LoadTodos(); })
                    } else {
                        UnCompleteTodo(todo.id).always(function () { LoadTodos(); })
                    }
                });

                $(todoEl).find('.delete-item').on('click', function () {
                    DeleteTodo(todo.id).always(function () { LoadTodos(); })
                });
                $('#todos').append(todoEl);
            }, this);
        }
    })
}

var AddTodo = function (formEl) {
    return $.ajax({
        url: "/todos/create",
        type: "POST",
        data: $(formEl).serialize(),
        success: function () {
            $(formEl).find('todo_input').val('');
        }
    })
}

var CompleteTodo = function (todoID) {
    return $.ajax({
        url: "/todos/" + todoID + "/complete",
        type: "PUT"
    })
}

var UnCompleteTodo = function (todoID) {
    return $.ajax({
        url: "/todos/" + todoID + "/uncomplete",
        type: "PUT"
    })
}

var DeleteTodo = function (todoID) {
    return $.ajax({
        url: "/todos/" + todoID,
        type: "DELETE"
    })
}

$(function () {
    LoadTodos();

    $('#todoForm').on('submit', function (e) {
        e.preventDefault();
        AddTodo(this).always(function () { LoadTodos(); });
    });
});