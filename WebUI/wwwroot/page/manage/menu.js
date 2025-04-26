let gModal = $("#modalMenuItem")
let gIsUpdate = false

const MAIN_MENU_FORM_ENTRIES = `
    <div class="py-1 row">
        <label class="form-label col-3 d-flex justify-content-end align-items-center">Menu name: <span class="text-danger px-1">*</span></label>
        <div class="col-8">
            <input type="text" class="form-control" name="MenuName" placeholder="Enter menu name">
        </div>
    </div>
    <div class="py-1 row">
        <label class="form-label col-3 d-flex justify-content-end align-items-center">Icon name: <span class="text-danger px-1">*</span></label>
        <div class="col-8">
            <input type="text" class="form-control" name="example-text-input" placeholder="">
        </div>
    </div>
`
const SUB_MENU_FORM_ENTRIES = `
    <div class="py-1 row">
        <label class="form-label col-3 d-flex justify-content-end align-items-center">Main menu: <span class="text-danger px-1">*</span></label>
        <div class="col-8">
            <select id="selMainMenu" class="form-control form-select"></select>
        </div>
    </div>
    <div class="py-1 row">
        <label class="form-label col-3 d-flex justify-content-end align-items-center">Menu name: <span class="text-danger px-1">*</span></label>
        <div class="col-8">
            <input type="text" class="form-control" name="MenuName" placeholder="Enter menu name">
        </div>
    </div>
`
const SUB_LEVEL_MENU_FORM_ENTRIES = `
    <div class="py-1 row">
        <label class="form-label col-3 d-flex justify-content-end align-items-center">Main menu: <span class="text-danger px-1">*</span></label>
        <div class="col-8">
            <select id="selMainMenu" class="form-control form-select"></select>
        </div>
    </div>
    <div class="py-1 row">
        <label class="form-label col-3 d-flex justify-content-end align-items-center">Sub menu: <span class="text-danger px-1">*</span></label>
        <div class="col-8">
            <select id="selSubMenu" class="form-control form-select"></select>
        </div>
    </div>
    <div class="py-1 row">
        <label class="form-label col-3 d-flex justify-content-end align-items-center">Menu name: <span class="text-danger px-1">*</span></label>
        <div class="col-8">
            <input type="text" class="form-control" name="MenuName" placeholder="Enter menu name">
        </div>
    </div>
`

$(function() {
    
})

function setTriggerEvent() {
    const formField = $(gModal).find('#menuItemFormFields');
    
    $(gModal).on("change", "#selMenuCategory", function() {
        const menuItemFormFields = getMenuItemFormFields($(this).val());
        $(formField).empty().append(menuItemFormFields)
    })
}

function getMenuItemFormFields(menuCategoryId) {
    let formFields = null
    
    switch(menuCategoryId) {
        case '1':
            formFields = MAIN_MENU_FORM_ENTRIES
            break
        case '2':
            formFields = SUB_MENU_FORM_ENTRIES
            break
        case '3':
            formFields = SUB_LEVEL_MENU_FORM_ENTRIES
            break
        default:
            formFields = ""
            break
    }
    
    console.log(formFields)
    console.log(menuCategoryId)
    console.log(typeof menuCategoryId)

    return formFields;
}

function showModalCreateMenuItem(element) {
    $(gModal).find(".modal-title").text("Create New Menu Item Entry");
    $(gModal).modal("show")
    
    setTriggerEvent()
    gIsUpdate = false
}

function cancelModal(element) {
    const form = $(element).closest("form")
    closeModal(element)
    clearEntries(form)
}

function closeModal(element) {
    $(element).closest('.modal').modal("hide");
}

function clearEntries(form) {
    $(form).find("input, select").each(function() {
        const input = $(this);
        if(input.name !== "__RequestVerificationToken") {
            if(input.is(':checked')) {
                input.prop('checked', false);
            } else if (input.is('select')) {
                input.prop('selectedIndex', 0);
            } else if (!input.is('file')) {
                input.val('');
            }
        }
    })
    
    $(form).find("textarea").val("")
}   