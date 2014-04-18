// This is a standard solution obtained from the net. It has a downside in that it accepts both . and , as
// valid inputs, but at least it works, and server-side validation then takes care of any values inconsistent
// with CurrentCulture.

$.validator.methods.range = function (value, element, param) {
    var globalizedValue = value.replace(",", ".");
    return this.optional(element) || (globalizedValue >= param[0] && globalizedValue <= param[1]);
};

$.validator.methods.number = function (value, element) {
    return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/.test(value);
};