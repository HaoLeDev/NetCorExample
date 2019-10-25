var js_NhanVien = function () {
    return {
        init: function () {
            this.EmployeeTable();
            
        },
        //Lấy dữ liệu nhân viên theo id
        GetbyId: function (Id) {
            $("#myModal").modal('show');
            $.ajax({
                url: 'Employee/GetById/' + Id,
                type: 'get',
                success: function (data) {
                    //load dữ liệu lên modal
                    $("#EmCode").val(data.em_Code);
                    $("#FirstName").val(data.firstName);
                    $("#LastName").val(data.lastName);
                    var d = new Date(data.birthDate);
                    var ngay = d.getDate();
                    var thang = d.getMonth()+1;
                    var nam = d.getFullYear();
                    $("#BirthDate").val(ngay+'/'+thang+'/'+nam);
                    $("#Address").val(data.address);
                    $("#Phone").val(data.phone);
                    $("#IdCardNumber").val(data.identityCardNumber);
                    if (data.sex == 1) {
                        $("#Sex").val(1)
                    }
                    if (data.sex == 0)
                        $("#Sex").val(0)                   
                    $("#Status").val(data.status);
                    $('#De_Id  option[value='+data.de_Id+']').prop("selected", true);
                }
            })
        },
        Create: function () {
            var emp = {
                Em_Code: $("#EmCode").val(),
                FirstName: $("#FirstName").val(),
                LastName: $("#LastName").val(),
                BirthDate: $("#BirthDate").val(),
                Address: $("#Address").val(),
                Phone: $("#Phone").val(),
                IdentityCardNumber: $("#IdCardNumber").val(),
                Sex: $("#Sex").val(),
                Status: $("#Status").val(),
                De_Id: $("#De_Id").val(),
            }
            $.ajax({               
                type: 'post',
                url: '/Employee/Create',
                data: emp,
                success: function () {
                    $.notify(
                        {
                            message: 'Thêm mới thành công!'
                        }, {
                        type: 'success'
                    });
                    $("#myModal").modal("hide");
                    this.RefreshTable("#EmployeeTable");
                },

            });
        },
        Update: function () {
            var emp1 = {
                Em_Code: $("#EmCode").val(),
                FirstName: $("#FirstName").val(),
                LastName: $("#LastName").val(),
                BirthDate: $("#BirthDate").val(),
                Address: $("#Address").val(),
                Phone: $("#Phone").val(),
                IdentityCardNumber: $("#IdCardNumber").val(),
                Sex: $("#Sex").val(),
                Status: $("#Status").val(),
                De_Id: $("#De_Id").val(),
            }
            $.ajax({
                type: 'post',
                url: '/Employee/UpDate',
                data: emp1,
                success: function () {
                    $.notify(
                        {
                            message: 'Chỉnh sửa thành công!'
                        }, {
                        type: 'success'
                    });
                    $("#myModal").modal("hide");
                    this.RefreshTable("#EmployeeTable");
                },

            });
        },
        Delete: function (id) {
            $.ajax({
                url: 'Employee/GetById/' + id,
                type: 'post',
                success: function (result) {
                    bootbox.confirm({
                        size: "small",
                        message: "Bạn chắc chắn muốn xóa?",
                        buttons: {
                            confirm: {
                                label: '<i class="fas fa-check"></i> Có',
                                className:'btn btn-success'
                            },
                            cancel: {
                                label: '<i class="fas fa-times"></i> Không',
                                className: 'btn-danger',
                                icon:'fas fa- times'
                            }
                        },
                        callback: function (result) {
                            if (result) {
                                $.ajax({
                                    url: 'Employee/Delete/' + id,
                                    type: 'post',
                                    data: {id},
                                    success: function () {
                                        $.notify(
                                            {
                                                icon: 'glyphicon glyphicon-star',
                                                message: 'Xóa thành công!'
                                            }, {
                                            type: 'success'
                                        });
                                        
                                        RefreshTable("#EmployeeTable");
                                    }
                                });
                            }
                        }
                    });
                }
            });
        },
        Detail: function (Id) {          
            $.ajax({
                url: 'Employee/Detail/' + Id,
                type: 'get',
                success: function (result) {
                    $("#dtEmcode").val(result.em_Code);
                    $("#dtName").val(result.firstName);
                    $("#dtBirthDate").val(result.strBirthDate);
                    $("#dtAddress").val(result.address);
                    $("#dtPhone").val(result.phone);
                    $("#dtIdCardNumber").val(result.identityCardNumber);
                    $("#dtStatus").val(result.strStatus);
                    $("#dtSex").val(result.strSex);
                    $('#dtDeId').val(result.de_Name);
                    $('#dtImage').attr('src',result.image);
                }
            }); 
            //$("#PopupDetail").html('');
             $('#modalDetail').modal('show');
            //$("#PopupDetail").html(html);
        },
        EmployeeTable: function () {
            $("#EmployeeTable").DataTable({
                "bDestroy": true,
                'bSort': false,
                'searching': false,
                "sPaginationType": "full_numbers",
                "lengthMenu": [5, 10, 25, 50, 100],
                'oLanguage': {
                    'sProcessing': "Đang xử lý",
                    "sLengthMenu": 'Hiển thị _MENU_ bản ghi',
                    'sZeroRecords': 'Không tìm thấy bản ghi nào!',
                    'sInfo': 'Hiển thị _START_ tới _END_ của (_TOTAL_ bản ghi)',
                    'sInfoEmpty': 'Không tìm thấy bản ghi nào!',
                    'oPaginate': {
                        'sFirst': 'Đầu',
                        'sPrevious': 'Trước',
                        'sNext': 'Sau',
                        'sLast': 'Cuối'
                    }
                }
            });
        },
        SetDefault: function () {
            $("#EmCode").val("");
            $("#FirstName").val("");
            $("#LastName").val("");
            //$("#De_Id").val(0);
            $('#De_Id  option[value=0]').prop("selected", true);
            $("#BirthDate").val("01/01/2019");
            $("#Phone").val("");
            $("#IdCardNumber").val("");
            $("#Sex").val(0);
            $("#Address").val('');
            $("#Status").val(0);
        },
        ValidateData: function () {
            var flag = true;
            if ($("#EmCode").val() == '') {
                $("#EmCode").focus();
                flag = false;
            }
            else if ($("#FirstName").val() == '') {
                $("#FirstName").focus();
                flag = false;
            }
            else if ($("#LastName").val() == '') {
                $("#FirstName").focus();
                flag = false;
            }
            else if ($("#De_Id").val() == 0) {
                flag = false;
            }
            return flag;
        },
        RefreshTable: function (tableId) {
            table = $(tableId).DataTable();
            osetting = table.fnSettings();
            table.fnDraw();
        },
        Search: function () {
            $("#EmployeeTable").DataTable().search(
                $('.ctrlsearch').val()
            ).draw();
        }
    }
}();
$(document).ready(function () {
    js_NhanVien.init();
    $("#btnAdd").click(function () {
        js_NhanVien.SetDefault();
        $("#myModal").modal('show');
        $('#btnSaveEdit').attr('id', 'btnSave');
        $("#title").text('Thêm mới nhân viên');
    });
    $("#btnUpdate").click(function () {
        $('#btnSave').attr('id', 'btnSaveEdit');
        $("#title").text('Sửa thông tin nhân viên');
    });
    $("#btnSave").click(function () {
        if (js_NhanVien.ValidateData() == true) {
            js_NhanVien.Create();
        }
    });
    $("#btnSaveEdit").click(function () {
        debugger;
        if (js_NhanVien.ValidateData() == true) {
            js_NhanVien.Update();
        }
    });
});