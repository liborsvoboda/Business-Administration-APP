<template>

    <div>
        <div class="container-fluid wizard_campaign_container">
            <div class="row">
                <div class="col-md-12 wizard_campaign_col">
                    <ul class="wizard_campaign">
                        <li class="list_group_button" v-on:click="goToStep('Step1')" v-bind:class="{ 'cursor_default': (CampaignName.length === 0) }">
                            <div class="d-flex justify-content-center align-items-center">
                                <div class="wizard_step_number d-flex align-items-center justify-content-center">1</div>
                                <div class="wizard_step_desc">Výběr</div>
                            </div>
                        </li>
                        <li class="wizard_step_active">
                            <div class="d-flex justify-content-center align-items-center">
                                <div class="wizard_step_number d-flex align-items-center justify-content-center">2</div>
                                <div class="wizard_step_desc">Spárování</div>
                            </div>
                        </li>
                        <li class="list_group_button" v-on:click="goToStep('Step3')" v-bind:class="{ 'cursor_default': (CampaignName.length === 0) }">
                            <div class="d-flex justify-content-center align-items-center">
                                <div class="wizard_step_number d-flex align-items-center justify-content-center">3</div>
                                <div class="wizard_step_desc">Zobrazení</div>
                            </div>
                        </li>
                        <li class="list_group_button" v-on:click="goToStep('Step4')" v-bind:class="{ 'cursor_default': (CampaignName.length === 0) }">
                            <div class="d-flex justify-content-center align-items-center">
                                <div class="wizard_step_number d-flex align-items-center justify-content-center">4</div>
                                <div class="wizard_step_desc">Nastavení</div>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="container new_campaign_container_wrap">
            <div class="row justify-content-center">
                <div class="d-inline-flex">
                    <ul class="capturedUrl_campaign col-md-12 justify-content-center align-items-center">
                        <li v-if="SelectedMessages.indexOf('LastEventsOrders') > -1" v-on:click="goToSelected('LastEventsOrders')" v-bind:class="{ 'cursor_default': (CapturedUrlsObjIn[0].length === 0 || CampaignName.length === 0) }" class="align-items-center pl-3 pr-3 list_group_button" style="display: inline-flex;background-color: transparent">
                            <span>
                                <img src="/images/product/orders_grey.svg" v-on:click="goToSelected('LastEventsOrders')" v-bind:class="{ 'cursor_default': (CapturedUrlsObjIn[0].length === 0 || CampaignName.length === 0) }" class="svg_img_60 list_group_button" style="margin-right:10px;" />
                            </span>
                            <span class="with_100_points" style="vertical-align: top;">
                                <div class="" style="vertical-align: top;font-weight: bold;">
                                    <span class="sub_title wizard_step_desc">Poslední objednávky</span>
                                </div>
                            </span>
                        </li>

                        <li v-if="SelectedMessages.indexOf('LastEventsRegistrations') > -1" v-on:click="goToSelected('LastEventsRegistrations')" v-bind:class="{ 'cursor_default': (CapturedUrlsRegIn[0].length === 0 || CampaignName.length === 0) }" class="align-items-center pl-3 pr-3 list_group_button" style="display: inline-flex;background-color: transparent">
                            <span>
                                <img src="/images/product/registration_grey.svg" v-on:click="goToSelected('LastEventsRegistrations')" v-bind:class="{ 'cursor_default': (CapturedUrlsRegIn[0].length === 0 || CampaignName.length === 0) }" class="svg_img_60 list_group_button" style="margin-right:10px;" />
                            </span>
                            <span class="with_100_points" style="vertical-align: top;">
                                <div class="" style="vertical-align: top;font-weight: bold;">
                                    <span class="sub_title wizard_step_desc">Poslední registrace</span>
                                </div>
                            </span>
                        </li>

                        <li v-if="SelectedMessages.indexOf('VisitCount') > -1" v-on:click="goToSelected('VisitCount')" class="align-items-center pl-3 pr-3" style="display: inline-flex;background-color: transparent">
                            <span>
                                <img src="/images/product/visits_grey.svg" v-on:click="goToSelected('VisitCount')" class="svg_img_60" style="margin-right:10px;cursor:default;" />
                            </span>
                            <span class="with_100_points" style="vertical-align: top;">
                                <div class="" style="vertical-align: top;font-weight: bold;">
                                    <span class="sub_title wizard_step_desc">Aktuální návštěvníci</span>
                                </div>
                            </span>
                        </li>

                        <li v-if="SelectedMessages.indexOf('Statistics') > -1" v-on:click="goToSelected('Statistics')" v-bind:class="{ 'cursor_default': (CapturedUrlsStatIn[0].length === 0 || CampaignName.length === 0) }" class="align-items-center pl-3 pr-3 list_group_button" style="display: inline-flex;background-color: transparent">
                            <span>
                                <img src="/images/product/statistics_grey.svg" v-on:click="goToSelected('Statistics')" v-bind:class="{ 'cursor_default': (CapturedUrlsStatIn[0].length === 0 || CampaignName.length === 0) }" class="svg_img_60 list_group_button" style="margin-right:10px;" />
                            </span>
                            <span class="with_100_points" style="vertical-align: top;">
                                <div class="" style="vertical-align: top;font-weight: bold;">
                                    <span class="sub_title wizard_step_desc">Souhrnné statistiky</span>
                                </div>
                            </span>
                        </li>

                        <li v-if="SelectedMessages.indexOf('Heureka') > -1" v-on:click="goToSelected('Heureka')" v-bind:class="{ 'cursor_default': (heurekaAPIkey === 'none' || CampaignName.length === 0) }" class="align-items-center pl-3 pr-3 list_group_button" style="display: inline-flex;background-color: transparent">
                            <span>
                                <img src="/images/product/reviews_grey.svg" v-on:click="goToSelected('Heureka')" v-bind:class="{ 'cursor_default': (heurekaAPIkey === 'none' || CampaignName.length === 0) }" class="svg_img_60 list_group_button" style="margin-right:10px;" />
                            </span>
                            <span class="with_100_points" style="vertical-align: top;">
                                <div class="" style="vertical-align: top;font-weight: bold;">
                                    <span class="sub_title wizard_step_desc">Recenze Heuréka</span>
                                </div>
                            </span>
                        </li>

                        <li v-if="SelectedMessages.indexOf('Zbozi') > -1" v-on:click="goToSelected('Zbozi')" v-bind:class="{ 'cursor_default': (zboziAPIkey === 'none' || CampaignName.length === 0) }" class="align-items-center pl-3 pr-3 list_group_button" style="display: inline-flex;background-color: transparent">
                            <span>
                                <img src="/images/product/zbozi_grey.svg" v-on:click="goToSelected('Zbozi')" v-bind:class="{ 'cursor_default': (zboziAPIkey === 'none' || CampaignName.length === 0) }" class="svg_img_60 list_group_button" style="margin-right:10px;cursor:default;width: 70px;" />
                            </span>
                            <span class="with_100_points" style="vertical-align: top;">
                                <div class="" style="vertical-align: top;font-weight: bold;">
                                    <span class="sub_title wizard_step_desc">Recenze Zboží.cz</span>
                                </div>
                            </span>
                        </li>

                        <li v-if="SelectedMessages.indexOf('OwnAppi') > -1" class="align-items-center pl-3 pr-3 list_group_button" style="display: inline-flex;background-color: transparent">
                            <span>
                                <img src="/images/product/offer.svg" class="svg_img_60 list_group_button" style="margin-right:10px;cursor:default;" />
                            </span>
                            <span class="with_100_points" style="vertical-align: top;">
                                <div class="" style="vertical-align: top;font-weight: bold;">
                                    <span class="sub_title ownAppi_color">TOP nabídky</span>
                                </div>
                            </span>
                        </li>

                    </ul>
                </div>
                <div class="col-md-12">
                    <div class="row justify-content-md-center">
                        <div class="col-md-8">
                            <div class="list-group mt-2 pt-5 shadow-sm">
                                <div class="list-group-item group_item_ownAppi">
                                    <div class="new_campaign_tile_group_item ownAppi_color d-flex align-items-center">
                                        <span class="width_100">Přehled aktivních TOP nabídek</span>
                                    </div>
                                </div>


                                <div class="list-group-item pb-5">
                                    <div class="align-items-center pb-5 pt-3 d-flex">
                                        <span class="bold " style="width:80px;color:inherit">Zobrazit: </span>

                                        <div class="btn-group btn-group-toggle" data-toggle="buttons">
                                            <label v-for="value,index in ownAppi.ownAppiActive"
                                                    class=" btn btn btn-outline-primary mycolor"
                                                    v-bind:class="{'active': (ownAppiSelectedVariant -1) == index,
                                                    'd-none': !value
                                                    }" v-if="value"
                                                v-on:click="changeOwnAppiSelectedVariant(index+1);">
                                                <input type="radio" name="options" autocomplete="off"
                                                        :checked="ownAppiSelectedVariant == index">
                                                <span v-if="index == 0" v-text="ownAppi.OwnAppi1Name"></span>
                                                <span v-if="index == 1" v-text="ownAppi.OwnAppi2Name"></span>
                                                <span v-if="index == 2" v-text="ownAppi.OwnAppi3Name"></span>
                                                <span v-if="index == 3" v-text="ownAppi.OwnAppi4Name"></span>
                                                <span v-if="index == 4" v-text="ownAppi.OwnAppi5Name"></span>
                                            </label>
                                        </div>
                                    </div>
                                    <div class="text-center">
                                        <div class="Appi_bubble shadow noselect text-left">
                                            <span class="ownAppiCircle" v-bind:style="{'border-color': (ownAppiSelectedVariant == 1)?ownAppi.Iconcolor1:(ownAppiSelectedVariant == 2)?ownAppi.Iconcolor2:(ownAppiSelectedVariant == 3)?ownAppi.Iconcolor3:(ownAppiSelectedVariant == 4)?ownAppi.Iconcolor4:ownAppi.Iconcolor5}" title="TOP nabídky" alt="TOP nabídky"></span>
                                            <span class="ownNotitifyIconCenter" v-bind:style="{'padding-left': ownAppi.horizontalIcon[(ownAppiSelectedVariant-1)]+'px','padding-top': ownAppi.verticalIcon[(ownAppiSelectedVariant-1)]+'px'}">

                                                <Information-icon id="Information" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon =='Information') || (ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon =='Information') || (ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon =='Information') || (ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon =='Information') || (ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon =='Information'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></Information-icon>
                                                <BellOutline-icon id="BellOutline" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'BellOutline') || (ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'BellOutline') || (ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'BellOutline') || (ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'BellOutline') || (ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'BellOutline'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></BellOutline-icon>
                                                <BellRingOutline-icon id="BellRingOutline" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'BellRingOutline') || (ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'BellRingOutline') || (ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'BellRingOutline') || (ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'BellRingOutline') || (ownAppiSelectedVariant == 2 && ownAppi.OwnAppi5Icon == 'BellRingOutline'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></BellRingOutline-icon>
                                                <Sale-icon id="Sale" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'Sale')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'Sale')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'Sale')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'Sale')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'Sale'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></Sale-icon>
                                                <Truck-icon id="Truck" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'Truck')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'Truck')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'Truck')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'Truck')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'Truck'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></Truck-icon>
                                                <TagHeart-icon id="TagHeart" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'TagHeart')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'TagHeart')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'TagHeart')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'TagHeart')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'TagHeart'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></TagHeart-icon>
                                                <TooltipAccount-icon id="TooltipAccount" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'TooltipAccount')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'TooltipAccount')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'TooltipAccount')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'TooltipAccount')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'TooltipAccount'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></TooltipAccount-icon>
                                                <AccountPlusOutline-icon id="AccountPlusOutline" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'AccountPlusOutline')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'AccountPlusOutline')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'AccountPlusOutline')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'AccountPlusOutline')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'AccountPlusOutline'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></AccountPlusOutline-icon>
                                                <StarOutline-icon id="StarOutline" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'StarOutline')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'StarOutline')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'StarOutline')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'StarOutline')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'StarOutline'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></StarOutline-icon>
                                                <WalletGiftcard-icon id="WalletGiftcard" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'WalletGiftcard')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'WalletGiftcard')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'WalletGiftcard')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'WalletGiftcard')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'WalletGiftcard'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></WalletGiftcard-icon>
                                                <GestureTap-icon id="GestureTap" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'GestureTap')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'GestureTap')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'GestureTap')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'GestureTap')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'GestureTap'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></GestureTap-icon>
                                                <Ticket-icon id="Ticket" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'Ticket')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'Ticket')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'Ticket')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'Ticket')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'Ticket'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></Ticket-icon>
                                                <EyeOutline-icon id="EyeOutline" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'EyeOutline')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'EyeOutline')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'EyeOutline')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'EyeOutline')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'EyeOutline'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></EyeOutline-icon>
                                                <ThumbUpOutline-icon id="ThumbUpOutline" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'ThumbUpOutline')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'ThumbUpOutline')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'ThumbUpOutline')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'ThumbUpOutline')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'ThumbUpOutline'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></ThumbUpOutline-icon>
                                                <AlertCircle-icon id="AlertCircle" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'AlertCircle')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'AlertCircle')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'AlertCircle')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'AlertCircle')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'AlertCircle'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></AlertCircle-icon>
                                                <MessageText-icon id="MessageText" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'MessageText')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'MessageText')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'MessageText')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'MessageText')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'MessageText'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></MessageText-icon>
                                                <EmailOutline-icon id="EmailOutline" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'EmailOutline')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'EmailOutline')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'EmailOutline')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'EmailOutline')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'EmailOutline'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></EmailOutline-icon>
                                                <LightbulbOnOutline-icon id="LightbulbOnOutline" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'LightbulbOnOutline')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'LightbulbOnOutline')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'LightbulbOnOutline')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'LightbulbOnOutline')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'LightbulbOnOutline'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></LightbulbOnOutline-icon>
                                                <CakeVariant-icon id="CakeVariant" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'CakeVariant')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'CakeVariant')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'CakeVariant')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'CakeVariant')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'CakeVariant'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></CakeVariant-icon>
                                                <Facebook-icon id="Facebook" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'Facebook')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'Facebook')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'Facebook')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'Facebook')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'Facebook'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></Facebook-icon>
                                                <FacebookBox-icon id="FacebookBox" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'FacebookBox')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'FacebookBox')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'FacebookBox')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'FacebookBox')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'FacebookBox'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></FacebookBox-icon>
                                                <FacebookMessenger-icon id="FacebookMessenger" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'FacebookMessenger')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'FacebookMessenger')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'FacebookMessenger')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'FacebookMessenger')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'FacebookMessenger'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></FacebookMessenger-icon>
                                                <GooglePlusBox-icon id="GooglePlusBox" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'GooglePlusBox')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'GooglePlusBox')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'GooglePlusBox')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'GooglePlusBox')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'GooglePlusBox'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></GooglePlusBox-icon>
                                                <LinkedinBox-icon id="LinkedinBox" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'LinkedinBox')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'LinkedinBox')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'LinkedinBox')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'LinkedinBox')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'LinkedinBox'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></LinkedinBox-icon>
                                                <TwitterBox-icon id="TwitterBox" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'TwitterBox')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'TwitterBox')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'TwitterBox')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'TwitterBox')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'TwitterBox'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></TwitterBox-icon>
                                                <Youtube-icon id="Youtube" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'Youtube')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'Youtube')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'Youtube')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'Youtube')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'Youtube'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></Youtube-icon>
                                                <Instagram-icon id="Instagram" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'Instagram')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'Instagram')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'Instagram')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'Instagram')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'Instagram'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></Instagram-icon>
                                                <FoodForkDrink-icon id="FoodForkDrink" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'FoodForkDrink')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'FoodForkDrink')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'FoodForkDrink')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'FoodForkDrink')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'FoodForkDrink'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></FoodForkDrink-icon>
                                                <EmoticonHappyOutline-icon id="EmoticonHappyOutline" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'EmoticonHappyOutline')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'EmoticonHappyOutline')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'EmoticonHappyOutline')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'EmoticonHappyOutline')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'EmoticonHappyOutline'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></EmoticonHappyOutline-icon>
                                                <Emoticon-icon id="Emoticon" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'Emoticon')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'Emoticon')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'Emoticon')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'Emoticon')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'Emoticon'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></Emoticon-icon>
                                                <EmoticonOutline-icon id="EmoticonOutline" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'EmoticonOutline')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'EmoticonOutline')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'EmoticonOutline')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'EmoticonOutline')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'EmoticonOutline'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></EmoticonOutline-icon>
                                                <Cupcake-icon id="Cupcake" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'Cupcake')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'Cupcake')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'Cupcake')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'Cupcake')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'Cupcake'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></Cupcake-icon>
                                                <CheckboxMarkedCircle-icon id="CheckboxMarkedCircle" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'CheckboxMarkedCircle')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'CheckboxMarkedCircle')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'CheckboxMarkedCircle')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'CheckboxMarkedCircle')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'CheckboxMarkedCircle'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></CheckboxMarkedCircle-icon>
                                                <GlassWine-icon id="GlassWine" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'GlassWine')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'GlassWine')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'GlassWine')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'GlassWine')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'GlassWine'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></GlassWine-icon>
                                                <ArrowRightCircle-icon id="ArrowRightCircle" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'ArrowRightCircle')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'ArrowRightCircle')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'ArrowRightCircle')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'ArrowRightCircle')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'ArrowRightCircle'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></ArrowRightCircle-icon>
                                                <ArrowRightCircleOutline-icon id="ArrowRightCircleOutline" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'ArrowRightCircleOutline')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'ArrowRightCircleOutline')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'ArrowRightCircleOutline')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'ArrowRightCircleOutline')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'ArrowRightCircleOutline'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></ArrowRightCircleOutline-icon>
                                                <ChevronDoubleRight-icon id="ChevronDoubleRight" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'ChevronDoubleRight')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'ChevronDoubleRight')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'ChevronDoubleRight')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'ChevronDoubleRight')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'ChevronDoubleRight'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></ChevronDoubleRight-icon>
                                                <GlassMugVariant-icon id="GlassMugVariant" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'GlassMugVariant')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'GlassMugVariant')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'GlassMugVariant')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'GlassMugVariant')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'GlassMugVariant'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></GlassMugVariant-icon>
                                                <ChevronRightCircle-icon id="ChevronRightCircle" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'ChevronRightCircle')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'ChevronRightCircle')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'ChevronRightCircle')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'ChevronRightCircle')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'ChevronRightCircle'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></ChevronRightCircle-icon>
                                                <BagChecked-icon id="BagChecked" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'BagChecked')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'BagChecked')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'BagChecked')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'BagChecked')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'BagChecked'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></BagChecked-icon>
                                                <Heart-icon id="Heart" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'Heart')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'Heart')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'Heart')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'Heart')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'Heart'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></Heart-icon>
                                                <HeartOutline-icon id="HeartOutline" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'HeartOutline')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'HeartOutline')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'HeartOutline')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'HeartOutline')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'HeartOutline'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></HeartOutline-icon>
                                                <ChatAlert-icon id="ChatAlert" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'ChatAlert')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'ChatAlert')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'ChatAlert')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'ChatAlert')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'ChatAlert'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></ChatAlert-icon>
                                                <CommentAlert-icon id="CommentAlert" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'CommentAlert')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'CommentAlert')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'CommentAlert')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'CommentAlert')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'CommentAlert'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></CommentAlert-icon>
                                                <TooltipText-icon id="TooltipText" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'TooltipText')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'TooltipText')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'TooltipText')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'TooltipText')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'TooltipText'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></TooltipText-icon>
                                                <CarHatchback-icon id="CarHatchback" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'CarHatchback')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'CarHatchback')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'CarHatchback')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'CarHatchback')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'CarHatchback'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></CarHatchback-icon>
                                                <AvTimer-icon id="AvTimer" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'AvTimer')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'AvTimer')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'AvTimer')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'AvTimer')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'AvTimer'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></AvTimer-icon>
                                                <ClockFast-icon id="ClockFast" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'ClockFast')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'ClockFast')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'ClockFast')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'ClockFast')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'ClockFast'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></ClockFast-icon>
                                                <TimerSand-icon id="TimerSand" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'TimerSand')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'TimerSand')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'TimerSand')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'TimerSand')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'TimerSand'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></TimerSand-icon>
                                                <Bike-icon id="Bike" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'Bike')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'Bike')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'Bike')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'Bike')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'Bike'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></Bike-icon>
                                                <Brain-icon id="Brain" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'Brain')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'Brain')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'Brain')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'Brain')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'Brain'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></Brain-icon>
                                                <Face-icon id="Face" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'Face')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'Face')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'Face')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'Face')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'Face'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></Face-icon>
                                                <FaceWoman-icon id="FaceWoman" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'FaceWoman')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'FaceWoman')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'FaceWoman')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'FaceWoman')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'FaceWoman'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></FaceWoman-icon>
                                                <GiftOutline-icon id="GiftOutline" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'GiftOutline')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'GiftOutline')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'GiftOutline')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'GiftOutline')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'GiftOutline'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></GiftOutline-icon>
                                                <BabyCarriage-icon id="BabyCarriage" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'BabyCarriage')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'BabyCarriage')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'BabyCarriage')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'BabyCarriage')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'BabyCarriage'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></BabyCarriage-icon>
                                                <Bone-icon id="Bone" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'Bone')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'Bone')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'Bone')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'Bone')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'Bone'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></Bone-icon>
                                                <Paw-icon id="Paw" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'Paw')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'Paw')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'Paw')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'Paw')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'Paw'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></Paw-icon>
                                                <Flower-icon id="Flower" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'Flower')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'Flower')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'Flower')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'Flower')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'Flower'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></Flower-icon>
                                                <Sprout-icon id="Sprout" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'Sprout')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'Sprout')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'Sprout')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'Sprout')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'Sprout'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></Sprout-icon>
                                                <ArmFlexOutline-icon id="ArmFlexOutline" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'ArmFlexOutline')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'ArmFlexOutline')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'ArmFlexOutline')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'ArmFlexOutline')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'ArmFlexOutline'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></ArmFlexOutline-icon>
                                                <MonitorCellphone-icon id="MonitorCellphone" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'MonitorCellphone')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'MonitorCellphone')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'MonitorCellphone')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'MonitorCellphone')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'MonitorCellphone'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></MonitorCellphone-icon>
                                                <CellphoneBasic-icon id="CellphoneBasic" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'CellphoneBasic')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'CellphoneBasic')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'CellphoneBasic')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'CellphoneBasic')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'CellphoneBasic'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></CellphoneBasic-icon>
                                                <ChatProcessing-icon id="ChatProcessing" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'ChatProcessing')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'ChatProcessing')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'ChatProcessing')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'ChatProcessing')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'ChatProcessing'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></ChatProcessing-icon>
                                                <CameraWirelessOutline-icon id="CameraWirelessOutline" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'CameraWirelessOutline')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'CameraWirelessOutline')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'CameraWirelessOutline')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'CameraWirelessOutline')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'CameraWirelessOutline'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></CameraWirelessOutline-icon>
                                                <ChefHat-icon id="ChefHat" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'ChefHat')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'ChefHat')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'ChefHat')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'ChefHat')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'ChefHat'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></ChefHat-icon>
                                                <Crown-icon id="Crown" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'Crown')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'Crown')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'Crown')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'Crown')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'Crown'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></Crown-icon>
                                                <DominoMask-icon id="DominoMask" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'DominoMask')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'DominoMask')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'DominoMask')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'DominoMask')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'DominoMask'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></DominoMask-icon>
                                                <Ring-icon id="Ring" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'Ring')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'Ring')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'Ring')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'Ring')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'Ring'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></Ring-icon>
                                                <ShoeHeel-icon id="ShoeHeel" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'ShoeHeel')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'ShoeHeel')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'ShoeHeel')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'ShoeHeel')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'ShoeHeel'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></ShoeHeel-icon>
                                                <TshirtCrewOutline-icon id="TshirtCrewOutline" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'TshirtCrewOutline')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'TshirtCrewOutline')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'TshirtCrewOutline')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'TshirtCrewOutline')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'TshirtCrewOutline'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></TshirtCrewOutline-icon>
                                                <Cash100-icon id="Cash100" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'Cash100')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'Cash100')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'Cash100')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'Cash100')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'Cash100'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></Cash100-icon>
                                                <PigVariant-icon id="PigVariant" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'PigVariant')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'PigVariant')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'PigVariant')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'PigVariant')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'PigVariant'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></PigVariant-icon>
                                                <Anchor-icon id="Anchor" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'Anchor')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'Anchor')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'Anchor')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'Anchor')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'Anchor'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></Anchor-icon>
                                                <Charity-icon id="Charity" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'Charity')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'Charity')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'Charity')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'Charity')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'Charity'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></Charity-icon>
                                                <Lifebuoy-icon id="Lifebuoy" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'Lifebuoy')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'Lifebuoy')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'Lifebuoy')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'Lifebuoy')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'Lifebuoy'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></Lifebuoy-icon>
                                                <HeartPulse-icon id="HeartPulse" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'HeartPulse')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'HeartPulse')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'HeartPulse')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'HeartPulse')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'HeartPulse'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></HeartPulse-icon>
                                                <MedicalBag-icon id="MedicalBag" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'MedicalBag')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'MedicalBag')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'MedicalBag')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'MedicalBag')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'MedicalBag'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></MedicalBag-icon>
                                                <Fire-icon id="Fire" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'Fire')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'Fire')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'Fire')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'Fire')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'Fire'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></Fire-icon>
                                                <Smoking-icon id="Smoking" v-if="((ownAppiSelectedVariant == 1 && ownAppi.OwnAppi1Icon == 'Smoking')||(ownAppiSelectedVariant == 2 && ownAppi.OwnAppi2Icon == 'Smoking')||(ownAppiSelectedVariant == 3 && ownAppi.OwnAppi3Icon == 'Smoking')||(ownAppiSelectedVariant == 4 && ownAppi.OwnAppi4Icon == 'Smoking')||(ownAppiSelectedVariant == 5 && ownAppi.OwnAppi5Icon == 'Smoking'))" v-bind:width=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)] v-bind:height=ownAppi.zoomIcon[(ownAppiSelectedVariant-1)]></Smoking-icon>

                                            </span>

                                            <span id="messageData" style="vertical-align: top;padding-left: 30px;margin-top: 0px;font-size: 15px;min-height: 68px;min-width: 303px;max-height: 68px;max-width: 303px;">
                                                <span class="width_100" style="vertical-align: top;" v-html="(selectedLanguage == 'en') ? ownAppi.editorContentEn[(ownAppiSelectedVariant-1)].split('<p>').join('<div>').split('</p>').join('</div>') : (selectedLanguage == 'sk') ? ownAppi.editorContentSk[(ownAppiSelectedVariant-1)].split('<p>').join('<div>').split('</p>').join('</div>') :  ownAppi.editorContentCz[(ownAppiSelectedVariant-1)].split('<p>').join('<div>').split('</p>').join('</div>')">
                                                </span>

                                                <div v-if="ownAppi.ShowLink[(ownAppiSelectedVariant - 1)] && !ownAppi.ShowLinkBtn[(ownAppiSelectedVariant - 1)]">
                                                    <a class="bubbleLink" v-bind:href="ownAppi.targetUrl[(ownAppiSelectedVariant-1)]" v-bind:style="{'color': (ownAppiSelectedVariant == 1)?ownAppi.IconcolorBtn1:(ownAppiSelectedVariant == 2)?ownAppi.IconcolorBtn2:(ownAppiSelectedVariant == 3)?ownAppi.IconcolorBtn3:(ownAppiSelectedVariant == 4)?ownAppi.IconcolorBtn4:ownAppi.IconcolorBtn5,}"
                                                       v-bind:target="(ownAppi.ShowLinkNewWin[(ownAppiSelectedVariant - 1)])?'_blank':'_self'">{{((selectedLanguage =='en') ? ownAppi.linkDescriptionEn[(ownAppiSelectedVariant-1)] : (selectedLanguage =='sk') ? ownAppi.linkDescriptionSk[(ownAppiSelectedVariant-1)] : ownAppi.linkDescriptionCz[(ownAppiSelectedVariant-1)])}}</a>
                                                </div>
                                                <button id="bubbleLinkButton" v-on:click="openWindow(ownAppi.targetUrl[(ownAppiSelectedVariant-1)],ownAppiSelectedVariant)" v-if="ownAppi.ShowLink[(ownAppiSelectedVariant - 1)] && ownAppi.ShowLinkBtn[(ownAppiSelectedVariant - 1)]"
                                                        class="btn btn-outline-link btn_link_new" v-bind:style="{'color': (ownAppiSelectedVariant == 1)?ownAppi.IconcolorBtn1:(ownAppiSelectedVariant == 2)?ownAppi.IconcolorBtn2:(ownAppiSelectedVariant == 3)?ownAppi.IconcolorBtn3:(ownAppiSelectedVariant == 4)?ownAppi.IconcolorBtn4:ownAppi.IconcolorBtn5,
                                                    'border-color': (ownAppiSelectedVariant == 1)?(ownAppi.IconcolorBtn1.toLowerCase() == '#ffffff')?ownAppi.IconcolorBckBtn1:ownAppi.IconcolorBtn1:(ownAppiSelectedVariant == 2)?(ownAppi.IconcolorBtn2.toLowerCase() == '#ffffff')?ownAppi.IconcolorBckBtn2:ownAppi.IconcolorBtn2:(ownAppiSelectedVariant == 3)?(ownAppi.IconcolorBtn3.toLowerCase() == '#ffffff')?ownAppi.IconcolorBckBtn3:ownAppi.IconcolorBtn3:(ownAppiSelectedVariant == 4)?(ownAppi.IconcolorBtn4.toLowerCase() == '#ffffff')?ownAppi.IconcolorBckBtn4:ownAppi.IconcolorBtn4:(ownAppi.IconcolorBtn5.toLowerCase() == '#ffffff')?ownAppi.IconcolorBckBtn5:ownAppi.IconcolorBtn5,
                                                    'background-color': (ownAppiSelectedVariant == 1)?ownAppi.IconcolorBckBtn1:(ownAppiSelectedVariant == 2)?ownAppi.IconcolorBckBtn2:(ownAppiSelectedVariant == 3)?ownAppi.IconcolorBckBtn3:(ownAppiSelectedVariant == 4)?ownAppi.IconcolorBckBtn4:ownAppi.IconcolorBckBtn5}"
                                                        @mouseover="mouseOverChange(ownAppiSelectedVariant,'on')"
                                                        @mouseleave="mouseOverChange(ownAppiSelectedVariant,'out')"
                                                        style="margin-top: 3px;padding: 0rem 1.2rem 0rem 1.2rem;font-size: 15px;">
                                                    {{((selectedLanguage =='en') ? ownAppi.linkDescriptionEn[(ownAppiSelectedVariant-1)] : (selectedLanguage =='sk') ? ownAppi.linkDescriptionSk[(ownAppiSelectedVariant-1)] : ownAppi.linkDescriptionCz[(ownAppiSelectedVariant-1)])}}
                                                </button>
                                            </span>
                                            <div class="width_100 text-right" style="right: 125px;line-height: 11px;bottom: -67px;position: relative;min-width: 100px;height: 10px;">
                                                <span class="Appi_bubble_check_gray"></span>
                                                <span class="Appi_bubble_text_gray">app</span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="container-bottom-buttons new_campaign_container_but">
            <div class="container">
                <div class="row">
                    <div class="col-md-12 d-flex justify-content-between p-0">
                        <div class="justify-content-start">
                            <button class="btn btn-outline-secondary btn_new_campaign" v-on:click="PreviousStep">
                                <i class="fas fa-chevron-circle-left"></i>&nbsp;&nbsp;&nbsp; Zpět
                            </button>
                        </div>
                        <div class="d-flex justify-content-center" style="display: inline-flex;">
                            <div class="d-inline-block pt-1 text-center">
                                Vybraná doména:
                                <i style="color:royalblue; opacity:1;" class="fa fa-question-circle pointer pl-2"
                                   v-tooltip.top="{ content: 'Pro změnu domény u celé kampaně se vraťte do kroku 1.' }"></i>
                                <input type="text" v-bind:alt="selectedDomain" v-bind:title="selectedDomain" v-model="selectedDomain" disabled="disabled" style="max-width: 240px;" name="selectedDomain" class="form-control" />
                            </div>
                        </div>
                        <div class="justify-content-end">
                            <button class="btn btn-main-primary btn_new btn_new_campaign" v-on:click="NextStep">
                                Pokračovat&nbsp;&nbsp;&nbsp; <i class="fas fa-chevron-circle-right"></i>
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</template>

