<template>
    <div id="ownAppiPanel" class="ownAppi_content panel_right">
        <form @submit.prevent="validateFields('n')" data-vv-scope="n">
            <div class="row pl-5 pr-5">
                <div class="col-md-12 pb-2 pt-2">
                    <button ref="closeBtn" @click="changeVisibility(0,false)" type="button" class="close" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="col-md-12">
                    <h1 class="panel_right_h1">TOP nabídky</h1>
                </div>
                <div class="col-md-12 pb-2">
                    <p class="under_title">Zobrazí na webu vlastní jedinečnou nabídku, událost nebo akci.</p>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="title_sidebar_set_new_campaign pl-5 pr-5 pb-3 pt-3" style="color:#666666">
                        Aktivujte jednu nebo více nabídek:
                    </div>
                </div>
            </div>
            <div class="col-md-12 pl-5 py-3 form_inline_set">
                <div>Vyberte</div>&nbsp;&nbsp;
                <div class="btn-group btn-group-toggle" data-toggle="buttons">
                    <label style="padding-right: 0.4rem;" class="btn btn btn-outline-primary mycolor" :class="{active: ownAppiSelectedVariant == 1, 'is-invalid': errors.has('n.OwnAppi1Name') || errors.has('OwnAppi1Name')}" v-on:click="changeVisibility(0,false);changeOwnAppiSelectedVariant(1);">
                        <input type="radio" name="options" autocomplete="off" :checked="ownAppiSelectedVariant == 1"> {{OwnAppi1Name}}
                        <span class="fas fa-pencil-alt" style="margin: 0px;margin-left: 7px;" @click="changeVisibility(1,visibility1)"
                              v-tooltip.bottom.notrigger="{class: 'v-tooltip_ownAppi', html:'name_1', visible: visibility1}"></span>
                        <span v-bind:id="'name_1'" class="text-left" style="left:-120px;" v-click-outside="onClickOutside1">
                            <div class="width_100 text-left tooltip_label" style="padding-top: 0px;">Zadejte název:</div>
                            <input type="text" placeholder="Nabídka 1" v-model="OwnAppi1Name" v-on:input="validateFields" v-validate="{required: true, min: 1, max: 10}" name="OwnAppi1Name" class="form-control form_control_set_width_2" :class="{ 'is-invalid': errors.has('n.OwnAppi1Name') || errors.has('OwnAppi1Name') }" />
                            <span v-if="errors.has('n.OwnAppi1Name') || errors.has('OwnAppi1Name')" class="d-flex invalid-feedback ">{{ errors.first('n.OwnAppi1Name') }}{{ errors.first('OwnAppi1Name') }}</span>
                        </span>
                    </label>
                    <label style="padding-right: 0.4rem;" class="btn btn btn-outline-primary mycolor" :class="{active: ownAppiSelectedVariant == 2, 'is-invalid': errors.has('n.OwnAppi2Name') || errors.has('OwnAppi2Name')}" v-on:click="changeVisibility(0,false);changeOwnAppiSelectedVariant(2);">
                        <input type="radio" name="options" autocomplete="off" :checked="ownAppiSelectedVariant == 2"> {{OwnAppi2Name}}
                        <span class="fas fa-pencil-alt" style="margin: 0px;margin-left: 7px;" @click="changeVisibility(2,visibility2)"
                              v-tooltip.bottom.notrigger="{class: 'v-tooltip_ownAppi', html:'name_2', visible: visibility2}"></span>
                        <span v-bind:id="'name_2'" class="text-left" style="left:-120px;" v-click-outside="onClickOutside2">
                            <div class="width_100 text-left tooltip_label" style="padding-top: 0px;">Zadejte název:</div>
                            <input type="text" placeholder="Nabídka 2" v-model="OwnAppi2Name" v-on:input="validateFields" v-validate="{required: true, min: 1, max: 10}" name="OwnAppi2Name" class="form-control form_control_set_width_2" :class="{ 'is-invalid': errors.has('n.OwnAppi2Name') || errors.has('OwnAppi2Name') }" />
                            <span v-if="errors.has('n.OwnAppi2Name') || errors.has('OwnAppi2Name')" class="d-flex invalid-feedback ">{{ errors.first('n.OwnAppi2Name') }}{{ errors.first('OwnAppi2Name') }}</span>
                        </span>
                    </label>
                    <label style="padding-right: 0.4rem;" class="btn btn btn-outline-primary mycolor" :class="{active: ownAppiSelectedVariant == 3, 'is-invalid': errors.has('n.OwnAppi3Name') || errors.has('OwnAppi3Name')}" v-on:click="changeVisibility(0,false);changeOwnAppiSelectedVariant(3);">
                        <input type="radio" name="options" autocomplete="off" :checked="ownAppiSelectedVariant == 3"> {{OwnAppi3Name}}
                        <span class="fas fa-pencil-alt" style="margin: 0px;margin-left: 7px;" @click="changeVisibility(3,visibility3)"
                              v-tooltip.bottom.notrigger="{class: 'v-tooltip_ownAppi', html:'name_3', visible: visibility3}"></span>
                        <span v-bind:id="'name_3'" class="text-left" style="left:-120px;" v-click-outside="onClickOutside3">
                            <div class="width_100 text-left tooltip_label" style="padding-top: 0px;">Zadejte název:</div>
                            <input type="text" placeholder="Nabídka 3" v-model="OwnAppi3Name" v-on:input="validateFields" v-validate="{required: true, min: 1, max: 10}" name="OwnAppi3Name" class="form-control form_control_set_width_2" :class="{ 'is-invalid': errors.has('n.OwnAppi3Name') || errors.has('OwnAppi3Name') }" />
                            <span v-if="errors.has('n.OwnAppi3Name') || errors.has('OwnAppi3Name')" class="d-flex invalid-feedback ">{{ errors.first('n.OwnAppi3Name') }}{{ errors.first('OwnAppi3Name') }}</span>
                        </span>
                    </label>
                    <label style="padding-right: 0.4rem;" class="btn btn btn-outline-primary mycolor" :class="{active: ownAppiSelectedVariant == 4, 'is-invalid': errors.has('n.OwnAppi4Name') || errors.has('OwnAppi4Name')}" v-on:click="changeVisibility(0,false);changeOwnAppiSelectedVariant(4);">
                        <input type="radio" name="options" autocomplete="off" :checked="ownAppiSelectedVariant == 4"> {{OwnAppi4Name}}
                        <span class="fas fa-pencil-alt" style="margin: 0px;margin-left: 7px;" @click="changeVisibility(4,visibility4)"
                              v-tooltip.bottom.notrigger="{class: 'v-tooltip_ownAppi', html:'name_4', visible: visibility4}"></span>
                        <span v-bind:id="'name_4'" class="text-left" style="left:-120px;" v-click-outside="onClickOutside4">
                            <div class="width_100 text-left tooltip_label" style="padding-top: 0px;">Zadejte název:</div>
                            <input type="text" placeholder="Nabídka 4" v-model="OwnAppi4Name" v-on:input="validateFields" v-validate="{required:true, min: 1, max: 10}" name="OwnAppi4Name" class="form-control form_control_set_width_2" :class="{ 'is-invalid': errors.has('n.OwnAppi4Name') || errors.has('OwnAppi4Name') }" />
                            <span v-if="errors.has('n.OwnAppi4Name') || errors.has('OwnAppi4Name')" class="d-flex invalid-feedback ">{{ errors.first('n.OwnAppi4Name') }}{{ errors.first('OwnAppi4Name') }}</span>
                        </span>
                    </label>
                    <label style="padding-right: 0.4rem;" class="btn btn btn-outline-primary mycolor" :class="{active: ownAppiSelectedVariant == 5, 'is-invalid': errors.has('n.OwnAppi5Name') || errors.has('OwnAppi5Name')}" v-on:click="changeVisibility(0,false);changeOwnAppiSelectedVariant(5);">
                        <input type="radio" name="options" autocomplete="off" :checked="ownAppiSelectedVariant == 5"> {{OwnAppi5Name}}
                        <span class="fas fa-pencil-alt" style="margin: 0px;margin-left: 7px;" @click="changeVisibility(5,visibility5)"
                              v-tooltip.bottom.notrigger="{class: 'v-tooltip_ownAppi', html:'name_5', visible: visibility5}"></span>
                        <span v-bind:id="'name_5'" class="text-left" style="left:-120px;" v-click-outside="onClickOutside5">
                            <div class="width_100 text-left tooltip_label" style="padding-top: 0px;">Zadejte název:</div>
                            <input type="text" placeholder="Nabídka 5" v-model="OwnAppi5Name" v-on:input="validateFields" v-validate="{required:true, min: 1, max: 10}" name="OwnAppi5Name" class="form-control form_control_set_width_2" :class="{ 'is-invalid': errors.has('n.OwnAppi5Name') || errors.has('OwnAppi5Name') }" />
                            <span v-if="errors.has('n.OwnAppi5Name') || errors.has('OwnAppi5Name')" class="d-flex invalid-feedback ">{{ errors.first('n.OwnAppi5Name') }}{{ errors.first('OwnAppi5Name') }}</span>
                        </span>
                    </label>
                </div>

            </div>
            <div class="col-md-12 pl-5 py-3 form_inline_set">
                <div class="pr-3">
                    Notifikace je aktivní
                </div>
                <div class="noselect">
                    <span class="toogle_desc">NE</span>&nbsp;&nbsp;
                    <button type="button" v-bind:id="'ownAppiBtnActive'+ownAppiSelectedVariant" class="btn btn-toggle" :key="ownAppiBtnActive" v-bind:class="ownAppiBtnActive" v-on:click="ShowLinkChange('Appi',ownAppiSelectedVariant)" data-toggle="button" aria-pressed="false" autocomplete="off"><div class="handle"></div></button>
                    &nbsp;&nbsp;<span class="toogle_desc">ANO</span>
                </div>
            </div>

            <div class="row d-block">
                <div class="col-md-12" id="ownAppiBubble">
                    <div class="notifikace">
                        <div class="Appi_bubble_400 shadow noselect">
                            <span class="ownAppiCircle" v-bind:style="{'border-color': (ownAppiSelectedVariant == 1)?Iconcolor1.hex:(ownAppiSelectedVariant == 2)?Iconcolor2.hex:(ownAppiSelectedVariant == 3)?Iconcolor3.hex:(ownAppiSelectedVariant == 4)?Iconcolor4.hex:Iconcolor5.hex}" title="TOP nabídky" alt="TOP nabídky"></span>
                            <span class="ownNotitifyIconCenter" v-bind:style="{'padding-left': horizontalIcon[(ownAppiSelectedVariant-1)]+'px','padding-top': verticalIcon[(ownAppiSelectedVariant-1)]+'px'}">

                                <Information-icon id="Information" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon =='Information') || (ownAppiSelectedVariant == 2 && OwnAppi2Icon =='Information') || (ownAppiSelectedVariant == 3 && OwnAppi3Icon =='Information') || (ownAppiSelectedVariant == 4 && OwnAppi4Icon =='Information') || (ownAppiSelectedVariant == 5 && OwnAppi5Icon =='Information'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></Information-icon>
                                <BellOutline-icon id="BellOutline" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'BellOutline') || (ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'BellOutline') || (ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'BellOutline') || (ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'BellOutline') || (ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'BellOutline'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></BellOutline-icon>
                                <BellRingOutline-icon id="BellRingOutline" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'BellRingOutline') || (ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'BellRingOutline') || (ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'BellRingOutline') || (ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'BellRingOutline') || (ownAppiSelectedVariant == 2 && OwnAppi5Icon == 'BellRingOutline'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></BellRingOutline-icon>
                                <Sale-icon id="Sale" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Sale')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Sale')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Sale')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Sale')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Sale'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></Sale-icon>
                                <Truck-icon id="Truck" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Truck')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Truck')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Truck')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Truck')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Truck'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></Truck-icon>
                                <TagHeart-icon id="TagHeart" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'TagHeart')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'TagHeart')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'TagHeart')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'TagHeart')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'TagHeart'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></TagHeart-icon>
                                <TooltipAccount-icon id="TooltipAccount" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'TooltipAccount')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'TooltipAccount')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'TooltipAccount')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'TooltipAccount')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'TooltipAccount'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></TooltipAccount-icon>
                                <AccountPlusOutline-icon id="AccountPlusOutline" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'AccountPlusOutline')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'AccountPlusOutline')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'AccountPlusOutline')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'AccountPlusOutline')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'AccountPlusOutline'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></AccountPlusOutline-icon>
                                <StarOutline-icon id="StarOutline" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'StarOutline')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'StarOutline')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'StarOutline')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'StarOutline')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'StarOutline'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></StarOutline-icon>
                                <WalletGiftcard-icon id="WalletGiftcard" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'WalletGiftcard')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'WalletGiftcard')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'WalletGiftcard')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'WalletGiftcard')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'WalletGiftcard'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></WalletGiftcard-icon>
                                <GestureTap-icon id="GestureTap" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'GestureTap')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'GestureTap')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'GestureTap')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'GestureTap')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'GestureTap'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></GestureTap-icon>
                                <Ticket-icon id="Ticket" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Ticket')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Ticket')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Ticket')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Ticket')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Ticket'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></Ticket-icon>
                                <EyeOutline-icon id="EyeOutline" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'EyeOutline')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'EyeOutline')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'EyeOutline')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'EyeOutline')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'EyeOutline'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></EyeOutline-icon>
                                <ThumbUpOutline-icon id="ThumbUpOutline" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'ThumbUpOutline')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'ThumbUpOutline')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'ThumbUpOutline')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'ThumbUpOutline')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'ThumbUpOutline'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></ThumbUpOutline-icon>
                                <AlertCircle-icon id="AlertCircle" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'AlertCircle')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'AlertCircle')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'AlertCircle')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'AlertCircle')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'AlertCircle'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></AlertCircle-icon>
                                <MessageText-icon id="MessageText" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'MessageText')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'MessageText')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'MessageText')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'MessageText')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'MessageText'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></MessageText-icon>
                                <EmailOutline-icon id="EmailOutline" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'EmailOutline')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'EmailOutline')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'EmailOutline')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'EmailOutline')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'EmailOutline'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></EmailOutline-icon>
                                <LightbulbOnOutline-icon id="LightbulbOnOutline" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'LightbulbOnOutline')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'LightbulbOnOutline')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'LightbulbOnOutline')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'LightbulbOnOutline')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'LightbulbOnOutline'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></LightbulbOnOutline-icon>
                                <CakeVariant-icon id="CakeVariant" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'CakeVariant')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'CakeVariant')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'CakeVariant')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'CakeVariant')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'CakeVariant'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></CakeVariant-icon>
                                <Facebook-icon id="Facebook" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Facebook')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Facebook')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Facebook')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Facebook')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Facebook'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></Facebook-icon>
                                <FacebookBox-icon id="FacebookBox" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'FacebookBox')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'FacebookBox')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'FacebookBox')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'FacebookBox')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'FacebookBox'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></FacebookBox-icon>
                                <FacebookMessenger-icon id="FacebookMessenger" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'FacebookMessenger')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'FacebookMessenger')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'FacebookMessenger')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'FacebookMessenger')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'FacebookMessenger'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></FacebookMessenger-icon>
                                <GooglePlusBox-icon id="GooglePlusBox" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'GooglePlusBox')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'GooglePlusBox')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'GooglePlusBox')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'GooglePlusBox')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'GooglePlusBox'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></GooglePlusBox-icon>
                                <LinkedinBox-icon id="LinkedinBox" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'LinkedinBox')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'LinkedinBox')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'LinkedinBox')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'LinkedinBox')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'LinkedinBox'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></LinkedinBox-icon>
                                <TwitterBox-icon id="TwitterBox" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'TwitterBox')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'TwitterBox')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'TwitterBox')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'TwitterBox')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'TwitterBox'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></TwitterBox-icon>
                                <Youtube-icon id="Youtube" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Youtube')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Youtube')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Youtube')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Youtube')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Youtube'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></Youtube-icon>
                                <Instagram-icon id="Instagram" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Instagram')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Instagram')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Instagram')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Instagram')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Instagram'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></Instagram-icon>
                                <FoodForkDrink-icon id="FoodForkDrink" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'FoodForkDrink')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'FoodForkDrink')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'FoodForkDrink')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'FoodForkDrink')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'FoodForkDrink'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></FoodForkDrink-icon>
                                <EmoticonHappyOutline-icon id="EmoticonHappyOutline" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'EmoticonHappyOutline')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'EmoticonHappyOutline')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'EmoticonHappyOutline')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'EmoticonHappyOutline')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'EmoticonHappyOutline'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></EmoticonHappyOutline-icon>
                                <Emoticon-icon id="Emoticon" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Emoticon')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Emoticon')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Emoticon')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Emoticon')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Emoticon'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></Emoticon-icon>
                                <EmoticonOutline-icon id="EmoticonOutline" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'EmoticonOutline')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'EmoticonOutline')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'EmoticonOutline')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'EmoticonOutline')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'EmoticonOutline'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></EmoticonOutline-icon>
                                <Cupcake-icon id="Cupcake" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Cupcake')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Cupcake')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Cupcake')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Cupcake')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Cupcake'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></Cupcake-icon>
                                <CheckboxMarkedCircle-icon id="CheckboxMarkedCircle" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'CheckboxMarkedCircle')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'CheckboxMarkedCircle')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'CheckboxMarkedCircle')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'CheckboxMarkedCircle')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'CheckboxMarkedCircle'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></CheckboxMarkedCircle-icon>
                                <GlassWine-icon id="GlassWine" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'GlassWine')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'GlassWine')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'GlassWine')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'GlassWine')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'GlassWine'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></GlassWine-icon>
                                <ArrowRightCircle-icon id="ArrowRightCircle" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'ArrowRightCircle')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'ArrowRightCircle')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'ArrowRightCircle')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'ArrowRightCircle')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'ArrowRightCircle'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></ArrowRightCircle-icon>
                                <ArrowRightCircleOutline-icon id="ArrowRightCircleOutline" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'ArrowRightCircleOutline')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'ArrowRightCircleOutline')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'ArrowRightCircleOutline')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'ArrowRightCircleOutline')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'ArrowRightCircleOutline'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></ArrowRightCircleOutline-icon>
                                <ChevronDoubleRight-icon id="ChevronDoubleRight" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'ChevronDoubleRight')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'ChevronDoubleRight')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'ChevronDoubleRight')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'ChevronDoubleRight')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'ChevronDoubleRight'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></ChevronDoubleRight-icon>
                                <GlassMugVariant-icon id="GlassMugVariant" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'GlassMugVariant')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'GlassMugVariant')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'GlassMugVariant')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'GlassMugVariant')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'GlassMugVariant'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></GlassMugVariant-icon>
                                <ChevronRightCircle-icon id="ChevronRightCircle" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'ChevronRightCircle')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'ChevronRightCircle')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'ChevronRightCircle')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'ChevronRightCircle')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'ChevronRightCircle'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></ChevronRightCircle-icon>
                                <BagChecked-icon id="BagChecked" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'BagChecked')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'BagChecked')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'BagChecked')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'BagChecked')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'BagChecked'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></BagChecked-icon>
                                <Heart-icon id="Heart" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Heart')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Heart')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Heart')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Heart')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Heart'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></Heart-icon>
                                <HeartOutline-icon id="HeartOutline" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'HeartOutline')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'HeartOutline')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'HeartOutline')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'HeartOutline')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'HeartOutline'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></HeartOutline-icon>
                                <ChatAlert-icon id="ChatAlert" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'ChatAlert')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'ChatAlert')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'ChatAlert')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'ChatAlert')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'ChatAlert'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></ChatAlert-icon>
                                <CommentAlert-icon id="CommentAlert" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'CommentAlert')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'CommentAlert')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'CommentAlert')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'CommentAlert')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'CommentAlert'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></CommentAlert-icon>
                                <TooltipText-icon id="TooltipText" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'TooltipText')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'TooltipText')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'TooltipText')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'TooltipText')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'TooltipText'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></TooltipText-icon>
                                <CarHatchback-icon id="CarHatchback" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'CarHatchback')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'CarHatchback')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'CarHatchback')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'CarHatchback')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'CarHatchback'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></CarHatchback-icon>
                                <AvTimer-icon id="AvTimer" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'AvTimer')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'AvTimer')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'AvTimer')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'AvTimer')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'AvTimer'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></AvTimer-icon>
                                <ClockFast-icon id="ClockFast" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'ClockFast')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'ClockFast')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'ClockFast')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'ClockFast')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'ClockFast'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></ClockFast-icon>
                                <TimerSand-icon id="TimerSand" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'TimerSand')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'TimerSand')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'TimerSand')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'TimerSand')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'TimerSand'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></TimerSand-icon>
                                <Bike-icon id="Bike" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Bike')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Bike')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Bike')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Bike')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Bike'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></Bike-icon>
                                <Brain-icon id="Brain" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Brain')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Brain')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Brain')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Brain')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Brain'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></Brain-icon>
                                <Face-icon id="Face" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Face')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Face')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Face')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Face')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Face'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></Face-icon>
                                <FaceWoman-icon id="FaceWoman" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'FaceWoman')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'FaceWoman')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'FaceWoman')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'FaceWoman')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'FaceWoman'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></FaceWoman-icon>
                                <GiftOutline-icon id="GiftOutline" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'GiftOutline')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'GiftOutline')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'GiftOutline')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'GiftOutline')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'GiftOutline'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></GiftOutline-icon>
                                <BabyCarriage-icon id="BabyCarriage" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'BabyCarriage')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'BabyCarriage')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'BabyCarriage')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'BabyCarriage')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'BabyCarriage'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></BabyCarriage-icon>
                                <Bone-icon id="Bone" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Bone')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Bone')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Bone')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Bone')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Bone'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></Bone-icon>
                                <Paw-icon id="Paw" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Paw')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Paw')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Paw')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Paw')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Paw'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></Paw-icon>
                                <Flower-icon id="Flower" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Flower')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Flower')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Flower')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Flower')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Flower'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></Flower-icon>
                                <Sprout-icon id="Sprout" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Sprout')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Sprout')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Sprout')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Sprout')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Sprout'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></Sprout-icon>
                                <ArmFlexOutline-icon id="ArmFlexOutline" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'ArmFlexOutline')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'ArmFlexOutline')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'ArmFlexOutline')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'ArmFlexOutline')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'ArmFlexOutline'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></ArmFlexOutline-icon>
                                <MonitorCellphone-icon id="MonitorCellphone" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'MonitorCellphone')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'MonitorCellphone')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'MonitorCellphone')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'MonitorCellphone')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'MonitorCellphone'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></MonitorCellphone-icon>
                                <CellphoneBasic-icon id="CellphoneBasic" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'CellphoneBasic')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'CellphoneBasic')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'CellphoneBasic')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'CellphoneBasic')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'CellphoneBasic'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></CellphoneBasic-icon>
                                <ChatProcessing-icon id="ChatProcessing" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'ChatProcessing')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'ChatProcessing')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'ChatProcessing')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'ChatProcessing')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'ChatProcessing'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></ChatProcessing-icon>
                                <CameraWirelessOutline-icon id="CameraWirelessOutline" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'CameraWirelessOutline')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'CameraWirelessOutline')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'CameraWirelessOutline')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'CameraWirelessOutline')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'CameraWirelessOutline'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></CameraWirelessOutline-icon>
                                <ChefHat-icon id="ChefHat" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'ChefHat')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'ChefHat')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'ChefHat')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'ChefHat')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'ChefHat'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></ChefHat-icon>
                                <Crown-icon id="Crown" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Crown')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Crown')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Crown')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Crown')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Crown'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></Crown-icon>
                                <DominoMask-icon id="DominoMask" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'DominoMask')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'DominoMask')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'DominoMask')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'DominoMask')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'DominoMask'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></DominoMask-icon>
                                <Ring-icon id="Ring" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Ring')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Ring')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Ring')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Ring')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Ring'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></Ring-icon>
                                <ShoeHeel-icon id="ShoeHeel" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'ShoeHeel')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'ShoeHeel')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'ShoeHeel')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'ShoeHeel')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'ShoeHeel'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></ShoeHeel-icon>
                                <TshirtCrewOutline-icon id="TshirtCrewOutline" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'TshirtCrewOutline')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'TshirtCrewOutline')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'TshirtCrewOutline')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'TshirtCrewOutline')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'TshirtCrewOutline'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></TshirtCrewOutline-icon>
                                <Cash100-icon id="Cash100" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Cash100')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Cash100')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Cash100')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Cash100')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Cash100'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></Cash100-icon>
                                <PigVariant-icon id="PigVariant" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'PigVariant')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'PigVariant')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'PigVariant')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'PigVariant')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'PigVariant'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></PigVariant-icon>
                                <Anchor-icon id="Anchor" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Anchor')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Anchor')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Anchor')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Anchor')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Anchor'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></Anchor-icon>
                                <Charity-icon id="Charity" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Charity')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Charity')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Charity')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Charity')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Charity'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></Charity-icon>
                                <Lifebuoy-icon id="Lifebuoy" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Lifebuoy')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Lifebuoy')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Lifebuoy')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Lifebuoy')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Lifebuoy'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></Lifebuoy-icon>
                                <HeartPulse-icon id="HeartPulse" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'HeartPulse')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'HeartPulse')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'HeartPulse')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'HeartPulse')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'HeartPulse'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></HeartPulse-icon>
                                <MedicalBag-icon id="MedicalBag" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'MedicalBag')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'MedicalBag')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'MedicalBag')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'MedicalBag')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'MedicalBag'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></MedicalBag-icon>
                                <Fire-icon id="Fire" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Fire')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Fire')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Fire')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Fire')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Fire'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></Fire-icon>
                                <Smoking-icon id="Smoking" v-if="((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Smoking')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Smoking')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Smoking')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Smoking')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Smoking'))" v-bind:width=zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=zoomIcon[(ownAppiSelectedVariant-1)]></Smoking-icon>

                            </span>

                            <span id="messageData" style="vertical-align: top;padding-left: 30px;margin-top: 0px;font-size: 15px;min-height: 68px;min-width: 303px;max-height: 68px;max-width: 303px;">
                                <span class="width_100" style="vertical-align: top;" v-html="editorContent[(ownAppiSelectedVariant-1)].split('<p>').join('<div>').split('</p>').join('</div>')">
                                </span>

                                <div v-if="ShowLink[(ownAppiSelectedVariant - 1)] && !ShowLinkBtn[(ownAppiSelectedVariant - 1)]">
                                    <a class="bubbleLink" v-bind:href="targetUrl[(ownAppiSelectedVariant-1)]" v-bind:style="{'color': (ownAppiSelectedVariant == 1)?IconcolorBtn1.hex:(ownAppiSelectedVariant == 2)?IconcolorBtn2.hex:(ownAppiSelectedVariant == 3)?IconcolorBtn3.hex:(ownAppiSelectedVariant == 4)?IconcolorBtn4.hex:IconcolorBtn5.hex,}"
                                       v-bind:target="(ShowLinkNewWin[(ownAppiSelectedVariant - 1)])?'_blank':'_self'">{{linkDescription[(ownAppiSelectedVariant-1)]}}</a>
                                </div>
                                <button id="bubbleLinkButton" v-on:click="openWindow(targetUrl[(ownAppiSelectedVariant-1)],ownAppiSelectedVariant)" v-if="ShowLink[(ownAppiSelectedVariant - 1)] && ShowLinkBtn[(ownAppiSelectedVariant - 1)]"
                                        class="btn btn-outline-link btn_link_new" v-bind:style="{'color': (ownAppiSelectedVariant == 1)?IconcolorBtn1.hex:(ownAppiSelectedVariant == 2)?IconcolorBtn2.hex:(ownAppiSelectedVariant == 3)?IconcolorBtn3.hex:(ownAppiSelectedVariant == 4)?IconcolorBtn4.hex:IconcolorBtn5.hex,
                                        'border-color': (ownAppiSelectedVariant == 1)?(IconcolorBtn1.hex.toLowerCase() == '#ffffff')?IconcolorBckBtn1.hex:IconcolorBtn1.hex:(ownAppiSelectedVariant == 2)?(IconcolorBtn2.hex.toLowerCase() == '#ffffff')?IconcolorBckBtn2.hex:IconcolorBtn2.hex:(ownAppiSelectedVariant == 3)?(IconcolorBtn3.hex.toLowerCase() == '#ffffff')?IconcolorBckBtn3.hex:IconcolorBtn3.hex:(ownAppiSelectedVariant == 4)?(IconcolorBtn4.hex.toLowerCase() == '#ffffff')?IconcolorBckBtn4.hex:IconcolorBtn4.hex:(IconcolorBtn5.hex.toLowerCase() == '#ffffff')?IconcolorBckBtn5.hex:IconcolorBtn5.hex,
                                        'background-color': (ownAppiSelectedVariant == 1)?IconcolorBckBtn1.hex:(ownAppiSelectedVariant == 2)?IconcolorBckBtn2.hex:(ownAppiSelectedVariant == 3)?IconcolorBckBtn3.hex:(ownAppiSelectedVariant == 4)?IconcolorBckBtn4.hex:IconcolorBckBtn5.hex}"
                                        @mouseover="mouseOverChange(ownAppiSelectedVariant,'on')"
                                        @mouseleave="mouseOverChange(ownAppiSelectedVariant,'out')"
                                        style="margin-top: 3px;padding: 0rem 1.2rem 0rem 1.2rem;font-size: 15px;">
                                    {{linkDescription[(ownAppiSelectedVariant-1)]}}
                                </button>
                            </span>
                            <div class="width_100 text-right" style="right: 125px;line-height: 11px;bottom: -67px;position: relative;min-width: 100px;height: 10px;">
                                <span class="Appi_bubble_check_gray"></span>
                                <span class="Appi_bubble_text_gray">app</span>
                            </div>
                        </div>
                        <span style="position: absolute;">
                            <img src="/images/product/liveview.png" style="filter: grayscale(100%);position: relative;min-width: 210px;" />
                        </span>
                    </div>
                </div>
            </div>
            <div class="row pl-5 pr-5">
                <div class="col-md-12 py-3">
                    <div style="font-size:30px">DETAILNÍ NASTAVENÍ</div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="title_sidebar_set_new_campaign pl-5 pr-5 pb-3 pt-3">
                        Obsah notifikace
                    </div>
                </div>
            </div>

            <div class="row pl-5 pr-5">
                <div id="selectIconOption" class="col-md-12 py-3 form_inline_set">
                    <div class="col-md-3" style="height:130px;top: 0px;">Vyberte ikonu</div>
                    <div class="col-md-9 d-block" style="overflow-y:scroll;height: 130px;">
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon =='Information') || (ownAppiSelectedVariant == 2 && OwnAppi2Icon =='Information') || (ownAppiSelectedVariant == 3 && OwnAppi3Icon =='Information') || (ownAppiSelectedVariant == 4 && OwnAppi4Icon =='Information') || (ownAppiSelectedVariant == 5 && OwnAppi5Icon =='Information'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'Information')"><Information-icon id="infIco" width="40" height="40"></Information-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'BellOutline') || (ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'BellOutline') || (ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'BellOutline') || (ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'BellOutline') || (ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'BellOutline'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'BellOutline')"><BellOutline-icon id="bellIco" width="40" height="40"></BellOutline-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'BellRingOutline') || (ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'BellRingOutline') || (ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'BellRingOutline') || (ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'BellRingOutline') || (ownAppiSelectedVariant == 2 && OwnAppi5Icon == 'BellRingOutline'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'BellRingOutline')"><BellRingOutline-icon id="bellRIco" width="40" height="40"></BellRingOutline-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Sale')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Sale')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Sale')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Sale')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Sale'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'Sale')"><Sale-icon id="saleIco" width="40" height="40"></Sale-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Truck')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Truck')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Truck')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Truck')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Truck'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'Truck')"><Truck-icon id="truckIco" width="40" height="40"></Truck-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'TagHeart')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'TagHeart')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'TagHeart')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'TagHeart')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'TagHeart'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'TagHeart')"><TagHeart-icon id="tagIco" width="40" height="40"></TagHeart-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'TooltipAccount')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'TooltipAccount')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'TooltipAccount')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'TooltipAccount')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'TooltipAccount'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'TooltipAccount')"><TooltipAccount-icon id="toolIco" width="40" height="40"></TooltipAccount-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'AccountPlusOutline')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'AccountPlusOutline')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'AccountPlusOutline')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'AccountPlusOutline')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'AccountPlusOutline'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'AccountPlusOutline')"><AccountPlusOutline-icon id="acountIco" width="40" height="40"></AccountPlusOutline-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'StarOutline')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'StarOutline')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'StarOutline')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'StarOutline')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'StarOutline'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'StarOutline')"><StarOutline-icon id="starIco" width="40" height="40"></StarOutline-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'WalletGiftcard')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'WalletGiftcard')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'WalletGiftcard')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'WalletGiftcard')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'WalletGiftcard'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'WalletGiftcard')"><WalletGiftcard-icon id="wallIco" width="40" height="40"></WalletGiftcard-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'GestureTap')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'GestureTap')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'GestureTap')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'GestureTap')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'GestureTap'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'GestureTap')"><GestureTap-icon id="gestIco" width="40" height="40"></GestureTap-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Ticket')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Ticket')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Ticket')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Ticket')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Ticket'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'Ticket')"><Ticket-icon id="ticketIco" width="40" height="40"></Ticket-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'EyeOutline')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'EyeOutline')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'EyeOutline')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'EyeOutline')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'EyeOutline'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'EyeOutline')"><EyeOutline-icon id="eyeIco" width="40" height="40"></EyeOutline-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'ThumbUpOutline')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'ThumbUpOutline')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'ThumbUpOutline')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'ThumbUpOutline')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'ThumbUpOutline'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'ThumbUpOutline')"><ThumbUpOutline-icon id="thumbIco" width="40" height="40"></ThumbUpOutline-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'AlertCircle')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'AlertCircle')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'AlertCircle')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'AlertCircle')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'AlertCircle'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'AlertCircle')"><AlertCircle-icon id="alertIco" width="40" height="40"></AlertCircle-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'MessageText')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'MessageText')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'MessageText')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'MessageText')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'MessageText'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'MessageText')"><MessageText-icon id="messIco" width="40" height="40"></MessageText-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'EmailOutline')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'EmailOutline')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'EmailOutline')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'EmailOutline')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'EmailOutline'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'EmailOutline')"><EmailOutline-icon id="emailIco" width="40" height="40"></EmailOutline-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'LightbulbOnOutline')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'LightbulbOnOutline')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'LightbulbOnOutline')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'LightbulbOnOutline')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'LightbulbOnOutline'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'LightbulbOnOutline')"><LightbulbOnOutline-icon id="lightIco" width="40" height="40"></LightbulbOnOutline-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'CakeVariant')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'CakeVariant')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'CakeVariant')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'CakeVariant')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'CakeVariant'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'CakeVariant')"><CakeVariant-icon id="cakeIco" width="40" height="40"></CakeVariant-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Facebook')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Facebook')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Facebook')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Facebook')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Facebook'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'Facebook')"><Facebook-icon id="faceIco" width="40" height="40"></Facebook-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'FacebookBox')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'FacebookBox')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'FacebookBox')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'FacebookBox')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'FacebookBox'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'FacebookBox')"><FacebookBox-icon id="faceBoxIco" width="40" height="40"></FacebookBox-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'FacebookMessenger')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'FacebookMessenger')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'FacebookMessenger')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'FacebookMessenger')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'FacebookMessenger'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'FacebookMessenger')"><FacebookMessenger-icon id="faceMessIco" width="40" height="40"></FacebookMessenger-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'GooglePlusBox')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'GooglePlusBox')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'GooglePlusBox')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'GooglePlusBox')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'GooglePlusBox'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'GooglePlusBox')"><GooglePlusBox-icon id="gooPlusIco" width="40" height="40"></GooglePlusBox-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'LinkedinBox')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'LinkedinBox')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'LinkedinBox')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'LinkedinBox')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'LinkedinBox'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'LinkedinBox')"><LinkedinBox-icon id="linkedIco" width="40" height="40"></LinkedinBox-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'TwitterBox')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'TwitterBox')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'TwitterBox')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'TwitterBox')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'TwitterBox'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'TwitterBox')"><TwitterBox-icon id="twitIco" width="40" height="40"></TwitterBox-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Youtube')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Youtube')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Youtube')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Youtube')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Youtube'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'Youtube')"><Youtube-icon id="youtIco" width="40" height="40"></Youtube-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Instagram')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Instagram')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Instagram')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Instagram')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Instagram'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'Instagram')"><Instagram-icon id="InstagramIco" width="40" height="40"></Instagram-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'FoodForkDrink')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'FoodForkDrink')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'FoodForkDrink')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'FoodForkDrink')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'FoodForkDrink'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'FoodForkDrink')"><FoodForkDrink-icon id="foodForkDrinkIco" width="40" height="40"></FoodForkDrink-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'EmoticonHappyOutline')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'EmoticonHappyOutline')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'EmoticonHappyOutline')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'EmoticonHappyOutline')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'EmoticonHappyOutline'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'EmoticonHappyOutline')"><EmoticonHappyOutline-icon id="emohapoutIco" width="40" height="40"></EmoticonHappyOutline-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Emoticon')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Emoticon')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Emoticon')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Emoticon')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Emoticon'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'Emoticon')"><Emoticon-icon id="emoIco" width="40" height="40"></Emoticon-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'EmoticonOutline')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'EmoticonOutline')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'EmoticonOutline')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'EmoticonOutline')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'EmoticonOutline'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'EmoticonOutline')"><EmoticonOutline-icon id="emooutIco" width="40" height="40"></EmoticonOutline-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Cupcake')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Cupcake')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Cupcake')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Cupcake')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Cupcake'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'Cupcake')"><Cupcake-icon id="cupcakeIco" width="40" height="40"></Cupcake-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'CheckboxMarkedCircle')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'CheckboxMarkedCircle')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'CheckboxMarkedCircle')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'CheckboxMarkedCircle')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'CheckboxMarkedCircle'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'CheckboxMarkedCircle')"><CheckboxMarkedCircle-icon id="checmarkcirIco" width="40" height="40"></CheckboxMarkedCircle-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'GlassWine')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'GlassWine')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'GlassWine')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'GlassWine')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'GlassWine'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'GlassWine')"><GlassWine-icon id="glasswineIco" width="40" height="40"></GlassWine-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'ArrowRightCircle')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'ArrowRightCircle')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'ArrowRightCircle')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'ArrowRightCircle')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'ArrowRightCircle'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'ArrowRightCircle')"><ArrowRightCircle-icon id="arrrighcirIco" width="40" height="40"></ArrowRightCircle-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'ArrowRightCircleOutline')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'ArrowRightCircleOutline')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'ArrowRightCircleOutline')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'ArrowRightCircleOutline')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'ArrowRightCircleOutline'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'ArrowRightCircleOutline')"><ArrowRightCircleOutline-icon id="arrrighciroutIco" width="40" height="40"></ArrowRightCircleOutline-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'ChevronDoubleRight')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'ChevronDoubleRight')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'ChevronDoubleRight')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'ChevronDoubleRight')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'ChevronDoubleRight'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'ChevronDoubleRight')"><ChevronDoubleRight-icon id="chevdoubrigIco" width="40" height="40"></ChevronDoubleRight-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'GlassMugVariant')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'GlassMugVariant')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'GlassMugVariant')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'GlassMugVariant')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'GlassMugVariant'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'GlassMugVariant')"><GlassMugVariant-icon id="glassmugvarIco" width="40" height="40"></GlassMugVariant-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'ChevronRightCircle')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'ChevronRightCircle')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'ChevronRightCircle')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'ChevronRightCircle')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'ChevronRightCircle'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'ChevronRightCircle')"><ChevronRightCircle-icon id="chevrigcirIco" width="40" height="40"></ChevronRightCircle-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'BagChecked')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'BagChecked')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'BagChecked')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'BagChecked')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'BagChecked'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'BagChecked')"><BagChecked-icon id="bagcheckIco" width="40" height="40"></BagChecked-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Heart')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Heart')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Heart')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Heart')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Heart'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'Heart')"><Heart-icon id="heartIco" width="40" height="40"></Heart-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'HeartOutline')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'HeartOutline')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'HeartOutline')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'HeartOutline')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'HeartOutline'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'HeartOutline')"><HeartOutline-icon id="HeartOutlineIco" width="40" height="40"></HeartOutline-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'ChatAlert')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'ChatAlert')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'ChatAlert')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'ChatAlert')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'ChatAlert'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'ChatAlert')"><ChatAlert-icon id="ChatAlertIco" width="40" height="40"></ChatAlert-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'CommentAlert')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'CommentAlert')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'CommentAlert')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'CommentAlert')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'CommentAlert'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'CommentAlert')"><CommentAlert-icon id="CommentAlertIco" width="40" height="40"></CommentAlert-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'TooltipText')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'TooltipText')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'TooltipText')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'TooltipText')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'TooltipText'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'TooltipText')"><TooltipText-icon id="TooltipTextIco" width="40" height="40"></TooltipText-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'CarHatchback')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'CarHatchback')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'CarHatchback')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'CarHatchback')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'CarHatchback'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'CarHatchback')"><CarHatchback-icon id="CarhatchbackIco" width="40" height="40"></CarHatchback-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'AvTimer')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'AvTimer')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'AvTimer')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'AvTimer')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'AvTimer'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'AvTimer')"><AvTimer-icon id="AvTimerIco" width="40" height="40"></AvTimer-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'ClockFast')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'ClockFast')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'ClockFast')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'ClockFast')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'ClockFast'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'ClockFast')"><ClockFast-icon id="ClockFastIco" width="40" height="40"></ClockFast-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'TimerSand')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'TimerSand')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'TimerSand')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'TimerSand')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'TimerSand'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'TimerSand')"><TimerSand-icon id="TimerSandIco" width="40" height="40"></TimerSand-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Bike')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Bike')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Bike')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Bike')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Bike'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'Bike')"><Bike-icon id="BikeIco" width="40" height="40"></Bike-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Brain')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Brain')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Brain')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Brain')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Brain'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'Brain')"><Brain-icon id="BrainIco" width="40" height="40"></Brain-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Face')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Face')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Face')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Face')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Face'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'Face')"><Face-icon id="FaceIco" width="40" height="40"></Face-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'FaceWoman')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'FaceWoman')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'FaceWoman')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'FaceWoman')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'FaceWoman'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'FaceWoman')"><FaceWoman-icon id="FaceWomanIco" width="40" height="40"></FaceWoman-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'GiftOutline')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'GiftOutline')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'GiftOutline')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'GiftOutline')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'GiftOutline'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'GiftOutline')"><GiftOutline-icon id="GiftOutlineIco" width="40" height="40"></GiftOutline-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'BabyCarriage')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'BabyCarriage')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'BabyCarriage')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'BabyCarriage')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'BabyCarriage'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'BabyCarriage')"><BabyCarriage-icon id="BabyCarriageIco" width="40" height="40"></BabyCarriage-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Bone')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Bone')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Bone')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Bone')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Bone'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'Bone')"><Bone-icon id="BoneIco" width="40" height="40"></Bone-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Paw')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Paw')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Paw')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Paw')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Paw'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'Paw')"><Paw-icon id="PawIco" width="40" height="40"></Paw-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Flower')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Flower')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Flower')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Flower')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Flower'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'Flower')"><Flower-icon id="FlowerIco" width="40" height="40"></Flower-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Sprout')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Sprout')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Sprout')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Sprout')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Sprout'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'Sprout')"><Sprout-icon id="SproutIco" width="40" height="40"></Sprout-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'ArmFlexOutline')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'ArmFlexOutline')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'ArmFlexOutline')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'ArmFlexOutline')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'ArmFlexOutline'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'ArmFlexOutline')"><ArmFlexOutline-icon id="ArmFlexOutlineIco" width="40" height="40"></ArmFlexOutline-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'MonitorCellphone')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'MonitorCellphone')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'MonitorCellphone')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'MonitorCellphone')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'MonitorCellphone'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'MonitorCellphone')"><MonitorCellphone-icon id="MonitorCellphoneIco" width="40" height="40"></MonitorCellphone-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'CellphoneBasic')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'CellphoneBasic')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'CellphoneBasic')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'CellphoneBasic')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'CellphoneBasic'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'CellphoneBasic')"><CellphoneBasic-icon id="CellphoneBasicIco" width="40" height="40"></CellphoneBasic-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'ChatProcessing')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'ChatProcessing')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'ChatProcessing')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'ChatProcessing')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'ChatProcessing'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'ChatProcessing')"><ChatProcessing-icon id="ChatProcessingIco" width="40" height="40"></ChatProcessing-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'CameraWirelessOutline')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'CameraWirelessOutline')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'CameraWirelessOutline')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'CameraWirelessOutline')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'CameraWirelessOutline'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'CameraWirelessOutline')"><CameraWirelessOutline-icon id="CameraWirelessOutlineIco" width="40" height="40"></CameraWirelessOutline-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'ChefHat')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'ChefHat')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'ChefHat')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'ChefHat')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'ChefHat'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'ChefHat')"><ChefHat-icon id="ChefHatIco" width="40" height="40"></ChefHat-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Crown')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Crown')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Crown')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Crown')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Crown'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'Crown')"><Crown-icon id="CrownIco" width="40" height="40"></Crown-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'DominoMask')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'DominoMask')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'DominoMask')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'DominoMask')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'DominoMask'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'DominoMask')"><DominoMask-icon id="DominoMaskIco" width="40" height="40"></DominoMask-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Ring')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Ring')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Ring')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Ring')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Ring'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'Ring')"><Ring-icon id="RingIco" width="40" height="40"></Ring-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'ShoeHeel')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'ShoeHeel')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'ShoeHeel')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'ShoeHeel')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'ShoeHeel'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'ShoeHeel')"><ShoeHeel-icon id="ShoeHeelIco" width="40" height="40"></ShoeHeel-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'TshirtCrewOutline')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'TshirtCrewOutline')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'TshirtCrewOutline')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'TshirtCrewOutline')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'TshirtCrewOutline'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'TshirtCrewOutline')"><TshirtCrewOutline-icon id="TshirtCrewOutlineIco" width="40" height="40"></TshirtCrewOutline-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Cash100')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Cash100')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Cash100')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Cash100')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Cash100'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'Cash100')"><Cash100-icon id="Cash100Ico" width="40" height="40"></Cash100-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'PigVariant')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'PigVariant')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'PigVariant')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'PigVariant')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'PigVariant'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'PigVariant')"><PigVariant-icon id="PigVariantIco" width="40" height="40"></PigVariant-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Anchor')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Anchor')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Anchor')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Anchor')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Anchor'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'Anchor')"><Anchor-icon id="AnchorIco" width="40" height="40"></Anchor-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Charity')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Charity')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Charity')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Charity')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Charity'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'Charity')"><Charity-icon id="CharityIco" width="40" height="40"></Charity-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Lifebuoy')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Lifebuoy')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Lifebuoy')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Lifebuoy')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Lifebuoy'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'Lifebuoy')"><Lifebuoy-icon id="LifebuoyIco" width="40" height="40"></Lifebuoy-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'HeartPulse')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'HeartPulse')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'HeartPulse')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'HeartPulse')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'HeartPulse'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'HeartPulse')"><HeartPulse-icon id="HeartPulseIco" width="40" height="40"></HeartPulse-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'MedicalBag')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'MedicalBag')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'MedicalBag')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'MedicalBag')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'MedicalBag'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'MedicalBag')"><MedicalBag-icon id="MedicalBagIco" width="40" height="40"></MedicalBag-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Fire')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Fire')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Fire')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Fire')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Fire'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'Fire')"><Fire-icon id="FireIco" width="40" height="40"></Fire-icon></span>
                        <span class="iconSelector" :class="{activeIcon: ((ownAppiSelectedVariant == 1 && OwnAppi1Icon == 'Smoking')||(ownAppiSelectedVariant == 2 && OwnAppi2Icon == 'Smoking')||(ownAppiSelectedVariant == 3 && OwnAppi3Icon == 'Smoking')||(ownAppiSelectedVariant == 4 && OwnAppi4Icon == 'Smoking')||(ownAppiSelectedVariant == 5 && OwnAppi5Icon == 'Smoking'))}" v-on:click="setSelectedIcon(ownAppiSelectedVariant,'Smoking')"><Smoking-icon id="SmokingIco" width="40" height="40"></Smoking-icon></span>

                    </div>
                </div>
            </div>


            <div class="row pl-5 pr-5">
                <div class="col-md-12 py-3">
                    <div class="col-md-12 py-3 form_inline_set">
                        <div class="pr-5" style="margin-right: 8px;">
                            Barva ikony
                        </div>&nbsp;&nbsp;
                        <span>
                            <input v-show="ownAppiSelectedVariant == 1" type="text" @click="changeVisibilityPicker(1,showColorPicker1)" v-tooltip.bottom.right.notrigger="{class: 'v-tooltip_ownAppiColor', html:'iconColor1', visible: showColorPicker1}" readonly="readonly" v-bind:placeholder="Iconcolor1.hex" v-bind:style="{'background-color': Iconcolor1.hex}" v-model="Iconcolor1.hex" class="form-control form_control_set_width_1 pointer" />
                            <sketch-picker v-show="showColorPicker1" v-bind:id="'iconColor1'" v-model="tmpIconcolor1" @input="updateFromPicker(1,tmpIconcolor1)" v-click-outside="onClickOutsidePicker1"></sketch-picker>
                            <input v-show="ownAppiSelectedVariant == 2" type="text" @click="changeVisibilityPicker(2,showColorPicker2)" v-tooltip.bottom.right.notrigger="{class: 'v-tooltip_ownAppiColor', html:'iconColor2', visible: showColorPicker2}" readonly="readonly" v-bind:placeholder="Iconcolor2.hex" v-bind:style="{'background-color': Iconcolor2.hex}" v-model="Iconcolor2.hex" class="form-control form_control_set_width_1 pointer" />
                            <sketch-picker v-show="showColorPicker2" v-bind:id="'iconColor2'" v-model="tmpIconcolor2" @input="updateFromPicker(2,tmpIconcolor2)" v-click-outside="onClickOutsidePicker2"></sketch-picker>
                            <input v-show="ownAppiSelectedVariant == 3" type="text" @click="changeVisibilityPicker(3,showColorPicker3)" v-tooltip.bottom.right.notrigger="{class: 'v-tooltip_ownAppiColor', html:'iconColor3', visible: showColorPicker3}" readonly="readonly" v-bind:placeholder="Iconcolor3.hex" v-bind:style="{'background-color': Iconcolor3.hex}" v-model="Iconcolor3.hex" class="form-control form_control_set_width_1 pointer" />
                            <sketch-picker v-show="showColorPicker3" v-bind:id="'iconColor3'" v-model="tmpIconcolor3" @input="updateFromPicker(3,tmpIconcolor3)" v-click-outside="onClickOutsidePicker3"></sketch-picker>
                            <input v-show="ownAppiSelectedVariant == 4" type="text" @click="changeVisibilityPicker(4,showColorPicker4)" v-tooltip.bottom.right.notrigger="{class: 'v-tooltip_ownAppiColor', html:'iconColor4', visible: showColorPicker4}" readonly="readonly" v-bind:placeholder="Iconcolor4.hex" v-bind:style="{'background-color': Iconcolor4.hex}" v-model="Iconcolor4.hex" class="form-control form_control_set_width_1 pointer" />
                            <sketch-picker v-show="showColorPicker4" v-bind:id="'iconColor4'" v-model="tmpIconcolor4" @input="updateFromPicker(4,tmpIconcolor4)" v-click-outside="onClickOutsidePicker4"></sketch-picker>
                            <input v-show="ownAppiSelectedVariant == 5" type="text" @click="changeVisibilityPicker(5,showColorPicker5)" v-tooltip.bottom.right.notrigger="{class: 'v-tooltip_ownAppiColor', html:'iconColor5', visible: showColorPicker5}" readonly="readonly" v-bind:placeholder="Iconcolor5.hex" v-bind:style="{'background-color': Iconcolor5.hex}" v-model="Iconcolor5.hex" class="form-control form_control_set_width_1 pointer" />
                            <sketch-picker v-show="showColorPicker5" v-bind:id="'iconColor5'" v-model="tmpIconcolor5" @input="updateFromPicker(5,tmpIconcolor5)" v-click-outside="onClickOutsidePicker5"></sketch-picker>
                        </span>

                        <!--<div class="col-md-4 pl-4 text-center">
            zmenšit / zvětšit &nbsp;&nbsp;
            <vue-slider v-model="zoomIcon[(ownAppiSelectedVariant-1)]" :min="20" :max="70" v-on:change="calculateIconPosition(ownAppiSelectedVariant)"
                        :process="false" :order="false" drag-on-click="false"
                        :marks="zoomMarks" :labelStyle="{cursor:'pointer'}"
                        :dot-options="dotOptions1" />
        </div>-->

                        <div class="col-md-6 pl-5 text-center">
                            doleva / doprava &nbsp;&nbsp;
                            <vue-slider v-model="horizontalIcon[(ownAppiSelectedVariant-1)]" :min="20" :max="40" v-on:change="reloadIcon(ownAppiSelectedVariant)"
                                        :process="false" :order="true" drag-on-click="false"
                                        :marks="horizontalMarks" :labelStyle="{cursor:'pointer'}"
                                        :dot-options="dotOptions1" />

                        </div>
                    </div>

                    <!--:tooltip-formatter="horizontalDotLabel"-->
                    <!--<div class="col-md-12 py-3 form_inline_set">
        <div class="col-md-4 text-center">
            doleva / doprava &nbsp;&nbsp;
            <vue-slider v-model="horizontalIcon[(ownAppiSelectedVariant-1)]" :min="0" :max="70"
                        :process="false" :order="true" drag-on-click="false"
                        :marks="horizontalMarks" :labelStyle="{cursor:'pointer'}"
                        :dot-options="dotOptions1" />

        </div>
        <div class="col-md-4 text-center">
            nahoru / dolů &nbsp;&nbsp;
            <vue-slider v-model="verticalIcon[(ownAppiSelectedVariant-1)]" :min="0" :max="50"
                        :process="false" :order="false" drag-on-click="false"
                        :marks="verticalMarks" :labelStyle="{cursor:'pointer'}"
                        :dot-options="dotOptions1" />
        </div>
        <div class="col-md-4 text-center">
            menší / větší &nbsp;&nbsp;
            <vue-slider v-model="zoomIcon[(ownAppiSelectedVariant-1)]" :min="20" :max="70"
                        :process="false" :order="false" drag-on-click="false"
                        :marks="zoomMarks" :labelStyle="{cursor:'pointer'}"
                        :dot-options="dotOptions1" />
        </div>

    </div>-->

                    <div class="col-md-12 pt-3 form_inline_set">
                        <div class="align-top" style="height:100px">
                            Text nabídky &nbsp;&nbsp;
                        </div>
                        <div class="col-md-10 pl-5" style="height: 100px;overflow-x: hidden;overflow-y: hidden;">
                            <vue-editor v-model="editorContent[(ownAppiSelectedVariant-1)]" v-on:input="validateFields" :editorToolbar="editorToolbar" style="height:60px">
                            </vue-editor>
                        </div>
                    </div>
                    <span v-if="errors.has('editorContent['+(ownAppiSelectedVariant-1)+']')" class="d-inline-block text-center invalid-feedback " style="margin-top: 0px;">{{ errors.first('editorContent['+(ownAppiSelectedVariant-1)+']') }}</span>


                    <div class="col-md-12 py-3" v-if="topVariablesAllowed=='true'">
                        <div class="d-flex flex-row justify-content-between align-items-center">
                            <div>
                                Zobrazí maximálně posledních
                                <i style="color:royalblue" class="fa fa-question-circle pointer"
                                   v-tooltip.top="{ content: 'Doporučujeme nastavit 20 hodnot, pokud máte dostatečné množství naimportovaných dat.' }"></i>
                            </div>&nbsp;&nbsp;<input type="text" v-model="showLastTopVariables[(ownAppiSelectedVariant-1)]" placeholder="20" v-on:input="validateFields" v-validate="{}" class="form-control form_control_set_width"  :class="{ 'is-invalid': errors.has('showLastTopVariables['+(ownAppiSelectedVariant - 1)+']') }" />&nbsp;&nbsp;<div>naimportovaných hodnot</div>
                        </div>
                    </div>
                    <div class="col-md-12 py-3" v-if="topVariablesAllowed=='true'">
                        <div class="d-flex flex-row justify-content-between align-items-center">
                            <div>
                                Přehled dostupných parametrů
                                <i style="color:royalblue" class="fa fa-question-circle pointer"
                                   v-tooltip.top="{ content: 'Ze seznamu parametrů vyberte parametr a vložte do do textového editoru pomocí CTRL+V nebo jej přepište tak jak jej vidíte ve výběru.' }"></i>
                            </div>
                           
                            <select id="selectedParam" v-model="selectedParam" name="selectedParam" v-on:change="copyToClipboard($event)" style="max-width: 160px;" class="form-control ml-3">
                                <option disabled="" value="none">Vyberte</option>
                                <option v-for="parameter,index in paramList" v-bind:value="selectedParam">
                                    {{parameter}}
                                </option>
                            </select>
                            <!--&nbsp;&nbsp;<button class="btn btn-outline-secondary_order fas fa-copy copyPaste" style="padding: 0.2rem 0.5rem;" v-on:click="copyToClipboard" title="Zkopírovat vybraný parametr" alt="Zkopírovat vybraný parametr" :disabled="(selectedParam=='none' || selectedParam=='')"> </button>-->
                           
                            </div>
                        </div>

                    <div class="col-md-12 py-3">
                        <div class="d-flex flex-row justify-content-between align-items-center">
                            <div>
                                Zobrazí v notifikaci i odkaz
                                <i style="color:royalblue" class="fa fa-question-circle pointer"
                                    v-tooltip.top="{ content: 'Pokud nechcete z notifikace odkazovat na vámi vybranou stránku, můžete napsat delší text nabídky.' }"></i>
                            </div>
                            <div class="noselect">
                                <span class="toogle_desc">NE</span>&nbsp;&nbsp;
                                <button type="button" v-bind:id="'ShowLinkActive'+ownAppiSelectedVariant" class="btn btn-toggle" :key="ShowLinkActive" v-bind:class="ShowLinkActive" v-on:click="ShowLinkChange('link',ownAppiSelectedVariant)" data-toggle="button" aria-pressed="false" autocomplete="off"><div class="handle"></div></button>
                                &nbsp;&nbsp;<span class="toogle_desc">ANO</span>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12 py-3">
                        <div class="d-flex flex-row justify-content-between align-items-center">
                            <div>
                                Odkaz zobrazí jako tlačítko
                            </div>
                            <div class="noselect">
                                <span class="toogle_desc">NE</span>&nbsp;&nbsp;
                                <button type="button" v-bind:id="'ShowLinkBtnActive'+ownAppiSelectedVariant" class="btn btn-toggle" :key="ShowLinkBtnActive" v-bind:class="ShowLinkBtnActive" :disabled="!ShowLink[(ownAppiSelectedVariant - 1)]" v-on:click="ShowLinkChange('btn',ownAppiSelectedVariant)" data-toggle="button" aria-pressed="false" autocomplete="off"><div class="handle"></div></button>
                                &nbsp;&nbsp;<span class="toogle_desc">ANO</span>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12 py-3">
                        <div class="d-flex flex-row justify-content-between align-items-center">
                            <div>
                                Odkaz se otevře v novém okně
                            </div>
                            <div class="noselect">
                                <span class="toogle_desc">NE</span>&nbsp;&nbsp;
                                <button type="button" v-bind:id="'ShowLinkNewWinActive'+ownAppiSelectedVariant" class="btn btn-toggle" :key="ShowLinkNewWinActive" v-bind:class="ShowLinkNewWinActive" :disabled="!ShowLink[(ownAppiSelectedVariant - 1)]" v-on:click="ShowLinkChange('newWin',ownAppiSelectedVariant)" data-toggle="button" aria-pressed="false" autocomplete="off"><div class="handle"></div></button>
                                &nbsp;&nbsp;<span class="toogle_desc">ANO</span>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12 py-3 form_inline_set">
                        <div>
                            <span>
                                Vlastní text odkazu
                            </span>
                        </div>&nbsp;&nbsp;
                        <input type="text" v-model="linkDescription[(ownAppiSelectedVariant - 1)]" placeholder="Klikněte a získejte dárek" v-on:input="validateFields" v-validate="{}" class="form-control form_control_set_width_3" :class="{ 'is-invalid': errors.has('linkDescription['+(ownAppiSelectedVariant - 1)+']') }" :disabled="!ShowLink[(ownAppiSelectedVariant -1)]" />
                    </div>
                    <span v-if="errors.has('linkDescription['+(ownAppiSelectedVariant - 1)+']')" class="invalid-feedback" style="display: inline;left: 215px;width: 100%;top: -10px;position: relative;"> {{ errors.first('linkDescription['+(ownAppiSelectedVariant - 1)+']') }}</span>

                    <div class="col-md-12 py-3 form_inline_set">
                        <div>
                            <span>
                                Cílová URL
                                <i style="color:royalblue" class="fa fa-question-circle pointer"
                                    v-tooltip.top="{ content: 'Zadejte kompletní url odkazu včetně http://,https:// \nPro vyvolání aplikace mailto:, callto:, tel:, sms:' }"></i>
                            </span>
                        </div>&nbsp;&nbsp;
                        <input type="text" v-model="targetUrl[(ownAppiSelectedVariant - 1)]" placeholder="https://app.cz" v-on:input="validateFields" v-validate="{}" class="form-control form_control_set_width_3" :class="{ 'is-invalid': errors.has('targetUrl['+(ownAppiSelectedVariant - 1)+']') }" :disabled="!ShowLink[(ownAppiSelectedVariant -1)]" />
                    </div>
                    <span v-if="errors.has('targetUrl['+(ownAppiSelectedVariant - 1)+']')" class="invalid-feedback" style="display: inline;left: 215px;width: 100%;top: -10px;position: relative;"> {{ errors.first('targetUrl['+(ownAppiSelectedVariant - 1)+']') }}</span>

                    <div class="col-md-12 py-3 form_inline_set">
                        <div>
                            Barva tlačítka nebo textového odkazu:
                        </div>&nbsp;&nbsp;
                        <span>
                            <input v-show="ownAppiSelectedVariant == 1" type="text" @click="changeVisibilityPickerBtn(1,showColorPickerBtn1)" v-tooltip.bottom.right.notrigger="{class: 'v-tooltip_ownAppiColor', html:'iconColorBtn1', visible: showColorPickerBtn1}" readonly="readonly" v-bind:placeholder="IconcolorBtn1.hex" v-bind:style="{'background-color': IconcolorBtn1.hex}" v-model="IconcolorBtn1.hex" class="form-control form_control_set_width_1 pointer" :disabled="!ShowLink[(ownAppiSelectedVariant -1)]" />
                            <sketch-picker v-show="showColorPickerBtn1" v-bind:id="'iconColorBtn1'" v-model="tmpIconcolorBtn1" @input="updateFromPickerBtn(1,tmpIconcolorBtn1)" v-click-outside="onClickOutsidePickerBtn1"></sketch-picker>
                            <input v-show="ownAppiSelectedVariant == 2" type="text" @click="changeVisibilityPickerBtn(2,showColorPickerBtn2)" v-tooltip.bottom.right.notrigger="{class: 'v-tooltip_ownAppiColor', html:'iconColorBtn2', visible: showColorPickerBtn2}" readonly="readonly" v-bind:placeholder="IconcolorBtn2.hex" v-bind:style="{'background-color': IconcolorBtn2.hex}" v-model="IconcolorBtn2.hex" class="form-control form_control_set_width_1 pointer" :disabled="!ShowLink[(ownAppiSelectedVariant -1)]" />
                            <sketch-picker v-show="showColorPickerBtn2" v-bind:id="'iconColorBtn2'" v-model="tmpIconcolorBtn2" @input="updateFromPickerBtn(2,tmpIconcolorBtn2)" v-click-outside="onClickOutsidePickerBtn2"></sketch-picker>
                            <input v-show="ownAppiSelectedVariant == 3" type="text" @click="changeVisibilityPickerBtn(3,showColorPickerBtn3)" v-tooltip.bottom.right.notrigger="{class: 'v-tooltip_ownAppiColor', html:'iconColorBtn3', visible: showColorPickerBtn3}" readonly="readonly" v-bind:placeholder="IconcolorBtn3.hex" v-bind:style="{'background-color': IconcolorBtn3.hex}" v-model="IconcolorBtn3.hex" class="form-control form_control_set_width_1 pointer" :disabled="!ShowLink[(ownAppiSelectedVariant -1)]" />
                            <sketch-picker v-show="showColorPickerBtn3" v-bind:id="'iconColorBtn3'" v-model="tmpIconcolorBtn3" @input="updateFromPickerBtn(3,tmpIconcolorBtn3)" v-click-outside="onClickOutsidePickerBtn3"></sketch-picker>
                            <input v-show="ownAppiSelectedVariant == 4" type="text" @click="changeVisibilityPickerBtn(4,showColorPickerBtn4)" v-tooltip.bottom.right.notrigger="{class: 'v-tooltip_ownAppiColor', html:'iconColorBtn4', visible: showColorPickerBtn4}" readonly="readonly" v-bind:placeholder="IconcolorBtn4.hex" v-bind:style="{'background-color': IconcolorBtn4.hex}" v-model="IconcolorBtn4.hex" class="form-control form_control_set_width_1 pointer" :disabled="!ShowLink[(ownAppiSelectedVariant -1)]" />
                            <sketch-picker v-show="showColorPickerBtn4" v-bind:id="'iconColorBtn4'" v-model="tmpIconcolorBtn4" @input="updateFromPickerBtn(4,tmpIconcolorBtn4)" v-click-outside="onClickOutsidePickerBtn4"></sketch-picker>
                            <input v-show="ownAppiSelectedVariant == 5" type="text" @click="changeVisibilityPickerBtn(5,showColorPickerBtn5)" v-tooltip.bottom.right.notrigger="{class: 'v-tooltip_ownAppiColor', html:'iconColorBtn5', visible: showColorPickerBtn5}" readonly="readonly" v-bind:placeholder="IconcolorBtn5.hex" v-bind:style="{'background-color': IconcolorBtn5.hex}" v-model="IconcolorBtn5.hex" class="form-control form_control_set_width_1 pointer" :disabled="!ShowLink[(ownAppiSelectedVariant -1)]" />
                            <sketch-picker v-show="showColorPickerBtn5" v-bind:id="'iconColorBtn5'" v-model="tmpIconcolorBtn5" @input="updateFromPickerBtn(5,tmpIconcolorBtn5)" v-click-outside="onClickOutsidePickerBtn5"></sketch-picker>
                        </span>
                    </div>

                    <div class="col-md-12 py-3 form_inline_set">
                        <div>
                            Barva pozadí tlačítka:
                        </div>&nbsp;&nbsp;
                        <span>
                            <input v-show="ownAppiSelectedVariant == 1" type="text" @click="changeVisibilityPickerBckBtn(1,showColorPickerBckBtn1)" v-tooltip.bottom.right.notrigger="{class: 'v-tooltip_ownAppiColor', html:'iconColorBckBtn1', visible: showColorPickerBckBtn1}" readonly="readonly" v-bind:placeholder="IconcolorBckBtn1.hex" v-bind:style="{'background-color': IconcolorBckBtn1.hex}" v-model="IconcolorBckBtn1.hex" class="form-control form_control_set_width_1 pointer" :disabled="(!ShowLinkBtn[(ownAppiSelectedVariant -1)] || !ShowLink[(ownAppiSelectedVariant -1)])" />
                            <sketch-picker v-show="showColorPickerBckBtn1" v-bind:id="'iconColorBckBtn1'" v-model="tmpIconcolorBckBtn1" @input="updateFromPickerBckBtn(1,tmpIconcolorBckBtn1)" v-click-outside="onClickOutsidePickerBckBtn1"></sketch-picker>
                            <input v-show="ownAppiSelectedVariant == 2" type="text" @click="changeVisibilityPickerBckBtn(2,showColorPickerBckBtn2)" v-tooltip.bottom.right.notrigger="{class: 'v-tooltip_ownAppiColor', html:'iconColorBckBtn2', visible: showColorPickerBckBtn2}" readonly="readonly" v-bind:placeholder="IconcolorBckBtn2.hex" v-bind:style="{'background-color': IconcolorBckBtn2.hex}" v-model="IconcolorBckBtn2.hex" class="form-control form_control_set_width_1 pointer" :disabled="(!ShowLinkBtn[(ownAppiSelectedVariant -1)] || !ShowLink[(ownAppiSelectedVariant -1)])" />
                            <sketch-picker v-show="showColorPickerBckBtn2" v-bind:id="'iconColorBckBtn2'" v-model="tmpIconcolorBckBtn2" @input="updateFromPickerBckBtn(2,tmpIconcolorBckBtn2)" v-click-outside="onClickOutsidePickerBckBtn2"></sketch-picker>
                            <input v-show="ownAppiSelectedVariant == 3" type="text" @click="changeVisibilityPickerBckBtn(3,showColorPickerBckBtn3)" v-tooltip.bottom.right.notrigger="{class: 'v-tooltip_ownAppiColor', html:'iconColorBckBtn3', visible: showColorPickerBckBtn3}" readonly="readonly" v-bind:placeholder="IconcolorBckBtn3.hex" v-bind:style="{'background-color': IconcolorBckBtn3.hex}" v-model="IconcolorBckBtn3.hex" class="form-control form_control_set_width_1 pointer" :disabled="(!ShowLinkBtn[(ownAppiSelectedVariant -1)] || !ShowLink[(ownAppiSelectedVariant -1)])" />
                            <sketch-picker v-show="showColorPickerBckBtn3" v-bind:id="'iconColorBckBtn3'" v-model="tmpIconcolorBckBtn3" @input="updateFromPickerBckBtn(3,tmpIconcolorBckBtn3)" v-click-outside="onClickOutsidePickerBckBtn3"></sketch-picker>
                            <input v-show="ownAppiSelectedVariant == 4" type="text" @click="changeVisibilityPickerBckBtn(4,showColorPickerBckBtn4)" v-tooltip.bottom.right.notrigger="{class: 'v-tooltip_ownAppiColor', html:'iconColorBckBtn4', visible: showColorPickerBckBtn4}" readonly="readonly" v-bind:placeholder="IconcolorBckBtn4.hex" v-bind:style="{'background-color': IconcolorBckBtn4.hex}" v-model="IconcolorBckBtn4.hex" class="form-control form_control_set_width_1 pointer" :disabled="(!ShowLinkBtn[(ownAppiSelectedVariant -1)] || !ShowLink[(ownAppiSelectedVariant -1)])" />
                            <sketch-picker v-show="showColorPickerBckBtn4" v-bind:id="'iconColorBckBtn4'" v-model="tmpIconcolorBckBtn4" @input="updateFromPickerBckBtn(4,tmpIconcolorBckBtn4)" v-click-outside="onClickOutsidePickerBckBtn4"></sketch-picker>
                            <input v-show="ownAppiSelectedVariant == 5" type="text" @click="changeVisibilityPickerBckBtn(5,showColorPickerBckBtn5)" v-tooltip.bottom.right.notrigger="{class: 'v-tooltip_ownAppiColor', html:'iconColorBckBtn5', visible: showColorPickerBckBtn5}" readonly="readonly" v-bind:placeholder="IconcolorBckBtn5.hex" v-bind:style="{'background-color': IconcolorBckBtn5.hex}" v-model="IconcolorBckBtn5.hex" class="form-control form_control_set_width_1 pointer" :disabled="(!ShowLinkBtn[(ownAppiSelectedVariant -1)] || !ShowLink[(ownAppiSelectedVariant -1)])" />
                            <sketch-picker v-show="showColorPickerBckBtn5" v-bind:id="'iconColorBckBtn5'" v-model="tmpIconcolorBckBtn5" @input="updateFromPickerBckBtn(5,tmpIconcolorBckBtn5)" v-click-outside="onClickOutsidePickerBckBtn5"></sketch-picker>
                        </span>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="title_sidebar_set_new_campaign pl-5 pr-5 pb-3 pt-3">
                        Pravidla zobrazování notifikací
                    </div>
                </div>
            </div>
            <div class="row pl-5 pr-5">
                <div class="col-md-12 py-3">
                    <div class="d-flex flex-row justify-content-between align-items-center">
                        <div>
                            Neustálé opakování notifikací
                        </div>
                        <div class="noselect">
                            <span class="toogle_desc">NE</span>&nbsp;&nbsp;
                            <button type="button" v-bind:id="'cycleShowingActive'+ownAppiSelectedVariant" class="btn btn-toggle" :key="cycleShowingActive" v-bind:class="cycleShowingActive" v-on:click="ShowLinkChange('cycle',ownAppiSelectedVariant)" data-toggle="button" aria-pressed="false" autocomplete="off"><div class="handle"></div></button>
                            &nbsp;&nbsp;<span class="toogle_desc">ANO</span>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row pl-5 pr-5 pb-5">
                <div class="col-md-12 border-top pt-3">
                    <button class="btn btn-outline-secondary btn_new" :disabled="!SaveAllowed" v-on:click="Save">Uložit</button>
                </div>
            </div>
        </form>
    </div>
