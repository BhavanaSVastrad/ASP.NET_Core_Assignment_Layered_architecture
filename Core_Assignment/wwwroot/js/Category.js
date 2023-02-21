
$(document).ready(function () {

    ShowCategory();

});


//Retrieving the values from Category Table
function ShowCategory() {
    
    $.ajax({
        url: '/Category/CategoryList',
        type: 'Get',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8;',
        success: function (result, statu, xhr) {
            var object = '';
            $.each(result, function (index, item) {
                object += '<tr>';
                object += '<td>' + item.id + '</td>';
                object += '<td>' + item.category_Name + '</td>';

                object += '<td> <a href="#" class="btn btn-primary" onclick="Edit(' + item.id +');">Edit</a> <a href="#" class="btn btn-danger" onclick="Delete('+item.id+');">Delete</a></td>';
                object += '</tr>';
            });
            $('#table_data').html(object);
        },
        error: function () {
            alert("Data cant able to retrieve!");
        }
    });

    //Onclick of Add button displaying the modal popup

    $('#btnAddCategory').click(function () {
        ClearTextBox();
        $('#CategoryMadal').modal('show');
        $('#CatId').hide();
        $('#AddCategory').css('display', 'block');
        $('#btnUpdate').css('display', 'none');
        $('#CategoryHeading').text('Add Category');
       // alert('ok');
    }
    );


};
//Posting i.e inserting new category into Category table


function AddCategory() {
   
    var objData = {
        Category_Name: $('#Name').val()

    }
    $.ajax({
        url: '/Category/AddCategory',
        type: 'Post',
        data: objData,
        contentType: 'application/x-www-form-urlencoded;charset=utf-8;',
        dataType: 'json',
        success: function () {
            alert('Data Saved Successfully');
            ClearTextBox();
            ShowCategory();
            HideModalPopUp();
        },
        error: function () {
            alert('Error while inserting!');
        }
    });


    
}

//function for hiding the add category popup
function HideModalPopUp() {
    $('#CategoryMadal').modal('hide');
}

//function for clearing the text from the values after inserting category 
function ClearTextBox() {
    $('#Name').val('');

    $('#CategoryId').val('');
}

//Function for deleting category record  from Category table
function Delete(id) {

    if (confirm('Are you Sure, You want to delete this record?')) {
        $.ajax({
            url: 'Category/Delete?id=' + id,
            success: function () {
                alert('Category Deleted!');
                ShowCategory();
            },
            error: function () {
                alert('Category cant be deleted!!');
            }
        });
    }
    
}
//Function for Editing the category record  from Category table i.e retriving the category record
function Edit(id) {
    
    $.ajax({
        url: 'Category/Edit?id=' + id,
        type: 'Get',
       
        contentType: 'application/json;charset=utf-8;',
        dataType: 'json',

        success: function (response) {

            $('#CategoryMadal').modal('show');
            $('#CategoryId').val(response.id);
            $('#Name').val(response.category_Name);

            $('#AddCategory').css('display','none');
            $('#btnUpdate').css('display', 'block');

            $('#CategoryHeading').text('Update Record');


        },
        error: function () {
            alert('Category cannot found!');
        }
    });
}

//Function for Updating category record  into Category table
function UpdateCategory() {
    
    var objData = {
        id: $('#CategoryId').val(),
        Category_Name: $('#Name').val()

    }
    $.ajax({
        url: '/Category/Update',
        type: 'Post',
        data: objData,
        contentType: 'application/x-www-form-urlencoded;charset=utf-8;',
        dataType: 'json',
        success: function () {
            alert('Data Saved Successfully');
            ClearTextBox();
            ShowCategory();
            HideModalPopUp();
        },
        error: function () {
            alert('Error while Updating!');
        }
    });
}