<script>

 	import Vue from 'vue';
	import VueCookie from 'vue-cookie';
    import VeeValidate from 'vee-validate';
    import { setTimeout } from 'timers';


    import VueI18n from 'vue-i18n';
	import cs from "vee-validate/dist/locale/cs";
    import en from "vee-validate/dist/locale/en";

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

    Vue.use(VueI18n);
	Vue.use(VueCookie);

    const parseDomain = require("parse-domain");
    const parseUrl = require("parse-url");

	const locale = Vue.cookie.get('locale') || 'cs';
	const i18n = new VueI18n({
	  locale: locale
	});


	Vue.use(VeeValidate, {
	  i18n,
	  dictionary: {
		cs,en
	  }
	});
	
    export default {
        components: {
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
                adminAccess: false,
                userUid: 'none',
                userEmail: null,

                //temp
                selectOptionList: ['Information', 'BellOutline', 'BellRingOutline', 'Sale', 'Truck', 'TagHeart', 'TooltipAccount', 'AccountPlusOutline', 'StarOutline', 'WalletGiftcard', 'GestureTap', 'Ticket', 'EyeOutline', 'ThumbUpOutline', 'AlertCircle', 'MessageText', 'EmailOutline', 'LightbulbOnOutline', 'CakeVariant', 'Facebook', 'FacebookBox', 'FacebookMessenger', 'GooglePlusBox', 'LinkedinBox', 'TwitterBox',
                    'Youtube', 'Instagram', 'FoodForkDrink', 'EmoticonHappyOutline', 'Emoticon', 'EmoticonOutline', 'Cupcake', 'CheckboxMarkedCircle', 'GlassWine', 'ArrowRightCircle', 'ArrowRightCircleOutline', 'ChevronDoubleRight', 'GlassMugVariant', 'ChevronRightCircle', 'BagChecked', 'Heart', 'HeartOutline', 'ChatAlert', 'CommentAlert', 'TooltipText', 'CarHatchback', 'AvTimer', 'ClockFast', 'TimerSand',
                    'Bike', 'Brain', 'Face', 'FaceWoman', 'GiftOutline', 'BabyCarriage', 'Bone', 'Paw', 'Flower', 'Sprout', 'ArmFlexOutline', 'MonitorCellphone', 'CellphoneBasic', 'ChatProcessing', 'CameraWirelessOutline', 'ChefHat', 'Crown', 'DominoMask', 'Ring', 'ShoeHeel', 'TshirtCrewOutline', 'Cash100', 'PigVariant', 'Anchor', 'Charity', 'Lifebuoy', 'HeartPulse', 'MedicalBag', 'Fire','Smoking'],
                ownAppiSelectedVariant: 1,

                //data
                ownAppi: JSON.parse(JSON.stringify(this.$store.state.OwnAppi)),

                Component: '',
                CampaignName: this.$store.state.CampaignName,
                selectedDomain: this.$store.state.selectedDomain,
                selectedLanguage: this.$store.state.selectedLanguage,

                DomainList: [],
                SelectedMessages: [],
                validatingEnabled: true,

                CaptureRuleObj: this.$store.state.CaptureRuleObj,
                CapturedUrlsObjIn: this.$store.state.CapturedUrlsObjIn,
                CapturedUrlsObjOut: this.$store.state.CapturedUrlsObjOut,
                CaptureRuleReg: this.$store.state.CaptureRuleReg,
                CapturedUrlsRegIn: this.$store.state.CapturedUrlsRegIn,
                CapturedUrlsRegOut: this.$store.state.CapturedUrlsRegOut,
                CaptureRuleStat: this.$store.state.CaptureRuleStat,
                CapturedUrlsStatIn: this.$store.state.CapturedUrlsStatIn,
                CapturedUrlsStatOut: this.$store.state.CapturedUrlsStatOut,
                ShownRule: this.$store.state.ShownRule,
                ShownUrlsIn: this.$store.state.ShownUrlsIn,
                ShownUrlsOut: this.$store.state.ShownUrlsOut,
                heurekaAPIkey: this.$store.state.heurekaAPIkey,
                zboziAPIkey: this.$store.state.zboziAPIkey,
            }
        },
        activated() {
            var that = this;
        
            that.ownAppi = JSON.parse(JSON.stringify(that.$store.state.OwnAppi));

            if (that.$store.state.CampaignData.campaignID != undefined) {
                if (that.SelectedMessages == '') { that.SelectedMessages = (that.$store.state.SelectedMessages != '') ? that.$store.state.SelectedMessages : that.$store.state.CampaignData.SelectedMessages; }
            } else {
                if (that.SelectedMessages == '') { that.SelectedMessages = that.$store.state.SelectedMessages; }
            }

            that.CaptureRuleObj = JSON.parse(JSON.stringify(that.$store.state.CaptureRuleObj));
            that.CapturedUrlsObjIn = JSON.parse(JSON.stringify(that.$store.state.CapturedUrlsObjIn));
            that.CapturedUrlsObjOut = JSON.parse(JSON.stringify(that.$store.state.CapturedUrlsObjOut));
            that.CaptureRuleReg = JSON.parse(JSON.stringify(that.$store.state.CaptureRuleReg));
            that.CapturedUrlsRegIn = JSON.parse(JSON.stringify(that.$store.state.CapturedUrlsRegIn));
            that.CapturedUrlsRegOut = JSON.parse(JSON.stringify(that.$store.state.CapturedUrlsRegOut));
            that.CaptureRuleStat = JSON.parse(JSON.stringify(that.$store.state.CaptureRuleStat));
            that.CapturedUrlsStatIn = JSON.parse(JSON.stringify(that.$store.state.CapturedUrlsStatIn));
            that.CapturedUrlsStatOut = JSON.parse(JSON.stringify(that.$store.state.CapturedUrlsStatOut));
            that.ShownRule = JSON.parse(JSON.stringify(that.$store.state.ShownRule));
            that.ShownUrlsIn = JSON.parse(JSON.stringify(that.$store.state.ShownUrlsIn));
            that.ShownUrlsOut = JSON.parse(JSON.stringify(that.$store.state.ShownUrlsOut));
            that.heurekaAPIkey = that.$store.state.heurekaAPIkey;
            that.zboziAPIkey = that.$store.state.zboziAPIkey;

            that.selectedDomain = that.$store.state.selectedDomain;
            that.selectedLanguage = that.$store.state.selectedLanguage;

            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/get_domains",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
            }).done(function (dataDomains) {
                if (dataDomains.domains != undefined && dataDomains.domains.length > 0) {
                    dataDomains.domains.forEach(function (domain) {
                        if (that.DomainList.indexOf(domain.domain) === -1 && domain.domain != "" && domain.domain.indexOf('file://') == -1 && domain.domain.indexOf('content://') == -1 && domain.domain.indexOf('about:blank') == -1) {
                            that.DomainList.push(domain.domain);
                        }
                    });
                }
            });

            setTimeout(() => {
                that.changeOwnAppiSelectedVariant(5);
            }, 50);
            setTimeout(() => {
                that.changeOwnAppiSelectedVariant((that.ownAppi.ownAppiActive.indexOf(true)+1));
            }, 100);
        },
        mounted() {
            this.updateFromPicker(1, this.ownAppi.Iconcolor1);
        },
        methods: {
            goToStep(value) {
                this.$store.state.SelectedMessages = this.SelectedMessages;
                switch (value) {
                    case 'Step4':
                        if (this.$store.state.CampaignName.length > 0) {
                            this.Component = "app-new-campaign-Step4";
                            this.$emit("changeComponent", this.Component);
                        }
                        break;
                    case 'Step3':
                        if (this.$store.state.CampaignName.length > 0) {
                            this.Component = "app-new-campaign-Step3";
                            this.$emit("changeComponent", this.Component);
                        }
                        break;
                    case 'Step2':
                        if (this.$store.state.CampaignName.length > 0) {
                            if (this.SelectedMessages.indexOf('LastEventsOrders') > -1) {
                                this.Component = "app-new-campaign-Step2_obj";
                            } else if (this.SelectedMessages.indexOf('LastEventsRegistrations') > -1) {
                                this.Component = "app-new-campaign-Step2_reg";
                            } else if (this.SelectedMessages.indexOf('VisitCount') > -1) {
                                this.Component = "app-new-campaign-Step2_visit";
                            } else if (this.SelectedMessages.indexOf('Statistics') > -1) {
                                this.Component = "app-new-campaign-Step2_stat";
                            } else if (this.SelectedMessages.indexOf('Heureka') > -1) {
                                this.Component = "app-new-campaign-Step2_rev";
                            } else if (this.SelectedMessages.indexOf('Zbozi') > -1) {
                                this.Component = "app-new-campaign-Step2_zbozi";
                            } else if (this.SelectedMessages.indexOf('OwnAppi') > -1) {
                                this.Component = "app-new-campaign-Step2_ownAppi";
                            }
                            this.$emit("changeComponent", this.Component);
                        }
                        break;
                    case 'Step1':
                        if (this.$store.state.CampaignName.length > 0) {
                            this.Component = "app-new-campaign-Step1";
                            this.$emit("changeComponent", this.Component);
                        }
                        break;
                }
            },

            goToSelected(value) {
                switch (value) {
                    case 'LastEventsOrders':
                        if (this.CapturedUrlsObjIn[0].length > 0 && this.CampaignName.length > 0) {
                            this.Component = "app-new-campaign-Step2_obj";
                            this.$emit("changeComponent", this.Component);
                        }
                        break;
                    case 'LastEventsRegistrations':
                        if (this.CapturedUrlsRegIn[0].length > 0 && this.CampaignName.length > 0) {
                            this.Component = "app-new-campaign-Step2_reg";
                            this.$emit("changeComponent", this.Component);
                        }
                        break;
                    case 'Statistics':
                        if (this.CapturedUrlsStatIn[0].length > 0 && this.CampaignName.length > 0) {
                            this.Component = "app-new-campaign-Step2_stat";
                            this.$emit("changeComponent", this.Component);
                        }
                        break;
                    case 'Heureka':
                        if (this.heurekaAPIkey !== 'none' && this.CampaignName.length > 0) {
                            this.Component = "app-new-campaign-Step2_rev";
                            this.$emit("changeComponent", this.Component);
                        }
                        break;
                    case 'Zbozi':
                        if (this.zboziAPIkey !== 'none' && this.CampaignName.length > 0) {
                            this.Component = "app-new-campaign-Step2_zbozi";
                            this.$emit("changeComponent", this.Component);
                            break;
                        }
                    case 'OwnAppi':
                        if (this.ownAppi.ownAppiActive.indexOf(true) > -1 && this.CampaignName.length > 0) {
                            this.Component = "app-new-campaign-Step2_ownAppi";
                            this.$emit("changeComponent", this.Component);
                            break;
                        }
                }

            },
            NextStep() {
                //uloží vybrané URL do globální state
                //změna dynamické komponenty
                this.Component = "app-new-campaign-Step3";
                this.$emit("changeComponent", this.Component);
            },
			
            PreviousStep() {
                //uloží vybrané URL do globální state
                //změna dynamické komponenty
                if (this.SelectedMessages.indexOf('Zbozi') > -1) {
                    this.Component = "app-new-campaign-Step2_zbozi";
                } else if (this.SelectedMessages.indexOf('Heureka') > -1) {
                    this.Component = "app-new-campaign-Step2_rev";
                } else if (this.SelectedMessages.indexOf('Statistics') > -1) {
                    this.Component = "app-new-campaign-Step2_stat";
                } else if (this.SelectedMessages.indexOf('VisitCount') > -1) {
                    this.Component = "app-new-campaign-Step2_visit";
                } else if (this.SelectedMessages.indexOf('LastEventsRegistrations') > -1) {
                    this.Component = "app-new-campaign-Step2_reg";
                } else if (this.SelectedMessages.indexOf('LastEventsOrders') > -1) {
                    this.Component = "app-new-campaign-Step2_obj";
                } else {
                    this.Component = "app-new-campaign-Step1";
                }
                this.$emit("changeComponent", this.Component);

            },
            changeOwnAppiSelectedVariant(value) {
                setTimeout(() => {
                    document.querySelector("#" +
                        ((value == 1) ? this.ownAppi.OwnAppi1Icon : (value == 2) ? this.ownAppi.OwnAppi2Icon : (value == 3) ? this.ownAppi.OwnAppi3Icon : (value == 4) ? this.ownAppi.OwnAppi4Icon : this.ownAppi.OwnAppi5Icon)
                    ).setAttribute("fill", ((value == 1) ? this.ownAppi.Iconcolor1 : (value == 2) ? this.ownAppi.Iconcolor2 : (value == 3) ? this.ownAppi.Iconcolor3 : (value == 4) ? this.ownAppi.Iconcolor4 : this.ownAppi.Iconcolor5))
                }, 50);
                if (this.ownAppi.ShowLinkBtn[(value - 1)]) {
                    setTimeout(() => { document.querySelector("#messageData").style.marginTop = '-3px'; }, 0);
                } else {
                    setTimeout(() => { document.querySelector("#messageData").style.marginTop = '0px'; }, 0);
                }
                this.ownAppiSelectedVariant = value;

                setTimeout(() => {
                    this.updateFromPicker(value, ((value == 1) ? this.ownAppi.Iconcolor1 : (value == 2) ? this.ownAppi.Iconcolor2 : (value == 3) ? this.ownAppi.Iconcolor3 : (value == 4) ? this.ownAppi.Iconcolor4 : this.ownAppi.Iconcolor5));
                }, 50);
            
            },
            updateFromPicker(visNr, value) {
                switch (visNr) {
                    case 1:
                        this.ownAppi.Iconcolor1 = value; setTimeout(() => { document.querySelector("#" + this.ownAppi.OwnAppi1Icon).setAttribute("fill", value);}, 0);
                        break;
                    case 2:
                        this.ownAppi.Iconcolor2 = value; setTimeout(() => { document.querySelector("#" + this.ownAppi.OwnAppi2Icon).setAttribute("fill", value);}, 0);
                        break;
                    case 3:
                        this.ownAppi.Iconcolor3 = value; setTimeout(() => { document.querySelector("#" + this.ownAppi.OwnAppi3Icon).setAttribute("fill", value);}, 0);
                        break;
                    case 4:
                        this.ownAppi.Iconcolor4 = value; setTimeout(() => { document.querySelector("#" + this.ownAppi.OwnAppi4Icon).setAttribute("fill", value);}, 0);
                        break;
                    case 5:
                        this.ownAppi.Iconcolor5 = value; setTimeout(() => { document.querySelector("#" + this.ownAppi.OwnAppi5Icon).setAttribute("fill", value); }, 0);
                        break;
                    default:
                }
            },
            mouseOverChange(visNr, status) {
                if (status == 'on') {
                    setTimeout(() => {
                        var el = document.querySelector("#bubbleLinkButton");
                        el.style.color = ((visNr == 1) ? this.ownAppi.IconcolorBckBtn1 : (visNr == 2) ? this.ownAppi.IconcolorBckBtn2 : (visNr == 3) ? this.ownAppi.IconcolorBckBtn3 : (visNr == 4) ? this.ownAppi.IconcolorBckBtn4 : this.ownAppi.IconcolorBckBtn5);
                        el.style.backgroundColor = ((visNr == 1) ? this.ownAppi.IconcolorBtn1 : (visNr == 2) ? this.ownAppi.IconcolorBtn2 : (visNr == 3) ? this.ownAppi.IconcolorBtn3 : (visNr == 4) ? this.ownAppi.IconcolorBtn4 : this.ownAppi.IconcolorBtn5);
                    }, 0);

                } else {
                    setTimeout(() => {
                        var el = document.querySelector("#bubbleLinkButton");
                        el.style.color = ((visNr == 1) ? this.ownAppi.IconcolorBtn1 : (visNr == 2) ? this.ownAppi.IconcolorBtn2 : (visNr == 3) ? this.ownAppi.IconcolorBtn3 : (visNr == 4) ? this.ownAppi.IconcolorBtn4 : this.ownAppi.IconcolorBtn5);
                        el.style.backgroundColor = ((visNr == 1) ? this.ownAppi.IconcolorBckBtn1 : (visNr == 2) ? this.ownAppi.IconcolorBckBtn2 : (visNr == 3) ? this.ownAppi.IconcolorBckBtn3 : (visNr == 4) ? this.ownAppi.IconcolorBckBtn4 : this.ownAppi.IconcolorBckBtn5);
                    }, 0);
                }
            },
            openWindow(url, visNr) {
                window.open(url, ((this.ownAppi.ShowLinkNewWin[(visNr - 1)]) ? '_blank' : '_self'));
            },
		},
        watch: {
       
        },
        created() {
            //console.log(this.ownAppi);
            this.userUid = this.$store.state.AdminModule.adminUserKey;
		}
    }
</script>