</template>


<script>
    import { mapState } from 'vuex';
 	import Vue from 'vue';
	import VueCookie from 'vue-cookie';
	import SlimDialog from 'v-slim-dialog';
    import VeeValidate from 'vee-validate';
    import VueI18n from 'vue-i18n';
    import axios from 'axios';
    import Tooltip from 'vue-directive-tooltip';
    import vClickOutside from 'v-click-outside';
    import { VueEditor } from "vue2-editor";
    import { setTimeout } from 'timers';
    import vulgarCZ from "../store/vulgarCZ.json";
    import vulgarEN from "../store/vulgarEN.json";
    import vulgarSK from "../store/vulgarSK.json";

    import VueSlider from 'vue-slider-component';
    import 'vue-slider-component/dist-css/vue-slider-component.css';

    import cs from "vee-validate/dist/locale/cs";
    import en from "vee-validate/dist/locale/en";

    import sketch from 'vue-color/src/components/Sketch.vue'; sketch.disableAlpha = true;

    import Information from 'mdi-vue/Information';
    import BellOutline from 'mdi-vue/BellOutline';
    import BellRingOutline from 'mdi-vue/BellRingOutline';
    import Sale from 'mdi-vue/Sale';
    import Truck from 'mdi-vue/Truck';
    import TagHeart from 'mdi-vue/TagHeart';
    import TooltipAccount from 'mdi-vue/TooltipAccount';
    import AccountPlusOutline from 'mdi-vue/AccountPlusOutline';
    import StarOutline from 'mdi-vue/StarOutline';
    import WalletGiftcard from 'mdi-vue/WalletGiftcard';
    import GestureTap from 'mdi-vue/GestureTap';
    import Ticket from 'mdi-vue/Ticket';
    import EyeOutline from 'mdi-vue/EyeOutline';
    import ThumbUpOutline from 'mdi-vue/ThumbUpOutline';
    import AlertCircle from 'mdi-vue/AlertCircle';
    import MessageText from 'mdi-vue/MessageText';
    import EmailOutline from 'mdi-vue/EmailOutline';
    import LightbulbOnOutline from 'mdi-vue/LightbulbOnOutline';
    import CakeVariant from 'mdi-vue/CakeVariant';
    import Facebook from 'mdi-vue/Facebook';
    import FacebookBox from 'mdi-vue/FacebookBox';
    import FacebookMessenger from 'mdi-vue/FacebookMessenger';
    import GooglePlusBox from 'mdi-vue/GooglePlusBox';
    import LinkedinBox from 'mdi-vue/LinkedinBox';
    import TwitterBox from 'mdi-vue/TwitterBox';
    import Youtube from 'mdi-vue/Youtube';
    import Instagram from 'mdi-vue/Instagram';
    import FoodForkDrink from 'mdi-vue/FoodForkDrink';
    import EmoticonHappyOutline from 'mdi-vue/EmoticonHappyOutline';
    import Emoticon from 'mdi-vue/Emoticon';
    import EmoticonOutline from 'mdi-vue/EmoticonOutline';
    import Cupcake from 'mdi-vue/Cupcake';
    import CheckboxMarkedCircle from 'mdi-vue/CheckboxMarkedCircle';
    import GlassWine from 'mdi-vue/GlassWine';
    import ArrowRightCircle from 'mdi-vue/ArrowRightCircle';
    import ArrowRightCircleOutline from 'mdi-vue/ArrowRightCircleOutline';
    import ChevronDoubleRight from 'mdi-vue/ChevronDoubleRight';
    import GlassMugVariant from 'mdi-vue/GlassMugVariant';
    import ChevronRightCircle from 'mdi-vue/ChevronRightCircle';
    import BagChecked from 'mdi-vue/BagChecked';
    import Heart from 'mdi-vue/Heart';
    import HeartOutline from 'mdi-vue/HeartOutline';
    import ChatAlert from 'mdi-vue/ChatAlert';
    import CommentAlert from 'mdi-vue/CommentAlert';
    import TooltipText from 'mdi-vue/TooltipText';
    import CarHatchback from 'mdi-vue/CarHatchback';
    import AvTimer from 'mdi-vue/AvTimer';
    import ClockFast from 'mdi-vue/ClockFast';
    import TimerSand from 'mdi-vue/TimerSand';
    import Bike from 'mdi-vue/Bike';
    import Brain from 'mdi-vue/Brain';
    import Face from 'mdi-vue/Face';
    import FaceWoman from 'mdi-vue/FaceWoman';
    import GiftOutline from 'mdi-vue/GiftOutline';
    import BabyCarriage from 'mdi-vue/BabyCarriage';
    import Bone from 'mdi-vue/Bone';
    import Paw from 'mdi-vue/Paw';
    import Flower from 'mdi-vue/Flower';
    import Sprout from 'mdi-vue/Sprout';
    import ArmFlexOutline from 'mdi-vue/ArmFlexOutline';
    import MonitorCellphone from 'mdi-vue/MonitorCellphone';
    import CellphoneBasic from 'mdi-vue/CellphoneBasic';
    import ChatProcessing from 'mdi-vue/ChatProcessing';
    import CameraWirelessOutline from 'mdi-vue/CameraWirelessOutline';
    import ChefHat from 'mdi-vue/ChefHat';
    import Crown from 'mdi-vue/Crown';
    import DominoMask from 'mdi-vue/DominoMask';
    import Ring from 'mdi-vue/Ring';
    import ShoeHeel from 'mdi-vue/ShoeHeel';
    import TshirtCrewOutline from 'mdi-vue/TshirtCrewOutline';
    import Cash100 from 'mdi-vue/Cash100';
    import PigVariant from 'mdi-vue/PigVariant';
    import Anchor from 'mdi-vue/Anchor';
    import Charity from 'mdi-vue/Charity';
    import Lifebuoy from 'mdi-vue/Lifebuoy';
    import HeartPulse from 'mdi-vue/HeartPulse';
    import MedicalBag from 'mdi-vue/MedicalBag';
    import Fire from 'mdi-vue/Fire';
    import Smoking from 'mdi-vue/Smoking';
    
    Vue.use(Tooltip); 

    Vue.use(SlimDialog);
    Vue.use(VueCookie);
    Vue.use(VueI18n);

    const parseUrl = require("parse-url");
    const parseDomain = require("parse-domain");
    const locale = Vue.cookie.get('locale') || 'cs';
    const i18n = new VueI18n({
        locale: locale
    });

    Vue.use(VeeValidate, {
        i18n,
        dictionary: {
            cs, en
        }
    });

    Vue.use(vClickOutside);

    export default {
        directives: {
            clickOutside: vClickOutside.directive
        },
        components: {
            'vue-editor': VueEditor,
            'sketch-picker': sketch,
            'vue-slider': VueSlider,

            'Information-icon': Information,
            'BellOutline-icon': BellOutline,
            'BellRingOutline-icon': BellRingOutline,
            'Sale-icon': Sale,
            'Truck-icon': Truck,
            'TagHeart-icon': TagHeart,
            'TooltipAccount-icon': TooltipAccount,
            'AccountPlusOutline-icon': AccountPlusOutline,
            'StarOutline-icon': StarOutline,
            'WalletGiftcard-icon': WalletGiftcard,
            'GestureTap-icon': GestureTap,
            'Ticket-icon': Ticket,
            'EyeOutline-icon': EyeOutline,
            'ThumbUpOutline-icon': ThumbUpOutline,
            'AlertCircle-icon': AlertCircle,
            'MessageText-icon': MessageText,
            'EmailOutline-icon': EmailOutline,
            'LightbulbOnOutline-icon': LightbulbOnOutline,
            'CakeVariant-icon': CakeVariant,
            'Facebook-icon': Facebook,
            'FacebookBox-icon': FacebookBox,
            'FacebookMessenger-icon': FacebookMessenger,
            'GooglePlusBox-icon': GooglePlusBox,
            'LinkedinBox-icon': LinkedinBox,
            'TwitterBox-icon': TwitterBox,
            'Youtube-icon': Youtube,
            'Instagram-icon': Instagram,
            'FoodForkDrink-icon': FoodForkDrink,
            'EmoticonHappyOutline-icon': EmoticonHappyOutline,
            'Emoticon-icon': Emoticon,
            'EmoticonOutline-icon': EmoticonOutline,
            'Cupcake-icon': Cupcake,
            'CheckboxMarkedCircle-icon': CheckboxMarkedCircle,
            'GlassWine-icon': GlassWine,
            'ArrowRightCircle-icon': ArrowRightCircle,
            'ArrowRightCircleOutline-icon': ArrowRightCircleOutline,
            'ChevronDoubleRight-icon': ChevronDoubleRight,
            'GlassMugVariant-icon': GlassMugVariant,
            'ChevronRightCircle-icon': ChevronRightCircle,
            'BagChecked-icon': BagChecked,
            'Heart-icon': Heart,
            'HeartOutline-icon': HeartOutline,
            'ChatAlert-icon': ChatAlert,
            'CommentAlert-icon': CommentAlert,
            'TooltipText-icon': TooltipText,
            'CarHatchback-icon': CarHatchback,
            'AvTimer-icon': AvTimer,
            'ClockFast-icon': ClockFast,
            'TimerSand-icon': TimerSand,
            'Bike-icon': Bike,
            'Brain-icon': Brain,
            'Face-icon': Face,
            'FaceWoman-icon': FaceWoman,
            'GiftOutline-icon': GiftOutline,
            'BabyCarriage-icon': BabyCarriage,
            'Bone-icon': Bone,
            'Paw-icon': Paw,
            'Flower-icon': Flower,
            'Sprout-icon': Sprout,
            'ArmFlexOutline-icon': ArmFlexOutline,
            'MonitorCellphone-icon': MonitorCellphone,
            'CellphoneBasic-icon': CellphoneBasic,
            'ChatProcessing-icon': ChatProcessing,
            'CameraWirelessOutline-icon': CameraWirelessOutline,
            'ChefHat-icon': ChefHat,
            'Crown-icon': Crown,
            'DominoMask-icon': DominoMask,
            'Ring-icon': Ring,
            'ShoeHeel-icon': ShoeHeel,
            'TshirtCrewOutline-icon': TshirtCrewOutline,
            'Cash100-icon': Cash100,
            'PigVariant-icon': PigVariant,
            'Anchor-icon': Anchor,
            'Charity-icon': Charity,
            'Lifebuoy-icon': Lifebuoy,
            'HeartPulse-icon': HeartPulse,
            'MedicalBag-icon': MedicalBag,
            'Fire-icon': Fire,
            'Smoking-icon': Smoking,

        },
        data() {
            return {
                selectOptionList: ['Information', 'BellOutline', 'BellRingOutline', 'Sale', 'Truck', 'TagHeart', 'TooltipAccount', 'AccountPlusOutline', 'StarOutline', 'WalletGiftcard', 'GestureTap', 'Ticket', 'EyeOutline', 'ThumbUpOutline', 'AlertCircle', 'MessageText', 'EmailOutline', 'LightbulbOnOutline', 'CakeVariant', 'Facebook', 'FacebookBox', 'FacebookMessenger', 'GooglePlusBox', 'LinkedinBox', 'TwitterBox',
                    'Youtube', 'Instagram', 'FoodForkDrink', 'EmoticonHappyOutline', 'Emoticon', 'EmoticonOutline', 'Cupcake', 'CheckboxMarkedCircle', 'GlassWine', 'ArrowRightCircle', 'ArrowRightCircleOutline', 'ChevronDoubleRight', 'GlassMugVariant', 'ChevronRightCircle', 'BagChecked', 'Heart', 'HeartOutline', 'ChatAlert', 'CommentAlert', 'TooltipText', 'CarHatchback', 'AvTimer', 'ClockFast', 'TimerSand',
                    'Bike', 'Brain', 'Face', 'FaceWoman', 'GiftOutline', 'BabyCarriage', 'Bone', 'Paw', 'Flower', 'Sprout', 'ArmFlexOutline', 'MonitorCellphone', 'CellphoneBasic', 'ChatProcessing', 'CameraWirelessOutline', 'ChefHat', 'Crown', 'DominoMask', 'Ring', 'ShoeHeel', 'TshirtCrewOutline', 'Cash100', 'PigVariant', 'Anchor', 'Charity', 'Lifebuoy', 'HeartPulse', 'MedicalBag', 'Fire', 'Smoking'],

                selectedParam: 'none',
                topVariablesAllowed: Vue.cookie.get('topVariables') || false,
                paramList: [],

                //temp part
                selectedLanguage: this.$store.state.selectedLanguage,
                userUid: "none",
                SaveAllowed: true,
                ownAppiSelectedVariant: 1,
                tmpIconcolor1: '#813EEF', tmpIconcolor2: '#813EEF', tmpIconcolor3: '#813EEF', tmpIconcolor4: '#813EEF', tmpIconcolor5: '#813EEF',
                tmpIconcolorBtn1: '#813EEF', tmpIconcolorBtn2: '#813EEF', tmpIconcolorBtn3: '#813EEF', tmpIconcolorBtn4: '#813EEF', tmpIconcolorBtn5: '#813EEF',
                tmpIconcolorBckBtn1: '#ffffff', tmpIconcolorBckBtn2: '#ffffff', tmpIconcolorBckBtn3: '#ffffff', tmpIconcolorBckBtn4: '#ffffff', tmpIconcolorBckBtn5: '#ffffff',

                visibility1: false, visibility2: false, visibility3: false, visibility4: false, visibility5: false,
                showColorPicker1: false, showColorPicker2: false, showColorPicker3: false, showColorPicker4: false, showColorPicker5: false,
                showColorPickerBtn1: false, showColorPickerBtn2: false, showColorPickerBtn3: false, showColorPickerBtn4: false, showColorPickerBtn5: false,
                showColorPickerBckBtn1: false, showColorPickerBckBtn2: false, showColorPickerBckBtn3: false, showColorPickerBckBtn4: false, showColorPickerBckBtn5: false,
                //horizontalMarks: { '0': 'vlevo', '31': 'střed', '50': 'vpravo' }, horizontalDotLabel: '{value}',
                //verticalMarks: { '0': 'nahoru', '5': 'střed', '20': 'dolů' }, verticalDotLabel: '{value}',
                //zoomMarks: { '-20': 'min', '0': 'ideal', '20': 'max' }, zoomDotLabel: '{value}',
                //horizontalMarks: { '31': 'optimální' }, horizontalDotLabel: '{value}',
                //verticalMarks: { '10': 'optimální'}, verticalDotLabel: '{value}',
                //zoomMarks: { '50': 'optimální' }, zoomDotLabel: '{value}',
                zoomMarks: { '50': { label: '', style: { width: '10px', height: '10px', cursor: 'pointer', display: 'block', backgroundColor: '#6200EE', transform: 'translate(-2px, -2px)' } } },
                dotOptions1: [{ disabled: false, tooltip: 'none' }],//dotOptions1: [{ disabled: false, tooltip: 'always'}],
                editorToolbar: [["bold", "italic", "strike"], [{ color: [] }, { background: [] }], ["clean"]],


                //data for saving
                showLastTopVariables: this.$store.getters.OWNAppi_showLastTopVariables,
                Iconcolor1: this.$store.getters.OWNAppi_Iconcolor1,
                Iconcolor2: this.$store.getters.OWNAppi_Iconcolor2,
                Iconcolor3: this.$store.getters.OWNAppi_Iconcolor3,
                Iconcolor4: this.$store.getters.OWNAppi_Iconcolor4,
                Iconcolor5: this.$store.getters.OWNAppi_Iconcolor5,
                IconcolorBtn1: this.$store.getters.OWNAppi_IconcolorBtn1,
                IconcolorBtn2: this.$store.getters.OWNAppi_IconcolorBtn2,
                IconcolorBtn3: this.$store.getters.OWNAppi_IconcolorBtn3,
                IconcolorBtn4: this.$store.getters.OWNAppi_IconcolorBtn4,
                IconcolorBtn5: this.$store.getters.OWNAppi_IconcolorBtn5,
                IconcolorBckBtn1: this.$store.getters.OWNAppi_IconcolorBckBtn1,
                IconcolorBckBtn2: this.$store.getters.OWNAppi_IconcolorBckBtn2,
                IconcolorBckBtn3: this.$store.getters.OWNAppi_IconcolorBckBtn3,
                IconcolorBckBtn4: this.$store.getters.OWNAppi_IconcolorBckBtn4,
                IconcolorBckBtn5: this.$store.getters.OWNAppi_IconcolorBckBtn5,
                horizontalIcon: this.$store.getters.OWNAppi_horizontalIcon,
                verticalIcon: this.$store.getters.OWNAppi_verticalIcon,
                zoomIcon: this.$store.getters.OWNAppi_zoomIcon,
                editorContent: this.$store.getters.OWNAppi_editorContentCz,
                targetUrl: this.$store.getters.OWNAppi_targetUrl,
                linkDescription: this.$store.getters.OWNAppi_linkDescriptionCz,

                ShowLinkNewWin: this.$store.getters.OWNAppi_ShowLinkNewWin,
                ShowLinkBtn: this.$store.getters.OWNAppi_ShowLinkBtn,
                ShowLink: this.$store.getters.OWNAppi_ShowLink,
                ownAppiActive: [false, false, false, false, false],
                CycleShowing: this.$store.getters.OWNAppi_CycleShowing,
                OwnAppi1Name: this.$store.getters.OWNAppi_OwnAppi1Name, OwnAppi2Name: this.$store.getters.OWNAppi_OwnAppi2Name, OwnAppi3Name: this.$store.getters.OWNAppi_OwnAppi3Name, OwnAppi4Name: this.$store.getters.OWNAppi_OwnAppi4Name, OwnAppi5Name: this.$store.getters.OWNAppi_OwnAppi5Name,
                OwnAppi1Icon: this.$store.getters.OWNAppi_OwnAppi1Icon, OwnAppi2Icon: this.$store.getters.OWNAppi_OwnAppi2Icon, OwnAppi3Icon: this.$store.getters.OWNAppi_OwnAppi3Icon, OwnAppi4Icon: this.$store.getters.OWNAppi_OwnAppi4Icon, OwnAppi5Icon: this.$store.getters.OWNAppi_OwnAppi5Icon,
                OwnAppiIcons: this.$store.getters.OWNAppi_OwnAppiIcons,

            }
        },
        computed: mapState({
            state: state => state.OwnAppi,

            ShowLinkActive: function () {
                return { active: this.ShowLink[(this.ownAppiSelectedVariant - 1)] }
            },
            ShowLinkBtnActive: function () {
                return { active: this.ShowLinkBtn[(this.ownAppiSelectedVariant - 1)] }
            },
            ShowLinkNewWinActive: function () {
                return { active: this.ShowLinkNewWin[(this.ownAppiSelectedVariant - 1)] }
            },
            ownAppiBtnActive: function () {
                return { active: this.ownAppiActive[(this.ownAppiSelectedVariant - 1)] }
            },
            cycleShowingActive: function () {
                return { active: this.CycleShowing[(this.ownAppiSelectedVariant - 1)] }
            }
        }),
        activated() {
        },
        mounted() {
            this.updateFromPicker(1, this.Iconcolor1);

            document.querySelector("#ownAppiPanel").addEventListener('scroll', function () {
                if (document.querySelector("#ownAppiPanel").scrollTop > 259 && document.querySelector('#ownAppiBubble').style.position == 'relative') {
                    var el = document.querySelector('#ownAppiBubble');
                    el.style.position = 'fixed';
                    el.style.top = '0px';
                    el.style.width = '100%';
                    el.style.zIndex = '1000';
                } else if (document.querySelector("#ownAppiPanel").scrollTop < 100) {
                    var el = document.querySelector('#ownAppiBubble');
                    el.style.position = 'relative';
                }
            });

            var that = this;
            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/getNDictionary",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({
                    session: Vue.cookie.get('session'),
                    using: 'app',
                })
            }).done(function (data) {
                that.dictionaryList = data.nDictionary;
                that.linkDescription = JSON.parse(that.translateAppi('ownLinkDescriptions', that.selectedLanguage));
                that.editorContent = JSON.parse(that.translateAppi('ownEditorContents', that.selectedLanguage));
            });

        },
        methods: {
            translateAppi(word, language) {
                try {
                    return this.dictionaryList.filter(function (s, i) {
                        return (s["systemName"] == word);
                    })[0][language];
                } catch (err) {
                    return [[]];
                }
            },
            copyToClipboard(value) {
                try {
                    document.getElementById('selectedParam').onchange = function () {
                        var input = document.createElement('input');
                        input.setAttribute('value', value.target.selectedOptions[0].text);
                        document.body.appendChild(input);
                        input.select();
                        var result = document.execCommand('copy');
                        document.body.removeChild(input)
                        return result;
                    }
                }
                catch (err) {
                }
            },

            mouseOverChange(visNr, status) {
                if (status == 'on') {
                    setTimeout(() => {
                        var el = document.querySelector("#bubbleLinkButton");
                        el.style.color = ((visNr == 1) ? this.IconcolorBckBtn1.hex : (visNr == 2) ? this.IconcolorBckBtn2.hex : (visNr == 3) ? this.IconcolorBckBtn3.hex : (visNr == 4) ? this.IconcolorBckBtn4.hex : this.IconcolorBckBtn5.hex);
                        el.style.backgroundColor = ((visNr == 1) ? this.IconcolorBtn1.hex : (visNr == 2) ? this.IconcolorBtn2.hex : (visNr == 3) ? this.IconcolorBtn3.hex : (visNr == 4) ? this.IconcolorBtn4.hex : this.IconcolorBtn5.hex);
                    }, 0);

                } else {
                    setTimeout(() => {
                        var el = document.querySelector("#bubbleLinkButton");
                        el.style.color = ((visNr == 1) ? this.IconcolorBtn1.hex : (visNr == 2) ? this.IconcolorBtn2.hex : (visNr == 3) ? this.IconcolorBtn3.hex : (visNr == 4) ? this.IconcolorBtn4.hex : this.IconcolorBtn5.hex);
                        el.style.backgroundColor = ((visNr == 1) ? this.IconcolorBckBtn1.hex : (visNr == 2) ? this.IconcolorBckBtn2.hex : (visNr == 3) ? this.IconcolorBckBtn3.hex : (visNr == 4) ? this.IconcolorBckBtn4.hex : this.IconcolorBckBtn5.hex);
                    }, 0);
                }
            },

            openWindow(url, visNr) {
                window.open(url, ((this.ShowLinkNewWin[(visNr - 1)]) ? '_blank' : '_self'));
            },
            updateFromPicker(visNr, value) {
                switch (visNr) {
                    case 1:
                        this.Iconcolor1 = value; document.querySelector("#" + this.OwnAppi1Icon).setAttribute("fill", value.hex);
                        break;
                    case 2:
                        this.Iconcolor2 = value; document.querySelector("#" + this.OwnAppi2Icon).setAttribute("fill", value.hex);
                        break;
                    case 3:
                        this.Iconcolor3 = value; document.querySelector("#" + this.OwnAppi3Icon).setAttribute("fill", value.hex);
                        break;
                    case 4:
                        this.Iconcolor4 = value; document.querySelector("#" + this.OwnAppi4Icon).setAttribute("fill", value.hex);
                        break;
                    case 5:
                        this.Iconcolor5 = value; document.querySelector("#" + this.OwnAppi5Icon).setAttribute("fill", value.hex);
                        break;
                    default:
                }
                var that = this;
                that.reloadIcon(visNr);
            },
            calculateIconPosition(visNr) {
                this.horizontalIcon[(visNr - 1)] = (40 - ((this.zoomIcon[(visNr - 1)] - 19) / 2.5)) + Math.sin(((this.zoomIcon[(visNr - 1)] - 19) / 19) - 50) * 3;
                this.verticalIcon[(visNr - 1)] = 35 - (this.zoomIcon[(visNr - 1)] / 2);
                var that = this;
                that.reloadIcon(visNr);
            },
            reloadIcon(visNr) {
                setTimeout(() => {
                    if (document.querySelector('#' + ((visNr == 1) ? this.OwnAppi1Icon : (visNr == 2) ? this.OwnAppi2Icon : (visNr == 3) ? this.OwnAppi3Icon : (visNr == 4) ? this.OwnAppi4Icon : this.OwnAppi5Icon)) != undefined) {
                        this.OwnAppiIcons[(visNr - 1)] = document.querySelector('#' + ((visNr == 1) ? this.OwnAppi1Icon : (visNr == 2) ? this.OwnAppi2Icon : (visNr == 3) ? this.OwnAppi3Icon : (visNr == 4) ? this.OwnAppi4Icon : this.OwnAppi5Icon)).outerHTML.replace(/"/g, "'");
                    }
                }, 0);
            },
            updateFromPickerBtn(visNr, value) {
                switch (visNr) {
                    case 1:
                        this.IconcolorBtn1 = value; break;
                    case 2:
                        this.IconcolorBtn2 = value; break;
                    case 3:
                        this.IconcolorBtn3 = value; break;
                    case 4:
                        this.IconcolorBtn4 = value; break;
                    case 5:
                        this.IconcolorBtn5 = value; break;
                    default:
                }
            },
            updateFromPickerBckBtn(visNr, value) {
                switch (visNr) {
                    case 1:
                        this.IconcolorBckBtn1 = value; break;
                    case 2:
                        this.IconcolorBckBtn2 = value; break;
                    case 3:
                        this.IconcolorBckBtn3 = value; break;
                    case 4:
                        this.IconcolorBckBtn4 = value; break;
                    case 5:
                        this.IconcolorBckBtn5 = value; break;
                    default:
                }
            },

            ShowLinkChange(type, visNr) {
                switch (type) {
                    case 'link':
                        this.ShowLink[(visNr - 1)] = !this.ShowLink[(visNr - 1)];
                        if (this.ShowLink[(this.ownAppiSelectedVariant - 1)]) {
                            setTimeout(() => { document.querySelector("#ShowLinkActive" + this.ownAppiSelectedVariant).classList.add("active"); }, 0);
                        } else {
                            setTimeout(() => { document.querySelector("#ShowLinkActive" + this.ownAppiSelectedVariant).classList.remove("active"); }, 0);
                        }
                        break;
                    case 'btn':
                        this.ShowLinkBtn[(visNr - 1)] = !this.ShowLinkBtn[(visNr - 1)];
                        if (this.ShowLinkBtn[(this.ownAppiSelectedVariant - 1)]) {
                            setTimeout(() => { document.querySelector("#messageData").style.marginTop = '-3px'; }, 0);
                            setTimeout(() => { document.querySelector("#ShowLinkBtnActive" + this.ownAppiSelectedVariant).classList.add("active"); }, 0);
                        } else {
                            setTimeout(() => { document.querySelector("#messageData").style.marginTop = '0px'; }, 0);
                            setTimeout(() => { document.querySelector("#ShowLinkBtnActive" + this.ownAppiSelectedVariant).classList.remove("active"); }, 0);
                        }
                        break;
                    case 'newWin':
                        this.ShowLinkNewWin[(visNr - 1)] = !this.ShowLinkNewWin[(visNr - 1)];
                        if (this.ShowLinkNewWin[(this.ownAppiSelectedVariant - 1)]) {
                            setTimeout(() => { document.querySelector("#ShowLinkNewWinActive" + this.ownAppiSelectedVariant).classList.add("active"); }, 0);
                        } else {
                            setTimeout(() => { document.querySelector("#ShowLinkNewWinActive" + this.ownAppiSelectedVariant).classList.remove("active"); }, 0);
                        }
                        break;
                    case 'Appi':
                        this.ownAppiActive[(visNr - 1)] = !this.ownAppiActive[(visNr - 1)];
                        if (this.ownAppiActive[(this.ownAppiSelectedVariant - 1)]) {
                            setTimeout(() => { document.querySelector("#ownAppiBtnActive" + this.ownAppiSelectedVariant).classList.add("active"); }, 0);
                        } else {
                            setTimeout(() => { document.querySelector("#ownAppiBtnActive" + this.ownAppiSelectedVariant).classList.remove("active"); }, 0);
                        }

                        break;
                    case 'cycle':
                        this.CycleShowing[(visNr - 1)] = !this.CycleShowing[(visNr - 1)];
                        if (this.CycleShowing[(this.ownAppiSelectedVariant - 1)]) {
                            setTimeout(() => { document.querySelector("#cycleShowingActive" + this.ownAppiSelectedVariant).classList.add("active"); }, 0);
                        } else {
                            setTimeout(() => { document.querySelector("#cycleShowingActive" + this.ownAppiSelectedVariant).classList.remove("active"); }, 0);
                        }
                        break;
                    default:
                }
                this.validateFields();
            },

            onClickOutside1(event) { this.visibility1 = false; this.reloadIcon(1) },
            onClickOutside2(event) { this.visibility2 = false; this.reloadIcon(2) },
            onClickOutside3(event) { this.visibility3 = false; this.reloadIcon(3) },
            onClickOutside4(event) { this.visibility4 = false; this.reloadIcon(4) },
            onClickOutside5(event) { this.visibility5 = false; this.reloadIcon(5) },

            onClickOutsidePicker1(event) { this.showColorPicker1 = false; this.reloadIcon(1) },
            onClickOutsidePicker2(event) { this.showColorPicker2 = false; this.reloadIcon(2) },
            onClickOutsidePicker3(event) { this.showColorPicker3 = false; this.reloadIcon(3) },
            onClickOutsidePicker4(event) { this.showColorPicker4 = false; this.reloadIcon(4) },
            onClickOutsidePicker5(event) { this.showColorPicker5 = false; this.reloadIcon(5) },

            onClickOutsidePickerBtn1(event) { this.showColorPickerBtn1 = false; },
            onClickOutsidePickerBtn2(event) { this.showColorPickerBtn2 = false; },
            onClickOutsidePickerBtn3(event) { this.showColorPickerBtn3 = false; },
            onClickOutsidePickerBtn4(event) { this.showColorPickerBtn4 = false; },
            onClickOutsidePickerBtn5(event) { this.showColorPickerBtn5 = false; },

            onClickOutsidePickerBckBtn1(event) { this.showColorPickerBckBtn1 = false; },
            onClickOutsidePickerBckBtn2(event) { this.showColorPickerBckBtn2 = false; },
            onClickOutsidePickerBckBtn3(event) { this.showColorPickerBckBtn3 = false; },
            onClickOutsidePickerBckBtn4(event) { this.showColorPickerBckBtn4 = false; },
            onClickOutsidePickerBckBtn5(event) { this.showColorPickerBckBtn5 = false; },

            setSelectedIcon(visNr, Icon) {
                switch (visNr) {
                    case 1:
                        this.OwnAppi1Icon = Icon; break;
                    case 2:
                        this.OwnAppi2Icon = Icon; break;
                    case 3:
                        this.OwnAppi3Icon = Icon; break;
                    case 4:
                        this.OwnAppi4Icon = Icon; break;
                    case 5:
                        this.OwnAppi5Icon = Icon; break;
                    default:
                }
                var that = this;
                that.reloadIcon(visNr);
            },
            changeVisibility(visNr, status) {
                switch (visNr) {
                    case 1:
                        this.visibility2 = this.visibility3 = this.visibility4 = this.visibility5 = false; setTimeout(() => { this.visibility1 = !status }, 300); break;
                    case 2:
                        this.visibility1 = this.visibility3 = this.visibility4 = this.visibility5 = false; setTimeout(() => { this.visibility2 = !status }, 300); break;
                    case 3:
                        this.visibility1 = this.visibility2 = this.visibility4 = this.visibility5 = false; setTimeout(() => { this.visibility3 = !status }, 300); break;
                    case 4:
                        this.visibility1 = this.visibility2 = this.visibility3 = this.visibility5 = false; setTimeout(() => { this.visibility4 = !status }, 300); break;
                    case 5:
                        this.visibility1 = this.visibility2 = this.visibility3 = this.visibility4 = false; setTimeout(() => { this.visibility5 = !this.visibility5 }, 300); break;
                    default:
                        this.visibility1 = this.visibility2 = this.visibility3 = this.visibility4 = this.visibility5 = false;
                        this.showColorPicker1 = this.showColorPicker2 = this.showColorPicker3 = this.showColorPicker4 = this.showColorPicker5 = false;
                        this.showColorPickerBtn1 = this.showColorPickerBtn2 = this.showColorPickerBtn3 = this.showColorPickerBtn4 = this.showColorPickerBtn5 = false;
                        this.showColorPickerBckBtn1 = this.showColorPickerBckBtn2 = this.showColorPickerBckBtn3 = this.showColorPickerBckBtn4 = this.showColorPickerBckBtn5 = false;
                }
            },
            changeVisibilityPicker(visNr, status) {
                switch (visNr) {
                    case 1:
                        this.showColorPicker2 = this.showColorPicker3 = this.showColorPicker4 = this.showColorPicker5 = false; setTimeout(() => { this.showColorPicker1 = !status }, 0); break;
                    case 2:
                        this.showColorPicker1 = this.showColorPicker3 = this.showColorPicker4 = this.showColorPicker5 = false; setTimeout(() => { this.showColorPicker2 = !status }, 0); break;
                    case 3:
                        this.showColorPicker1 = this.showColorPicker2 = this.showColorPicker4 = this.showColorPicker5 = false; setTimeout(() => { this.showColorPicker3 = !status }, 0); break;
                    case 4:
                        this.showColorPicker1 = this.showColorPicker2 = this.showColorPicker3 = this.showColorPicker5 = false; setTimeout(() => { this.showColorPicker4 = !status }, 0); break;
                    case 5:
                        this.showColorPicker1 = this.showColorPicker2 = this.showColorPicker3 = this.showColorPicker4 = false; setTimeout(() => { this.showColorPicker5 = !status }, 0); break;
                    default:
                        this.showColorPicker1 = this.showColorPicker2 = this.showColorPicker3 = this.showColorPicker4 = this.showColorPicker5 = false;
                }
            },
            changeVisibilityPickerBtn(visNr, status) {
                switch (visNr) {
                    case 1:
                        this.showColorPickerBtn2 = this.showColorPickerBtn3 = this.showColorPickerBtn4 = this.showColorPickerBtn5 = false; setTimeout(() => { this.showColorPickerBtn1 = !status }, 0); break;
                    case 2:
                        this.showColorPickerBtn1 = this.showColorPickerBtn3 = this.showColorPickerBtn4 = this.showColorPickerBtn5 = false; setTimeout(() => { this.showColorPickerBtn2 = !status }, 0); break;
                    case 3:
                        this.showColorPickerBtn1 = this.showColorPickerBtn2 = this.showColorPickerBtn4 = this.showColorPickerBtn5 = false; setTimeout(() => { this.showColorPickerBtn3 = !status }, 0); break;
                    case 4:
                        this.showColorPickerBtn1 = this.showColorPickerBtn2 = this.showColorPickerBtn3 = this.showColorPickerBtn5 = false; setTimeout(() => { this.showColorPickerBtn4 = !status }, 0); break;
                    case 5:
                        this.showColorPickerBtn1 = this.showColorPickerBtn2 = this.showColorPickerBtn3 = this.showColorPickerBtn4 = false; setTimeout(() => { this.showColorPickerBtn5 = !status }, 0); break;
                    default:
                        this.showColorPickerBtn1 = this.showColorPickerBtn2 = this.showColorPickerBtn3 = this.showColorPickerBtn4 = this.showColorPickerBtn5 = false;
                }
            },
            changeVisibilityPickerBckBtn(visNr, status) {
                switch (visNr) {
                    case 1:
                        this.showColorPickerBckBtn2 = this.showColorPickerBckBtn3 = this.showColorPickerBckBtn4 = this.showColorPickerBckBtn5 = false; setTimeout(() => { this.showColorPickerBckBtn1 = !status }, 0); break;
                    case 2:
                        this.showColorPickerBckBtn1 = this.showColorPickerBckBtn3 = this.showColorPickerBckBtn4 = this.showColorPickerBckBtn5 = false; setTimeout(() => { this.showColorPickerBckBtn2 = !status }, 0); break;
                    case 3:
                        this.showColorPickerBckBtn1 = this.showColorPickerBckBtn2 = this.showColorPickerBckBtn4 = this.showColorPickerBckBtn5 = false; setTimeout(() => { this.showColorPickerBckBtn3 = !status }, 0); break;
                    case 4:
                        this.showColorPickerBckBtn1 = this.showColorPickerBckBtn2 = this.showColorPickerBckBtn3 = this.showColorPickerBckBtn5 = false; setTimeout(() => { this.showColorPickerBckBtn4 = !status }, 0); break;
                    case 5:
                        this.showColorPickerBckBtn1 = this.showColorPickerBckBtn2 = this.showColorPickerBckBtn3 = this.showColorPickerBckBtn4 = false; setTimeout(() => { this.showColorPickerBckBtn5 = !status }, 0); break;
                    default:
                        this.showColorPickerBckBtn1 = this.showColorPickerBckBtn2 = this.showColorPickerBckBtn3 = this.showColorPickerBckBtn4 = this.showColorPickerBckBtn5 = false;
                }
            },
            changeOwnAppiSelectedVariant(value) {
                setTimeout(() => {
                    if (document.querySelector("#" + ((value == 1) ? this.OwnAppi1Icon : (value == 2) ? this.OwnAppi2Icon : (value == 3) ? this.OwnAppi3Icon : (value == 4) ? this.OwnAppi4Icon : this.OwnAppi5Icon))) {
                        document.querySelector("#" +
                            ((value == 1) ? this.OwnAppi1Icon : (value == 2) ? this.OwnAppi2Icon : (value == 3) ? this.OwnAppi3Icon : (value == 4) ? this.OwnAppi4Icon : this.OwnAppi5Icon)
                        ).setAttribute("fill", ((value == 1) ? this.Iconcolor1.hex : (value == 2) ? this.Iconcolor2.hex : (value == 3) ? this.Iconcolor3.hex : (value == 4) ? this.Iconcolor4.hex : this.Iconcolor5.hex))
                    }
                }, 100);
                if (this.ShowLinkBtn[(value - 1)]) {
                    setTimeout(() => { document.querySelector("#messageData").style.marginTop = '-3px'; }, 0);
                } else {
                    setTimeout(() => { document.querySelector("#messageData").style.marginTop = '0px'; }, 0);
                }
                this.ownAppiSelectedVariant = value;
            },
            parseUrl(parsUrl) {
                return parseUrl(parsUrl, true).resource;
            },
            validUrl(valUrl) {
                if (parseUrl(valUrl, false).protocol != "http" && parseUrl(valUrl, false).protocol != "https" && parseUrl(valUrl, false).protocol != "ssh") {
                    return false;
                }

                if (parseUrl(valUrl, true).protocol == null) {
                    return false;
                }

                if (parseDomain(valUrl) == null) {
                    return false;
                }

                if (/^[a-zA-Z0-9][a-zA-Z0-9-]{1,61}[a-zA-Z0-9]\.[a-zA-Z]{2,}$/.test(parseUrl(valUrl, true).resource) || /^[a-zA-Z0-9-]{0,61}[a-zA-Z0-9]\.[a-zA-Z0-9-]{1,61}[a-zA-Z0-9]\.[a-zA-Z]{1,}$/.test(parseUrl(valUrl, true).resource)) {
                    return true;
                } else {
                    return false;
                }
            },
            getVariablesLength(input) {
                try {
                    var regex = /\[([^\]]*)\]/g;
                    var matches = [];
                    var match;
                    var lengthVariables = 0;
                    while (match = regex.exec(input)) {
                        matches.push(JSON.parse('[' + match[1] + ']'));
                    }
                    for (var i = 0; i < matches.length; i++) {
                        lengthVariables += matches[i][1];
                    }
                    return lengthVariables;
                }
                catch (err) {
                    return 0;
                }
            },
            checkVulgar(fieldName, text, language) {
                this.selectedLanguage = this.$store.state.selectedLanguage;
                let res = true;
                var that = this;
                switch (language) {
                    case "cs":
                        vulgarCZ.forEach(function (child) {
                            if (text.includes(child + " ")) {
                                that.errors.add({ field: fieldName, msg: 'Pardon, ale pod tohle se teda nepodepíšem' });
                                res = false;
                            }
                        });
                        break;
                    case "sk":
                        vulgarSK.forEach(function (child) {
                            if (text.includes(child + " ")) {
                                that.errors.add({ field: fieldName, msg: 'Pardon, ale pod tohle se teda nepodepíšem' });
                                res = false;
                            }
                        });
                        break;
                    case "en":
                        vulgarEN.forEach(function (child) {
                            if (text.includes(child + " ")) {
                                that.errors.add({ field: fieldName, msg: 'Pardon, ale pod tohle se teda nepodepíšem' });
                                res = false;
                            }
                        });
                        break;
                }
                return res;
            },
            validateFields: function () {
                this.errors.clear();
                var that = this;
                this.$validator.validateAll('n').then((valid) => {
                    if (valid) {
                        that.SaveAllowed = true;

                        if (that.showLastTopVariables[(that.ownAppiSelectedVariant - 1)] < 1 || that.showLastTopVariables[(that.ownAppiSelectedVariant - 1)] > 99) {
                            that.errors.add({ field: 'showLastTopVariables[' + (that.ownAppiSelectedVariant - 1) + ']', msg: 'Zadaná hodnota je mimo povolený rozsah.' });
                            that.SaveAllowed = false;
                        }

                        var fieldLength = that.getVariablesLength(that.editorContent[(that.ownAppiSelectedVariant - 1)].replace(/<[^>]*>/g, ""));
                        var checkText = that.editorContent[(that.ownAppiSelectedVariant - 1)].replace(/<[^>]*>/g, "").replace(/\[([^\]]*)\]/g, "");
                        if (((checkText.length + fieldLength) > 70 && this.ShowLink[(that.ownAppiSelectedVariant - 1)]) || ((checkText.length + fieldLength) > 100 && !this.ShowLink[(that.ownAppiSelectedVariant - 1)])) {
                            that.errors.add({ field: 'editorContent[' + (that.ownAppiSelectedVariant - 1) + ']', msg: 'Text je příliš dlouhý' });
                            that.SaveAllowed = false;
                        }
                        //if (!that.checkVulgar('editorContent[' + (that.ownAppiSelectedVariant - 1) + ']', checkText, that.selectedLanguage)) {
                        //    that.SaveAllowed = false;
                        //}

                        that.targetUrl.forEach(function (targetUrlCheck, index) {
                            if (targetUrlCheck.length == 0 && that.ShowLink[index]) {
                                that.errors.add({ field: 'targetUrl[' + index + ']', msg: 'Url adresa nesmí být prázdná.' });
                                that.SaveAllowed = false;
                            }



                            if (targetUrlCheck.length > 0 && that.ShowLink[index]) {
                                if (!that.validUrl(targetUrlCheck)) {
                                    that.errors.add({ field: 'targetUrl[' + index + ']', msg: 'Url adresa nemá správný formát.' });
                                    that.SaveAllowed = false;
                                }
                            }
                        });

                        that.linkDescription.forEach(function (linkDescriptionCheck, index) {
                            if (linkDescriptionCheck.length == 0 && that.ShowLink[index]) {
                                that.errors.add({ field: 'linkDescription[' + index + ']', msg: 'Popisek nesmí být prázdný' });
                                that.SaveAllowed = false;
                            }

                            if (linkDescriptionCheck.length > 35 && that.ShowLink[index]) {
                                that.errors.add({ field: 'linkDescription[' + index + ']', msg: 'Popisek je příliš dlouhý.' });
                                that.SaveAllowed = false;
                            }
                            //if (!that.checkVulgar('linkDescription[' + index + ']', linkDescriptionCheck, that.selectedLanguage)) {
                            //    that.SaveAllowed = false;
                            //}
                        });

                        if (that.OwnAppi1Name === that.OwnAppi2Name || that.OwnAppi1Name === that.OwnAppi3Name || that.OwnAppi1Name === that.OwnAppi4Name || that.OwnAppi1Name === that.OwnAppi5Name ||
                            that.OwnAppi2Name === that.OwnAppi3Name || that.OwnAppi2Name === that.OwnAppi4Name || that.OwnAppi2Name === that.OwnAppi5Name ||
                            that.OwnAppi3Name === that.OwnAppi4Name || that.OwnAppi3Name === that.OwnAppi5Name ||
                            that.OwnAppi4Name === that.OwnAppi5Name) {

                            if (that.visibility1) {
                                that.errors.add({ field: 'OwnAppi1Name', msg: 'Název již existuje' });
                            } else if (that.visibility2) {
                                that.errors.add({ field: 'OwnAppi2Name', msg: 'Název již existuje' });
                            } else if (that.visibility3) {
                                that.errors.add({ field: 'OwnAppi3Name', msg: 'Název již existuje' });
                            } else if (that.visibility4) {
                                that.errors.add({ field: 'OwnAppi4Name', msg: 'Název již existuje' });
                            } else if (that.visibility5) {
                                that.errors.add({ field: 'OwnAppi5Name', msg: 'Název již existuje' });
                            }
                            that.SaveAllowed = false;
                        }
                    }
                    else {
                        that.SaveAllowed = false;
                    }
                });
            },
            Save() {
                var that = this;
                //console.log("barvy", that.Iconcolor1.hex, that.Iconcolor2.hex, that.Iconcolor3.hex, that.Iconcolor4.hex, that.Iconcolor5.hex)
                that.OwnAppiIcons.forEach((icon, index) => {
                    switch (index) {
                        case 0:
                            that.OwnAppiIcons[index] = icon.replace(icon.substr(icon.indexOf('fill') + 6, 7).toString(), that.Iconcolor1.hex); break;
                        case 1:
                            that.OwnAppiIcons[index] = icon.replace(icon.substr(icon.indexOf('fill') + 6, 7).toString(), that.Iconcolor2.hex); break;
                        case 2:
                            that.OwnAppiIcons[index] = icon.replace(icon.substr(icon.indexOf('fill') + 6, 7).toString(), that.Iconcolor3.hex); break;
                        case 3:
                            that.OwnAppiIcons[index] = icon.replace(icon.substr(icon.indexOf('fill') + 6, 7).toString(), that.Iconcolor4.hex); break;
                        case 4:
                            that.OwnAppiIcons[index] = icon.replace(icon.substr(icon.indexOf('fill') + 6, 7).toString(), that.Iconcolor5.hex); break;
                        default:
                            break;
                    }
                });
                //console.log("ikony", that.OwnAppiIcons);

                that.state.showLastTopVariables = that.showLastTopVariables;
                that.state.ownAppiActive = that.ownAppiActive;
                that.state.OwnAppi1Icon = that.OwnAppi1Icon; that.state.OwnAppi2Icon = that.OwnAppi2Icon; that.state.OwnAppi3Icon = that.OwnAppi3Icon; that.state.OwnAppi4Icon = that.OwnAppi4Icon; that.state.OwnAppi5Icon = that.OwnAppi5Icon;
                that.state.OwnAppi1Name = that.OwnAppi1Name; that.state.OwnAppi2Name = that.OwnAppi2Name; that.state.OwnAppi3Name = that.OwnAppi3Name; that.state.OwnAppi4Name = that.OwnAppi4Name; that.state.OwnAppi5Name = that.OwnAppi5Name;
                that.state.ShowLink = that.ShowLink;
                that.state.ShowLinkBtn = that.ShowLinkBtn;
                that.state.ShowLinkNewWin = that.ShowLinkNewWin;
                that.state.CycleShowing = that.CycleShowing;
                that.state.Iconcolor1 = that.Iconcolor1.hex; that.state.Iconcolor2 = that.Iconcolor2.hex; that.state.Iconcolor3 = that.Iconcolor3.hex; that.state.Iconcolor4 = that.Iconcolor4.hex; that.state.Iconcolor5 = that.Iconcolor5.hex;
                that.state.IconcolorBtn1 = that.IconcolorBtn1.hex; that.state.IconcolorBtn2 = that.IconcolorBtn2.hex; that.state.IconcolorBtn3 = that.IconcolorBtn3.hex; that.state.IconcolorBtn4 = that.IconcolorBtn4.hex; that.state.IconcolorBtn5 = that.IconcolorBtn5.hex;
                that.state.IconcolorBckBtn1 = that.IconcolorBckBtn1.hex; that.state.IconcolorBckBtn2 = that.IconcolorBckBtn2.hex; that.state.IconcolorBckBtn3 = that.IconcolorBckBtn3.hex; that.state.IconcolorBckBtn4 = that.IconcolorBckBtn4.hex; that.state.IconcolorBckBtn5 = that.IconcolorBckBtn5.hex;
                switch (this.selectedLanguage) {
                    case "cs":
                        that.state.editorContentCz = that.editorContent;
                        that.state.linkDescriptionCz = that.linkDescription;
                        break;
                    case "sk":
                        that.state.editorContentSk = that.editorContent;
                        that.state.linkDescriptionSk = that.linkDescription;
                        break;
                    case "en":
                        that.state.editorContentEn = that.editorContent;
                        that.state.linkDescriptionEn = that.linkDescription;
                        break;
                }
                that.state.zoomIcon = that.zoomIcon;
                that.state.horizontalIcon = that.horizontalIcon;
                that.state.verticalIcon = that.verticalIcon;
                that.state.targetUrl = that.targetUrl;
                that.$store.state.OwnAppiIcons = that.OwnAppiIcons;

                that.changeVisibility(0, false);

                document.querySelector("#ownAppi").click();
                that.$refs.closeBtn.click();//that.showAlert("Saved");
              
            },
			showAlert(val) {
				const options = {title: 'Info', size: 'sm'}
				this.$dialogs.alert(val, options)
					.then(res => {
				});
            },
            GetCampaignData() {
                return new Promise((resolve, reject) => {
                    return axios.post('https://appi.app.cz:444/get_campaigns', {
                        session: Vue.cookie.get('session'),
                        uuid: this.userUid
                    }).then((dataCampaigns) => {
                        resolve(dataCampaigns.data);
                    }).catch((error) => {
                        reject(error)
                    })
                });
            },
            GetParams() {
                return new Promise((resolve, reject) => {
                    return axios.post('https://appi.app.cz:444/getParams', {
                        session: Vue.cookie.get('session'),
                        uuid: this.userUid
                    }).then((params) => {
                        resolve(params.data);
                    }).catch((error) => {
                        reject(error)
                    })
                });
            }
        },
        watch: {
            '$store.state.selectedLanguage': function () {
                this.selectedLanguage = this.$store.state.selectedLanguage;
                this.linkDescription = JSON.parse(this.translateAppi('ownLinkDescriptions', this.selectedLanguage));
                this.editorContent = JSON.parse(this.translateAppi('ownEditorContents', this.selectedLanguage));
                this.validateFields();
            },
            '$store.state.SelectedMessages': function () {
                this.SelectedMessages = this.$store.state.SelectedMessages;
            }
        },
        created() {
            this.userUid = this.$store.state.AdminModule.adminUserKey;
            var that = this;
        
            this.GetParams().then(params => {
                params.params.forEach(function (param) {
                    that.paramList.push('["'+param.parameter+'",'+ param.paramMaxLength+']');
                });
            });

            if (Vue.cookie.get('EditCampaignID') != 'null' && Vue.cookie.get('EditCampaignID') != undefined) {
                var selectedCampaignID = Vue.cookie.get('EditCampaignID');
                this.GetCampaignData().then(dataCampaigns => {
                    dataCampaigns.campaigns.forEach(function (campaign) {
                        if (campaign.campaignID == selectedCampaignID) {
                            that.tmpIconcolor1 = campaign.OwnAppi.Iconcolor1; that.tmpIconcolor2 = campaign.OwnAppi.Iconcolor2; that.tmpIconcolor3 = campaign.OwnAppi.Iconcolor3; that.tmpIconcolor4 = campaign.OwnAppi.Iconcolor4; that.tmpIconcolor5 = campaign.OwnAppi.Iconcolor5;
                            that.tmpIconcolorBtn1 = campaign.OwnAppi.IconcolorBtn1; that.tmpIconcolorBtn2 = campaign.OwnAppi.IconcolorBtn2; that.tmpIconcolorBtn3 = campaign.OwnAppi.IconcolorBtn3; that.tmpIconcolorBtn4 = campaign.OwnAppi.IconcolorBtn4; that.tmpIconcolorBtn5 = campaign.OwnAppi.IconcolorBtn5;
                            that.tmpIconcolorBckBtn1 = campaign.OwnAppi.IconcolorBckBtn1; that.tmpIconcolorBckBtn2 = campaign.OwnAppi.IconcolorBckBtn2; that.tmpIconcolorBckBtn3 = campaign.OwnAppi.IconcolorBckBtn3; that.tmpIconcolorBckBtn4 = campaign.OwnAppi.IconcolorBckBtn4; that.tmpIconcolorBckBtn5 = campaign.OwnAppi.IconcolorBckBtn5;

                            that.Iconcolor1.hex = campaign.OwnAppi.Iconcolor1; that.Iconcolor2.hex = campaign.OwnAppi.Iconcolor2; that.Iconcolor3.hex = campaign.OwnAppi.Iconcolor3; that.Iconcolor4.hex = campaign.OwnAppi.Iconcolor4; that.Iconcolor5.hex = campaign.OwnAppi.Iconcolor5;
                            that.IconcolorBtn1.hex = campaign.OwnAppi.IconcolorBtn1; that.IconcolorBtn2.hex = campaign.OwnAppi.IconcolorBtn2; that.IconcolorBtn3.hex = campaign.OwnAppi.IconcolorBtn3; that.IconcolorBtn4.hex = campaign.OwnAppi.IconcolorBtn4; that.IconcolorBtn5.hex = campaign.OwnAppi.IconcolorBtn5;
                            that.IconcolorBckBtn1.hex = campaign.OwnAppi.IconcolorBckBtn1; that.IconcolorBckBtn2.hex = campaign.OwnAppi.IconcolorBckBtn2; that.IconcolorBckBtn3.hex = campaign.OwnAppi.IconcolorBckBtn3; that.IconcolorBckBtn4.hex = campaign.OwnAppi.IconcolorBckBtn4; that.IconcolorBckBtn5.hex = campaign.OwnAppi.IconcolorBckBtn5;
                            that.OwnAppi1Name = campaign.OwnAppi.OwnAppi1Name; that.OwnAppi2Name = campaign.OwnAppi.OwnAppi2Name; that.OwnAppi3Name = campaign.OwnAppi.OwnAppi3Name; that.OwnAppi4Name = campaign.OwnAppi.OwnAppi4Name; that.OwnAppi5Name = campaign.OwnAppi.OwnAppi5Name;
                            that.OwnAppi1Icon = campaign.OwnAppi.OwnAppi1Icon; that.OwnAppi2Icon = campaign.OwnAppi.OwnAppi2Icon; that.OwnAppi3Icon = campaign.OwnAppi.OwnAppi3Icon; that.OwnAppi4Icon = campaign.OwnAppi.OwnAppi4Icon; that.OwnAppi5Icon = campaign.OwnAppi.OwnAppi5Icon;
                            that.ShowLink = campaign.OwnAppi.ShowLink;
                            that.ShowLinkNewWin = campaign.OwnAppi.ShowLinkNewWin;
                            that.ShowLinkBtn = campaign.OwnAppi.ShowLinkBtn;
                            that.CycleShowing = campaign.OwnAppi.CycleShowing;
                            that.ownAppiActive = campaign.OwnAppi.ownAppiActive;
                            that.editorContent = (campaign.OwnAppi.editorContent[0] != []) ? campaign.OwnAppi.editorContent : (that.selectedLanguage == 'en') ? that.$store.state.OwnAppi.editorContentEn : (that.selectedLanguage == 'sk') ? that.$store.state.OwnAppi.editorContentSk : that.$store.state.OwnAppi.editorContentCz;
                            that.zoomIcon = campaign.OwnAppi.zoomIcon;
                            that.horizontalIcon = campaign.OwnAppi.horizontalIcon;
                            that.verticalIcon = campaign.OwnAppi.verticalIcon;
                            that.targetUrl = campaign.OwnAppi.targetUrl;
                            that.linkDescription = (campaign.OwnAppi.linkDescription[0] != []) ? campaign.OwnAppi.linkDescription : (that.selectedLanguage == 'en') ? that.$store.state.OwnAppi.linkDescriptionEn : (that.selectedLanguage == 'sk') ? that.$store.state.OwnAppi.linkDescriptionSk : that.$store.state.OwnAppi.linkDescriptionCz;
                            that.OwnAppiIcons = campaign.OwnAppiIcons;
                            that.showLastTopVariables = campaign.OwnAppi.showLastTopVariables;

                            that.$store.state.OwnAppi = campaign.OwnAppi;
                            switch (that.selectedLanguage) {
                                case "cs":
                                    that.$store.state.OwnAppi.editorContentCz = campaign.OwnAppi.editorContent;
                                    that.$store.state.OwnAppi.linkDescriptionCz = campaign.OwnAppi.linkDescription;
                                    break;
                                case "sk":
                                    that.$store.state.OwnAppi.editorContentSk = campaign.OwnAppi.editorContent;
                                    that.$store.state.OwnAppi.linkDescriptionSk = campaign.OwnAppi.linkDescription;
                                    break;
                                case "en":
                                    that.$store.state.OwnAppi.editorContentEn = campaign.OwnAppi.editorContent;
                                    that.$store.state.OwnAppi.linkDescriptionEn = campaign.OwnAppi.linkDescription;
                                    break;
                            }

                            setTimeout(() => {
                                that.changeOwnAppiSelectedVariant(2); 
                            }, 50);
                            setTimeout(() => {
                                that.changeOwnAppiSelectedVariant(1);
                            }, 100);
                          
                        }
                    })
                  
                })
            }
        }
       

    }

</script>

