export class ValidatorConstants {
    static readonly v_username = '^[0-9a-z\.\_\@]{5,50}$';
    static readonly v_password = '^(?=.*[0-9])[a-zA-Z0-9!@#$%^&*]{6,20}$';
    static readonly v_fullname = '^([0-9 a-z A-Z_ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼẾỀỂưăạảấầẩẫậắằẳẵặẹẻẽếềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹý()\']){5,120}$';
    static readonly v_manv = '^([A-Za-z0-9]){1,10}$';
    static readonly v_email = '^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$';
    static readonly v_phone = '^([0-9]){9,15}$';
    static readonly v_bankaccountnumber = '^([0-9]){0,50}$';
    static readonly v_mabn = '^([0-9]){1}([0-9]){7}$';
    static readonly v_namsinh = '^([1-9]){1}([0-9]){3}$';
    static readonly v_namsinhmin = 1900;
    static readonly v_ngaysinh = '^([0-2][0-9]|(3)[0-1])(\/|\-)(((0)[0-9])|((1)[0-2]))(\/|\-)\d{4}$';
    static readonly v_cmnd = '(^([0-9]){9}$)|(^([0-9]){12}$)';
    static readonly v_gio = '^([0-1][0-9]|(2)[0-3])\:([0-5][0-9])$';

    static readonly v_ngaygio = '^([0-2][0-9]|(3)[0-1])(\/|\-)(((0)[0-9])|((1)[0-2]))(\/|\-)\d{4}\s([0-1][0-9]|(2)[0-3])\:([0-5][0-9])$';

    static readonly v_bhyt = '(^[A-Za-z]{2}[A-Za-z0-9]{13}$)|(^[0-9]{10}$)|(^[A-Za-z]{2}[A-Za-z0-9]{18}$)';
    static readonly v_huyetap = '^([0-9]){1,3}(\/)([0-9]){1,3}$';
    static readonly v_mach = '^([0-9]){1,3}$';


    static readonly v_confirmPassword = 'Xác thực mật khẩu không đúng';

    static readonly ms_required = 'Bắt buộc';
    static readonly ms_pattern = 'Không hợp lệ';
    static readonly ms_textlength = 'Độ dài chuỗi không hợp lệ';
    static readonly ms_min = 'Phải lớn hơn hoặc bằng';
    static readonly ms_max = 'Phải nhỏ hơn hoặc bằng';
    static readonly ms_mabn = '8 ký tự (0->9)';
    static readonly ms_gio = 'định dạng 00:00';
    static readonly ms_ngay = 'định dạng dd/mm/yyyy';

    public static BloodPressure = '^([0-9]){1,3}(\/)([0-9]){1,3}$';
}