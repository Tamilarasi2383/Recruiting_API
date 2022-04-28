<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitingApp.Master" AutoEventWireup="true" CodeBehind="ManagerDashboard.aspx.cs" Inherits="Recruiting_API.ManagerDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="assets/css/Common.css" rel="stylesheet" />
    <script src="assets/js/plugins/chartjs.min.js"></script>
    <script src="assets/js/plugins/Chart.extension.js"></script>

    <style id="jss-server-side">
        .jsshover1:hover{
            box-shadow: inset 0px 0px 7px 0px #ff843b;
            /*border: solid 1px #ff843b;*/
        }

        .jsshover2:hover{
            box-shadow: inset 0px 0px 7px 0px #1edefc;
            /*border: solid 1px #1edefc;*/
        }

        .jsshover3:hover{
            box-shadow: inset 0px 0px 7px 0px #28ff8a;
            /*border: solid 1px #28ff8a;*/
        }

        .jsshover4:hover{
            box-shadow: inset 0px 0px 7px 0px #f44336;
            /*border: solid 1px #f44336;*/
        }

        .MuiPaper-root {
            color: rgba(0, 0, 0, 0.87);
            transition: box-shadow 300ms cubic-bezier(0.4, 0, 0.2, 1) 0ms;
            background-color: #fff;
        }

        .MuiPaper-rounded {
            border-radius: 4px;
        }

        .MuiPaper-outlined {
            border: 1px solid rgba(0, 0, 0, 0.12);
        }

        .MuiPaper-elevation0 {
            box-shadow: none;
        }

        .MuiPaper-elevation1 {
            box-shadow: 0px 2px 1px -1px rgba(0,0,0,0.2),0px 1px 1px 0px rgba(0,0,0,0.14),0px 1px 3px 0px rgba(0,0,0,0.12);
        }

        .MuiPaper-elevation2 {
            box-shadow: 0px 3px 1px -2px rgba(0,0,0,0.2),0px 2px 2px 0px rgba(0,0,0,0.14),0px 1px 5px 0px rgba(0,0,0,0.12);
        }

        .MuiPaper-elevation3 {
            box-shadow: 0px 3px 3px -2px rgba(0,0,0,0.2),0px 3px 4px 0px rgba(0,0,0,0.14),0px 1px 8px 0px rgba(0,0,0,0.12);
        }

        .MuiPaper-elevation4 {
            box-shadow: 0px 2px 4px -1px rgba(0,0,0,0.2),0px 4px 5px 0px rgba(0,0,0,0.14),0px 1px 10px 0px rgba(0,0,0,0.12);
        }

        .MuiPaper-elevation5 {
            box-shadow: 0px 3px 5px -1px rgba(0,0,0,0.2),0px 5px 8px 0px rgba(0,0,0,0.14),0px 1px 14px 0px rgba(0,0,0,0.12);
        }

        .MuiPaper-elevation6 {
            box-shadow: 0px 3px 5px -1px rgba(0,0,0,0.2),0px 6px 10px 0px rgba(0,0,0,0.14),0px 1px 18px 0px rgba(0,0,0,0.12);
        }

        .MuiPaper-elevation7 {
            box-shadow: 0px 4px 5px -2px rgba(0,0,0,0.2),0px 7px 10px 1px rgba(0,0,0,0.14),0px 2px 16px 1px rgba(0,0,0,0.12);
        }

        .MuiPaper-elevation8 {
            box-shadow: 0px 5px 5px -3px rgba(0,0,0,0.2),0px 8px 10px 1px rgba(0,0,0,0.14),0px 3px 14px 2px rgba(0,0,0,0.12);
        }

        .MuiPaper-elevation9 {
            box-shadow: 0px 5px 6px -3px rgba(0,0,0,0.2),0px 9px 12px 1px rgba(0,0,0,0.14),0px 3px 16px 2px rgba(0,0,0,0.12);
        }

        .MuiPaper-elevation10 {
            box-shadow: 0px 6px 6px -3px rgba(0,0,0,0.2),0px 10px 14px 1px rgba(0,0,0,0.14),0px 4px 18px 3px rgba(0,0,0,0.12);
        }

        .MuiPaper-elevation11 {
            box-shadow: 0px 6px 7px -4px rgba(0,0,0,0.2),0px 11px 15px 1px rgba(0,0,0,0.14),0px 4px 20px 3px rgba(0,0,0,0.12);
        }

        .MuiPaper-elevation12 {
            box-shadow: 0px 7px 8px -4px rgba(0,0,0,0.2),0px 12px 17px 2px rgba(0,0,0,0.14),0px 5px 22px 4px rgba(0,0,0,0.12);
        }

        .MuiPaper-elevation13 {
            box-shadow: 0px 7px 8px -4px rgba(0,0,0,0.2),0px 13px 19px 2px rgba(0,0,0,0.14),0px 5px 24px 4px rgba(0,0,0,0.12);
        }

        .MuiPaper-elevation14 {
            box-shadow: 0px 7px 9px -4px rgba(0,0,0,0.2),0px 14px 21px 2px rgba(0,0,0,0.14),0px 5px 26px 4px rgba(0,0,0,0.12);
        }

        .MuiPaper-elevation15 {
            box-shadow: 0px 8px 9px -5px rgba(0,0,0,0.2),0px 15px 22px 2px rgba(0,0,0,0.14),0px 6px 28px 5px rgba(0,0,0,0.12);
        }

        .MuiPaper-elevation16 {
            box-shadow: 0px 8px 10px -5px rgba(0,0,0,0.2),0px 16px 24px 2px rgba(0,0,0,0.14),0px 6px 30px 5px rgba(0,0,0,0.12);
        }

        .MuiPaper-elevation17 {
            box-shadow: 0px 8px 11px -5px rgba(0,0,0,0.2),0px 17px 26px 2px rgba(0,0,0,0.14),0px 6px 32px 5px rgba(0,0,0,0.12);
        }

        .MuiPaper-elevation18 {
            box-shadow: 0px 9px 11px -5px rgba(0,0,0,0.2),0px 18px 28px 2px rgba(0,0,0,0.14),0px 7px 34px 6px rgba(0,0,0,0.12);
        }

        .MuiPaper-elevation19 {
            box-shadow: 0px 9px 12px -6px rgba(0,0,0,0.2),0px 19px 29px 2px rgba(0,0,0,0.14),0px 7px 36px 6px rgba(0,0,0,0.12);
        }

        .MuiPaper-elevation20 {
            box-shadow: 0px 10px 13px -6px rgba(0,0,0,0.2),0px 20px 31px 3px rgba(0,0,0,0.14),0px 8px 38px 7px rgba(0,0,0,0.12);
        }

        .MuiPaper-elevation21 {
            box-shadow: 0px 10px 13px -6px rgba(0,0,0,0.2),0px 21px 33px 3px rgba(0,0,0,0.14),0px 8px 40px 7px rgba(0,0,0,0.12);
        }

        .MuiPaper-elevation22 {
            box-shadow: 0px 10px 14px -6px rgba(0,0,0,0.2),0px 22px 35px 3px rgba(0,0,0,0.14),0px 8px 42px 7px rgba(0,0,0,0.12);
        }

        .MuiPaper-elevation23 {
            box-shadow: 0px 11px 14px -7px rgba(0,0,0,0.2),0px 23px 36px 3px rgba(0,0,0,0.14),0px 9px 44px 8px rgba(0,0,0,0.12);
        }

        .MuiPaper-elevation24 {
            box-shadow: 0px 11px 15px -7px rgba(0,0,0,0.2),0px 24px 38px 3px rgba(0,0,0,0.14),0px 9px 46px 8px rgba(0,0,0,0.12);
        }

        .MuiAppBar-root {
            width: 100%;
            display: flex;
            z-index: 1100;
            box-sizing: border-box;
            flex-shrink: 0;
            flex-direction: column;
        }

        .MuiAppBar-positionFixed {
            top: 0;
            left: auto;
            right: 0;
            position: fixed;
        }

        @media print {
            .MuiAppBar-positionFixed {
                position: absolute;
            }
        }

        .MuiAppBar-positionAbsolute {
            top: 0;
            left: auto;
            right: 0;
            position: absolute;
        }

        .MuiAppBar-positionSticky {
            top: 0;
            left: auto;
            right: 0;
            position: sticky;
        }

        .MuiAppBar-positionStatic {
            position: static;
        }

        .MuiAppBar-positionRelative {
            position: relative;
        }

        .MuiAppBar-colorDefault {
            color: rgba(0, 0, 0, 0.87);
            background-color: #f5f5f5;
        }

        .MuiAppBar-colorPrimary {
            color: #fff;
            background-color: #3f51b5;
        }

        .MuiAppBar-colorSecondary {
            color: #fff;
            background-color: #f50057;
        }

        .MuiAppBar-colorInherit {
            color: inherit;
        }

        .MuiAppBar-colorTransparent {
            color: inherit;
            background-color: transparent;
        }

        .MuiToolbar-root {
            display: flex;
            position: relative;
            align-items: center;
        }

        .MuiToolbar-gutters {
            padding-left: 16px;
            padding-right: 16px;
        }

        @media (min-width:600px) {
            .MuiToolbar-gutters {
                padding-left: 24px;
                padding-right: 24px;
            }
        }

        .MuiToolbar-regular {
            min-height: 56px;
        }

        @media (min-width:0px) and (orientation: landscape) {
            .MuiToolbar-regular {
                min-height: 48px;
            }
        }

        @media (min-width:600px) {
            .MuiToolbar-regular {
                min-height: 64px;
            }
        }

        .MuiToolbar-dense {
            min-height: 48px;
        }

        @media (min-width:0px) and (max-width:599.95px) {
            .jss64 {
                display: none;
            }
        }

        @media (min-width:0px) {
            .jss65 {
                display: none;
            }
        }

        @media (max-width:599.95px) {
            .jss66 {
                display: none;
            }
        }

        @media (min-width:600px) and (max-width:959.95px) {
            .jss67 {
                display: none;
            }
        }

        @media (min-width:600px) {
            .jss68 {
                display: none;
            }
        }

        @media (max-width:959.95px) {
            .jss69 {
                display: none;
            }
        }

        @media (min-width:960px) and (max-width:1279.95px) {
            .jss70 {
                display: none;
            }
        }

        @media (min-width:960px) {
            .jss71 {
                display: none;
            }
        }

        @media (max-width:1279.95px) {
            .jss72 {
                display: none;
            }
        }

        @media (min-width:1280px) and (max-width:1919.95px) {
            .jss73 {
                display: none;
            }
        }

        @media (min-width:1280px) {
            .jss74 {
                display: none;
            }
        }

        @media (max-width:1919.95px) {
            .jss75 {
                display: none;
            }
        }

        @media (min-width:1920px) {
            .jss76 {
                display: none;
            }
        }

        @media (min-width:1920px) {
            .jss77 {
                display: none;
            }
        }

        @media (min-width:0px) {
            .jss78 {
                display: none;
            }
        }

        .MuiSvgIcon-root {
            fill: currentColor;
            width: 1em;
            height: 1em;
            display: inline-block;
            font-size: 1.5rem;
            transition: fill 200ms cubic-bezier(0.4, 0, 0.2, 1) 0ms;
            flex-shrink: 0;
            user-select: none;
        }

        .MuiSvgIcon-colorPrimary {
            color: #3f51b5;
        }

        .MuiSvgIcon-colorSecondary {
            color: #f50057;
        }

        .MuiSvgIcon-colorAction {
            color: rgba(0, 0, 0, 0.54);
        }

        .MuiSvgIcon-colorError {
            color: #f44336;
        }

        .MuiSvgIcon-colorDisabled {
            color: rgba(0, 0, 0, 0.26);
        }

        .MuiSvgIcon-fontSizeInherit {
            font-size: inherit;
        }

        .MuiSvgIcon-fontSizeSmall {
            font-size: 1.25rem;
        }

        .MuiSvgIcon-fontSizeLarge {
            font-size: 2.1875rem;
        }

        .MuiButtonBase-root {
            color: inherit;
            border: 0;
            cursor: pointer;
            margin: 0;
            display: inline-flex;
            outline: 0;
            padding: 0;
            position: relative;
            align-items: center;
            user-select: none;
            border-radius: 0;
            vertical-align: middle;
            -moz-appearance: none;
            justify-content: center;
            text-decoration: none;
            background-color: transparent;
            -webkit-appearance: none;
            -webkit-tap-highlight-color: transparent;
        }

            .MuiButtonBase-root::-moz-focus-inner {
                border-style: none;
            }

            .MuiButtonBase-root.Mui-disabled {
                cursor: default;
                pointer-events: none;
            }

        @media print {
            .MuiButtonBase-root {
                color-adjust: exact;
            }
        }

        .MuiListItem-root {
            width: 100%;
            display: flex;
            position: relative;
            box-sizing: border-box;
            text-align: left;
            align-items: center;
            padding-top: 8px;
            padding-bottom: 8px;
            justify-content: flex-start;
            text-decoration: none;
        }

            .MuiListItem-root.Mui-focusVisible {
                background-color: rgba(0, 0, 0, 0.08);
            }

            .MuiListItem-root.Mui-selected, .MuiListItem-root.Mui-selected:hover {
                background-color: rgba(0, 0, 0, 0.08);
            }

            .MuiListItem-root.Mui-disabled {
                opacity: 0.5;
            }

        .MuiListItem-container {
            position: relative;
        }

        .MuiListItem-dense {
            padding-top: 4px;
            padding-bottom: 4px;
        }

        .MuiListItem-alignItemsFlexStart {
            align-items: flex-start;
        }

        .MuiListItem-divider {
            border-bottom: 1px solid rgba(0, 0, 0, 0.12);
            background-clip: padding-box;
        }

        .MuiListItem-gutters {
            padding-left: 16px;
            padding-right: 16px;
        }

        .MuiListItem-button {
            transition: background-color 150ms cubic-bezier(0.4, 0, 0.2, 1) 0ms;
        }

            .MuiListItem-button:hover {
                text-decoration: none;
                background-color: rgba(0, 0, 0, 0.04);
            }

        @media (hover: none) {
            .MuiListItem-button:hover {
                background-color: transparent;
            }
        }

        .MuiListItem-secondaryAction {
            padding-right: 48px;
        }

        .MuiList-root {
            margin: 0;
            padding: 0;
            position: relative;
            list-style: none;
        }

        .MuiList-padding {
            padding-top: 8px;
            padding-bottom: 8px;
        }

        .MuiList-subheader {
            padding-top: 0;
        }

        .MuiFormControl-root {
            border: 0;
            margin: 0;
            display: inline-flex;
            padding: 0;
            position: relative;
            min-width: 0;
            flex-direction: column;
            vertical-align: top;
        }

        .MuiFormControl-marginNormal {
            margin-top: 16px;
            margin-bottom: 8px;
        }

        .MuiFormControl-marginDense {
            margin-top: 8px;
            margin-bottom: 4px;
        }

        .MuiFormControl-fullWidth {
            width: 100%;
        }

        @keyframes mui-auto-fill {
        }

        @keyframes mui-auto-fill-cancel {
        }

        .MuiInputBase-root {
            color: rgba(0, 0, 0, 0.87);
            cursor: text;
            display: inline-flex;
            position: relative;
            font-size: 1rem;
            box-sizing: border-box;
            align-items: center;
            font-family: "Roboto", "Helvetica", "Arial", sans-serif;
            font-weight: 400;
            line-height: 1.1876em;
            letter-spacing: 0.00938em;
        }

            .MuiInputBase-root.Mui-disabled {
                color: rgba(0, 0, 0, 0.38);
                cursor: default;
            }

        .MuiInputBase-multiline {
            padding: 6px 0 7px;
        }

            .MuiInputBase-multiline.MuiInputBase-marginDense {
                padding-top: 3px;
            }

        .MuiInputBase-fullWidth {
            width: 100%;
        }

        .MuiInputBase-input {
            font: inherit;
            color: currentColor;
            width: 100%;
            border: 0;
            height: 1.1876em;
            margin: 0;
            display: block;
            padding: 6px 0 7px;
            min-width: 0;
            background: none;
            box-sizing: content-box;
            animation-name: mui-auto-fill-cancel;
            letter-spacing: inherit;
            animation-duration: 10ms;
            -webkit-tap-highlight-color: transparent;
        }

            .MuiInputBase-input::-webkit-input-placeholder {
                color: currentColor;
                opacity: 0.42;
                transition: opacity 200ms cubic-bezier(0.4, 0, 0.2, 1) 0ms;
            }

            .MuiInputBase-input::-moz-placeholder {
                color: currentColor;
                opacity: 0.42;
                transition: opacity 200ms cubic-bezier(0.4, 0, 0.2, 1) 0ms;
            }

            .MuiInputBase-input:-ms-input-placeholder {
                color: currentColor;
                opacity: 0.42;
                transition: opacity 200ms cubic-bezier(0.4, 0, 0.2, 1) 0ms;
            }

            .MuiInputBase-input::-ms-input-placeholder {
                color: currentColor;
                opacity: 0.42;
                transition: opacity 200ms cubic-bezier(0.4, 0, 0.2, 1) 0ms;
            }

            .MuiInputBase-input:focus {
                outline: 0;
            }

            .MuiInputBase-input:invalid {
                box-shadow: none;
            }

            .MuiInputBase-input::-webkit-search-decoration {
                -webkit-appearance: none;
            }

            .MuiInputBase-input.Mui-disabled {
                opacity: 1;
            }

            .MuiInputBase-input:-webkit-autofill {
                animation-name: mui-auto-fill;
                animation-duration: 5000s;
            }

        label[data-shrink=false] + .MuiInputBase-formControl .MuiInputBase-input::-webkit-input-placeholder {
            opacity: 0 !important;
        }

        label[data-shrink=false] + .MuiInputBase-formControl .MuiInputBase-input::-moz-placeholder {
            opacity: 0 !important;
        }

        label[data-shrink=false] + .MuiInputBase-formControl .MuiInputBase-input:-ms-input-placeholder {
            opacity: 0 !important;
        }

        label[data-shrink=false] + .MuiInputBase-formControl .MuiInputBase-input::-ms-input-placeholder {
            opacity: 0 !important;
        }

        label[data-shrink=false] + .MuiInputBase-formControl .MuiInputBase-input:focus::-webkit-input-placeholder {
            opacity: 0.42;
        }

        label[data-shrink=false] + .MuiInputBase-formControl .MuiInputBase-input:focus::-moz-placeholder {
            opacity: 0.42;
        }

        label[data-shrink=false] + .MuiInputBase-formControl .MuiInputBase-input:focus:-ms-input-placeholder {
            opacity: 0.42;
        }

        label[data-shrink=false] + .MuiInputBase-formControl .MuiInputBase-input:focus::-ms-input-placeholder {
            opacity: 0.42;
        }

        .MuiInputBase-inputMarginDense {
            padding-top: 3px;
        }

        .MuiInputBase-inputMultiline {
            height: auto;
            resize: none;
            padding: 0;
        }

        .MuiInputBase-inputTypeSearch {
            -moz-appearance: textfield;
            -webkit-appearance: textfield;
        }

        .MuiInput-root {
            position: relative;
        }

        label + .MuiInput-formControl {
            margin-top: 16px;
        }

        .MuiInput-colorSecondary.MuiInput-underline:after {
            border-bottom-color: #f50057;
        }

        .MuiInput-underline:after {
            left: 0;
            right: 0;
            bottom: 0;
            content: "";
            position: absolute;
            transform: scaleX(0);
            transition: transform 200ms cubic-bezier(0.0, 0, 0.2, 1) 0ms;
            border-bottom: 2px solid #3f51b5;
            pointer-events: none;
        }

        .MuiInput-underline.Mui-focused:after {
            transform: scaleX(1);
        }

        .MuiInput-underline.Mui-error:after {
            transform: scaleX(1);
            border-bottom-color: #f44336;
        }

        .MuiInput-underline:before {
            left: 0;
            right: 0;
            bottom: 0;
            content: "\00a0";
            position: absolute;
            transition: border-bottom-color 200ms cubic-bezier(0.4, 0, 0.2, 1) 0ms;
            border-bottom: 1px solid rgba(0, 0, 0, 0.42);
            pointer-events: none;
        }

        .MuiInput-underline:hover:not(.Mui-disabled):before {
            border-bottom: 2px solid rgba(0, 0, 0, 0.87);
        }

        .MuiInput-underline.Mui-disabled:before {
            border-bottom-style: dotted;
        }

        @media (hover: none) {
            .MuiInput-underline:hover:not(.Mui-disabled):before {
                border-bottom: 1px solid rgba(0, 0, 0, 0.42);
            }
        }

        .MuiButton-root {
            color: rgba(0, 0, 0, 0.87);
            padding: 6px 16px;
            font-size: 0.875rem;
            min-width: 64px;
            box-sizing: border-box;
            transition: background-color 250ms cubic-bezier(0.4, 0, 0.2, 1) 0ms,box-shadow 250ms cubic-bezier(0.4, 0, 0.2, 1) 0ms,border 250ms cubic-bezier(0.4, 0, 0.2, 1) 0ms;
            font-family: "Roboto", "Helvetica", "Arial", sans-serif;
            font-weight: 500;
            line-height: 1.75;
            border-radius: 4px;
            letter-spacing: 0.02857em;
            text-transform: uppercase;
        }

            .MuiButton-root:hover {
                text-decoration: none;
                background-color: rgba(0, 0, 0, 0.04);
            }

            .MuiButton-root.Mui-disabled {
                color: rgba(0, 0, 0, 0.26);
            }

        @media (hover: none) {
            .MuiButton-root:hover {
                background-color: transparent;
            }
        }

        .MuiButton-root:hover.Mui-disabled {
            background-color: transparent;
        }

        .MuiButton-label {
            width: 100%;
            display: inherit;
            align-items: inherit;
            justify-content: inherit;
        }

        .MuiButton-text {
            padding: 6px 8px;
        }

        .MuiButton-textPrimary {
            color: #3f51b5;
        }

            .MuiButton-textPrimary:hover {
                background-color: rgba(63, 81, 181, 0.04);
            }

        @media (hover: none) {
            .MuiButton-textPrimary:hover {
                background-color: transparent;
            }
        }

        .MuiButton-textSecondary {
            color: #f50057;
        }

            .MuiButton-textSecondary:hover {
                background-color: rgba(245, 0, 87, 0.04);
            }

        @media (hover: none) {
            .MuiButton-textSecondary:hover {
                background-color: transparent;
            }
        }

        .MuiButton-outlined {
            border: 1px solid rgba(0, 0, 0, 0.23);
            padding: 5px 15px;
        }

            .MuiButton-outlined.Mui-disabled {
                border: 1px solid rgba(0, 0, 0, 0.12);
            }

        .MuiButton-outlinedPrimary {
            color: #3f51b5;
            border: 1px solid rgba(63, 81, 181, 0.5);
        }

            .MuiButton-outlinedPrimary:hover {
                border: 1px solid #3f51b5;
                background-color: rgba(63, 81, 181, 0.04);
            }

        @media (hover: none) {
            .MuiButton-outlinedPrimary:hover {
                background-color: transparent;
            }
        }

        .MuiButton-outlinedSecondary {
            color: #f50057;
            border: 1px solid rgba(245, 0, 87, 0.5);
        }

            .MuiButton-outlinedSecondary:hover {
                border: 1px solid #f50057;
                background-color: rgba(245, 0, 87, 0.04);
            }

            .MuiButton-outlinedSecondary.Mui-disabled {
                border: 1px solid rgba(0, 0, 0, 0.26);
            }

        @media (hover: none) {
            .MuiButton-outlinedSecondary:hover {
                background-color: transparent;
            }
        }

        .MuiButton-contained {
            color: rgba(0, 0, 0, 0.87);
            box-shadow: 0px 3px 1px -2px rgba(0,0,0,0.2),0px 2px 2px 0px rgba(0,0,0,0.14),0px 1px 5px 0px rgba(0,0,0,0.12);
            background-color: #e0e0e0;
        }

            .MuiButton-contained:hover {
                box-shadow: 0px 2px 4px -1px rgba(0,0,0,0.2),0px 4px 5px 0px rgba(0,0,0,0.14),0px 1px 10px 0px rgba(0,0,0,0.12);
                background-color: #d5d5d5;
            }

            .MuiButton-contained.Mui-focusVisible {
                box-shadow: 0px 3px 5px -1px rgba(0,0,0,0.2),0px 6px 10px 0px rgba(0,0,0,0.14),0px 1px 18px 0px rgba(0,0,0,0.12);
            }

            .MuiButton-contained:active {
                box-shadow: 0px 5px 5px -3px rgba(0,0,0,0.2),0px 8px 10px 1px rgba(0,0,0,0.14),0px 3px 14px 2px rgba(0,0,0,0.12);
            }

            .MuiButton-contained.Mui-disabled {
                color: rgba(0, 0, 0, 0.26);
                box-shadow: none;
                background-color: rgba(0, 0, 0, 0.12);
            }

        @media (hover: none) {
            .MuiButton-contained:hover {
                box-shadow: 0px 3px 1px -2px rgba(0,0,0,0.2),0px 2px 2px 0px rgba(0,0,0,0.14),0px 1px 5px 0px rgba(0,0,0,0.12);
                background-color: #e0e0e0;
            }
        }

        .MuiButton-contained:hover.Mui-disabled {
            background-color: rgba(0, 0, 0, 0.12);
        }

        .MuiButton-containedPrimary {
            color: #fff;
            background-color: #3f51b5;
        }

            .MuiButton-containedPrimary:hover {
                background-color: #303f9f;
            }

        @media (hover: none) {
            .MuiButton-containedPrimary:hover {
                background-color: #3f51b5;
            }
        }

        .MuiButton-containedSecondary {
            color: #fff;
            background-color: #f50057;
        }

            .MuiButton-containedSecondary:hover {
                background-color: #c51162;
            }

        @media (hover: none) {
            .MuiButton-containedSecondary:hover {
                background-color: #f50057;
            }
        }

        .MuiButton-disableElevation {
            box-shadow: none;
        }

            .MuiButton-disableElevation:hover {
                box-shadow: none;
            }

            .MuiButton-disableElevation.Mui-focusVisible {
                box-shadow: none;
            }

            .MuiButton-disableElevation:active {
                box-shadow: none;
            }

            .MuiButton-disableElevation.Mui-disabled {
                box-shadow: none;
            }

        .MuiButton-colorInherit {
            color: inherit;
            border-color: currentColor;
        }

        .MuiButton-textSizeSmall {
            padding: 4px 5px;
            font-size: 0.8125rem;
        }

        .MuiButton-textSizeLarge {
            padding: 8px 11px;
            font-size: 0.9375rem;
        }

        .MuiButton-outlinedSizeSmall {
            padding: 3px 9px;
            font-size: 0.8125rem;
        }

        .MuiButton-outlinedSizeLarge {
            padding: 7px 21px;
            font-size: 0.9375rem;
        }

        .MuiButton-containedSizeSmall {
            padding: 4px 10px;
            font-size: 0.8125rem;
        }

        .MuiButton-containedSizeLarge {
            padding: 8px 22px;
            font-size: 0.9375rem;
        }

        .MuiButton-fullWidth {
            width: 100%;
        }

        .MuiButton-startIcon {
            display: inherit;
            margin-left: -4px;
            margin-right: 8px;
        }

            .MuiButton-startIcon.MuiButton-iconSizeSmall {
                margin-left: -2px;
            }

        .MuiButton-endIcon {
            display: inherit;
            margin-left: 8px;
            margin-right: -4px;
        }

            .MuiButton-endIcon.MuiButton-iconSizeSmall {
                margin-right: -2px;
            }

        .MuiButton-iconSizeSmall > *:first-child {
            font-size: 18px;
        }

        .MuiButton-iconSizeMedium > *:first-child {
            font-size: 20px;
        }

        .MuiButton-iconSizeLarge > *:first-child {
            font-size: 22px;
        }

        .MuiDrawer-docked {
            flex: 0 0 auto;
        }

        .MuiDrawer-paper {
            top: 0;
            flex: 1 0 auto;
            height: 100%;
            display: flex;
            outline: 0;
            z-index: 1200;
            position: fixed;
            overflow-y: auto;
            flex-direction: column;
            -webkit-overflow-scrolling: touch;
        }

        .MuiDrawer-paperAnchorLeft {
            left: 0;
            right: auto;
        }

        .MuiDrawer-paperAnchorRight {
            left: auto;
            right: 0;
        }

        .MuiDrawer-paperAnchorTop {
            top: 0;
            left: 0;
            right: 0;
            bottom: auto;
            height: auto;
            max-height: 100%;
        }

        .MuiDrawer-paperAnchorBottom {
            top: auto;
            left: 0;
            right: 0;
            bottom: 0;
            height: auto;
            max-height: 100%;
        }

        .MuiDrawer-paperAnchorDockedLeft {
            border-right: 1px solid rgba(0, 0, 0, 0.12);
        }

        .MuiDrawer-paperAnchorDockedTop {
            border-bottom: 1px solid rgba(0, 0, 0, 0.12);
        }

        .MuiDrawer-paperAnchorDockedRight {
            border-left: 1px solid rgba(0, 0, 0, 0.12);
        }

        .MuiDrawer-paperAnchorDockedBottom {
            border-top: 1px solid rgba(0, 0, 0, 0.12);
        }

        .MuiListItemText-root {
            flex: 1 1 auto;
            min-width: 0;
            margin-top: 4px;
            margin-bottom: 4px;
        }

        .MuiListItemText-multiline {
            margin-top: 6px;
            margin-bottom: 6px;
        }

        .MuiListItemText-inset {
            padding-left: 56px;
        }

        .MuiCollapse-container {
            height: 0;
            overflow: hidden;
            transition: height 300ms cubic-bezier(0.4, 0, 0.2, 1) 0ms;
        }

        .MuiCollapse-entered {
            height: auto;
            overflow: visible;
        }

        .MuiCollapse-hidden {
            visibility: hidden;
        }

        .MuiCollapse-wrapper {
            display: flex;
        }

        .MuiCollapse-wrapperInner {
            width: 100%;
        }

        .MuiIcon-root {
            width: 1em;
            height: 1em;
            overflow: hidden;
            font-size: 1.5rem;
            flex-shrink: 0;
            user-select: none;
        }

        .MuiIcon-colorPrimary {
            color: #3f51b5;
        }

        .MuiIcon-colorSecondary {
            color: #f50057;
        }

        .MuiIcon-colorAction {
            color: rgba(0, 0, 0, 0.54);
        }

        .MuiIcon-colorError {
            color: #f44336;
        }

        .MuiIcon-colorDisabled {
            color: rgba(0, 0, 0, 0.26);
        }

        .MuiIcon-fontSizeInherit {
            font-size: inherit;
        }

        .MuiIcon-fontSizeSmall {
            font-size: 1.25rem;
        }

        .MuiIcon-fontSizeLarge {
            font-size: 2.25rem;
        }

        @media (min-width:960px) {
            .jss8 {
                left: auto !important;
                right: 0 !important;
            }
        }

        @media (max-width:959.95px) {
            .jss8 {
                left: 0 !important;
                right: auto !important;
            }
        }

        .jss9 {
            top: 0;
            left: 0;
            width: 260px;
            border: none;
            bottom: 0;
            z-index: 1032;
            position: fixed;
            box-shadow: 0 10px 30px -12px rgba(0, 0, 0, 0.42), 0 4px 25px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 0, 0, 0.2);
            transition-duration: .2s, .2s, .35s;
            transition-property: top, bottom, width;
            transition-timing-function: linear, linear, ease;
        }

        @media (min-width:960px) {
            .jss9 {
                width: 260px;
                height: 100%;
                position: fixed;
            }
        }

        @media (max-width:959.95px) {
            .jss9 {
                top: 0;
                left: auto;
                right: 0;
                width: 260px;
                height: 100vh;
                display: block;
                z-index: 1032;
                position: fixed;
                transform: translate3d(260px, 0, 0);
                border-top: none;
                box-shadow: 0 10px 30px -12px rgba(0, 0, 0, 0.42), 0 4px 25px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 0, 0, 0.2);
                overflow-y: visible;
                text-align: left;
                transition: all 0.33s cubic-bezier(0.685, 0.0473, 0.346, 1);
                visibility: visible;
                padding-left: 0;
                padding-right: 0px;
            }
        }

        .jss9:before, .jss9:after {
            top: 0;
            width: 100%;
            height: 100%;
            content: "";
            display: block;
            z-index: 3;
            position: absolute;
        }

        .jss10 {
            color: #FFF;
        }

            .jss10:after {
                opacity: .8;
                background: #000;
            }

        .jss11 {
            color: #FFF;
        }

            .jss11:after {
                opacity: .93;
                background: #00acc1;
            }

        .jss12 {
            color: #3C4858;
        }

            .jss12:after {
                opacity: .93;
                background: #FFF;
            }

        .jss13:after {
            background-color: hsla(0,0%,71%,.3) !important;
        }

        .jss14 {
            width: 80px !important;
        }

        .jss15 {
            margin: 0;
            display: block;
            padding: 15px 0px;
            z-index: 4;
            position: relative;
        }

            .jss15:after {
                right: 15px;
                width: calc(100% - 30px);
                bottom: 0;
                height: 1px;
                content: "";
                position: absolute;
                background-color: hsla(0,0%,100%,.3);
            }

        .jss16 {
            color: inherit;
            float: left;
            width: 30px;
            display: inline-block;
            opacity: 1;
            margin-top: 7px;
            max-height: 30px;
            text-align: center;
            transition: all 300ms linear;
            margin-left: 22px;
            margin-right: 18px;
        }

        .jss17 {
            float: right;
            margin-left: 26px;
            margin-right: 30px;
        }

        .jss18 {
            display: block;
            opacity: 1;
            padding: 5px 0px;
            overflow: hidden;
            font-size: 18px;
            transform: translate3d(0px, 0, 0);
            transition: all 300ms linear;
            font-family: "Roboto", "Helvetica", "Arial", sans-serif;
            font-weight: 400;
            line-height: 30px;
            white-space: nowrap;
            text-transform: uppercase;
        }

            .jss18, .jss18:hover, .jss18:focus {
                color: inherit;
            }

        .jss19 {
            text-align: right;
        }

        .jss20 {
            opacity: 0;
            transform: translate3d(-25px, 0, 0);
        }

        .jss21 {
            transform: translate3d(25px, 0, 0);
        }

        .jss22 {
            width: 35px;
            border: 0;
            vertical-align: middle;
        }

        .jss23 {
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            display: block;
            z-index: 1;
            position: absolute;
            transition: all 300ms linear;
            background-size: cover;
            background-position: center center;
        }

        .jss24 {
            color: inherit;
            list-style: none;
            margin-top: 15px;
            padding-top: 0;
            padding-left: 0;
            margin-bottom: 0;
            padding-bottom: 0;
        }

            .jss24:before, .jss24:after {
                content: " ";
                display: table;
            }

            .jss24:after {
                clear: both;
            }

        .jss25 {
            color: inherit;
            margin: 0;
            display: block;
            padding: 0;
            position: relative;
            text-decoration: none;
        }

        .jss26:last-child {
            padding-bottom: 0px;
        }

        .jss27 {
            width: auto;
            margin: 10px 15px 0;
            display: block;
            padding: 10px 15px;
            position: relative;
            transition: all 300ms linear;
            font-family: "Roboto", "Helvetica", "Arial", sans-serif;
            font-weight: 300;
            line-height: 1.5em;
            padding-left: 10px;
            border-radius: 3px;
            padding-right: 10px;
            background-color: transparent;
        }

            .jss27:hover {
                outline: none;
                box-shadow: none;
                background-color: rgba(200, 200, 200, 0.2);
            }

            .jss27, .jss27:hover, .jss27:focus {
                color: inherit;
            }

        .jss28 {
            top: 3px;
            color: inherit;
            float: left;
            width: 30px;
            height: 24px;
            opacity: 0.8;
            position: inherit;
            text-align: center;
            margin-right: 15px;
            vertical-align: middle;
        }

        .jss29 {
            float: right;
            margin-left: 15px;
            margin-right: 1px;
        }

        .jss30 {
            color: inherit;
            height: auto;
            margin: 0;
            display: block;
            opacity: 1;
            padding: 0 16px !important;
            position: relative;
            font-size: 14px;
            transform: translate3d(0px, 0, 0);
            transition: transform 300ms ease 0s, opacity 300ms ease 0s;
            font-family: "Roboto", "Helvetica", "Arial", sans-serif;
            font-weight: 300;
            line-height: 30px;
            white-space: nowrap;
        }

        .jss31 {
            line-height: 22px;
        }

        .jss32 {
            text-align: right;
            margin-right: 45px;
        }

        .jss33 {
            opacity: 0;
            transform: translate3d(-25px, 0, 0);
        }

        .jss34 {
            transform: translate3d(25px, 0, 0) !important;
        }

        .jss35 {
            margin-top: 0;
        }

            .jss35 .jss45 {
                margin-top: 8px;
            }

        .jss36 {
            margin: 10px 0 0 0;
            display: block;
            padding: 0;
            position: relative;
            text-decoration: none;
        }

        .jss37 {
            outline: none;
            box-shadow: none;
            background-color: rgba(200, 200, 200, 0.2);
        }

        .jss38 {
            width: auto;
            margin: 0 15px;
            display: block;
            padding: 10px;
            position: relative;
            transition: all 300ms linear;
            font-family: "Roboto", "Helvetica", "Arial", sans-serif;
            font-weight: 300;
            line-height: 1.5em;
            border-radius: 3px;
            background-color: transparent;
        }

            .jss38:hover {
                outline: none;
                box-shadow: none;
                background-color: rgba(200, 200, 200, 0.2);
            }

            .jss38, .jss38:hover, .jss38:focus {
                color: inherit;
            }

        .jss39 {
            color: inherit;
            float: left;
            width: 30px;
            display: inherit;
            position: relative;
            font-size: 14px;
            text-align: center;
            transition: transform 300ms ease 0s, opacity 300ms ease 0s;
            font-family: "Roboto", "Helvetica", "Arial", sans-serif;
            font-weight: 300;
            line-height: 1.5em;
            margin-right: 15px;
            letter-spacing: 1px;
            text-transform: uppercase;
        }

        .jss40 {
            float: right;
            margin-left: 30px;
            margin-right: 1px;
        }

        .jss41 {
            color: inherit;
            margin: 0;
            display: block;
            opacity: 1;
            position: relative;
            font-size: 14px;
            transform: translateX(0px);
            transition: transform 300ms ease 0s, opacity 300ms ease 0s;
            font-family: "Roboto", "Helvetica", "Arial", sans-serif;
            font-weight: 300;
            line-height: 1.5em;
            white-space: nowrap;
        }

        .jss42 {
            text-align: right;
        }

        .jss43 {
            transform: translate3d(25px, 0, 0) !important;
        }

        .jss44 {
            opacity: 0;
            transform: translate3d(-25px, 0, 0);
        }

        .jss45 {
            right: 18px;
            width: 0;
            height: 0;
            display: inline-block;
            position: absolute;
            border-top: 4px solid;
            margin-top: 13px;
            transition: all 150ms ease-in;
            border-left: 4px solid transparent;
            margin-left: 2px;
            border-right: 4px solid transparent;
            vertical-align: middle;
        }

        .jss46 {
            margin-top: 10px;
        }

        .jss47 {
            left: 11px;
            right: auto;
        }

        .jss48 {
            transform: rotate(180deg);
        }

        .jss49, .jss49:hover, .jss49:focus {
            color: #FFF;
            box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(156, 39, 176,.4);
            background-color: #9c27b0;
        }

        .jss50, .jss50:hover, .jss50:focus {
            color: #FFF;
            box-shadow: 0 12px 20px -10px rgba(0, 172, 193,.28), 0 4px 20px 0 rgba(0, 0, 0,.12), 0 7px 8px -5px rgba(0, 172, 193,.2);
            background-color: #00acc1;
        }

        .jss51, .jss51:hover, .jss51:focus {
            color: #FFF;
            box-shadow: 0 12px 20px -10px rgba(76, 175, 80,.28), 0 4px 20px 0 rgba(0, 0, 0,.12), 0 7px 8px -5px rgba(76, 175, 80,.2);
            background-color: #4caf50;
        }

        .jss52, .jss52:hover, .jss52:focus {
            color: #FFF;
            box-shadow: 0 12px 20px -10px rgba(255, 152, 0,.28), 0 4px 20px 0 rgba(0, 0, 0,.12), 0 7px 8px -5px rgba(255, 152, 0,.2);
            background-color: #ff9800;
        }

        .jss53, .jss53:hover, .jss53:focus {
            color: #FFF;
            box-shadow: 0 12px 20px -10px rgba(244, 67, 54,.28), 0 4px 20px 0 rgba(0, 0, 0,.12), 0 7px 8px -5px rgba(244, 67, 54,.2);
            background-color: #f44336;
        }

        .jss54, .jss54:hover, .jss54:focus {
            color: #3C4858;
            box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(60, 72, 88,.4);
            background-color: #FFF;
        }

        .jss55, .jss55:hover, .jss55:focus {
            color: #FFF;
            box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(233, 30, 99,.4);
            background-color: #e91e63;
        }

        .jss56 {
            color: inherit;
            width: 260px;
            height: calc(100vh - 75px);
            z-index: 4;
            overflow: auto;
            position: relative;
            padding-bottom: 30px;
            overflow-scrolling: touch;
            transition-duration: .2s, .2s, .35s;
            transition-property: top, bottom, width;
            transition-timing-function: linear, linear, ease;
        }

        .jss57 {
            overflow: hidden !important;
        }

        .jss58 {
            margin: 20px auto 0;
            position: relative;
            padding-bottom: 20px;
        }

            .jss58:after {
                right: 15px;
                width: calc(100% - 30px);
                bottom: 0;
                height: 1px;
                content: "";
                position: absolute;
                background-color: hsla(0,0%,100%,.3);
            }

        .jss59 {
            float: left;
            width: 34px;
            height: 34px;
            z-index: 5;
            overflow: hidden;
            box-shadow: 0 10px 30px -12px rgba(0, 0, 0, 0.42), 0 4px 25px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 0, 0, 0.2);
            transition: all 300ms linear;
            margin-left: 23px;
            margin-right: 11px;
            border-radius: 50%;
        }

        .jss60 {
            float: right;
            margin-left: 12px;
            margin-right: 24px;
        }

        .jss61 {
            width: 100%;
            border: 0;
            vertical-align: middle;
        }

        .jss62 {
            margin: 0;
            padding: 6px 15px;
        }

            .jss62:hover {
                background: none;
            }

        .jss63 {
            margin-top: -4px;
        }

        .MuiIconButton-root {
            flex: 0 0 auto;
            color: rgba(0, 0, 0, 0.54);
            padding: 12px;
            overflow: visible;
            font-size: 1.5rem;
            text-align: center;
            transition: background-color 150ms cubic-bezier(0.4, 0, 0.2, 1) 0ms;
            border-radius: 50%;
        }

            .MuiIconButton-root:hover {
                background-color: rgba(0, 0, 0, 0.04);
            }

            .MuiIconButton-root.Mui-disabled {
                color: rgba(0, 0, 0, 0.26);
                background-color: transparent;
            }

        @media (hover: none) {
            .MuiIconButton-root:hover {
                background-color: transparent;
            }
        }

        .MuiIconButton-edgeStart {
            margin-left: -12px;
        }

        .MuiIconButton-sizeSmall.MuiIconButton-edgeStart {
            margin-left: -3px;
        }

        .MuiIconButton-edgeEnd {
            margin-right: -12px;
        }

        .MuiIconButton-sizeSmall.MuiIconButton-edgeEnd {
            margin-right: -3px;
        }

        .MuiIconButton-colorInherit {
            color: inherit;
        }

        .MuiIconButton-colorPrimary {
            color: #3f51b5;
        }

            .MuiIconButton-colorPrimary:hover {
                background-color: rgba(63, 81, 181, 0.04);
            }

        @media (hover: none) {
            .MuiIconButton-colorPrimary:hover {
                background-color: transparent;
            }
        }

        .MuiIconButton-colorSecondary {
            color: #f50057;
        }

            .MuiIconButton-colorSecondary:hover {
                background-color: rgba(245, 0, 87, 0.04);
            }

        @media (hover: none) {
            .MuiIconButton-colorSecondary:hover {
                background-color: transparent;
            }
        }

        .MuiIconButton-sizeSmall {
            padding: 3px;
            font-size: 1.125rem;
        }

        .MuiIconButton-label {
            width: 100%;
            display: flex;
            align-items: inherit;
            justify-content: inherit;
        }

        .jss519 {
            padding: 9px;
        }

        .jss522 {
            top: 0;
            left: 0;
            width: 100%;
            cursor: inherit;
            height: 100%;
            margin: 0;
            opacity: 0;
            padding: 0;
            z-index: 1;
            position: absolute;
        }

        .MuiSwitch-root {
            width: 58px;
            height: 38px;
            display: inline-flex;
            padding: 12px;
            z-index: 0;
            overflow: hidden;
            position: relative;
            box-sizing: border-box;
            flex-shrink: 0;
            vertical-align: middle;
        }

        @media print {
            .MuiSwitch-root {
                color-adjust: exact;
            }
        }

        .MuiSwitch-edgeStart {
            margin-left: -8px;
        }

        .MuiSwitch-edgeEnd {
            margin-right: -8px;
        }

        .MuiSwitch-switchBase {
            top: 0;
            left: 0;
            color: #fafafa;
            z-index: 1;
            position: absolute;
            transition: left 150ms cubic-bezier(0.4, 0, 0.2, 1) 0ms,transform 150ms cubic-bezier(0.4, 0, 0.2, 1) 0ms;
        }

            .MuiSwitch-switchBase.Mui-checked {
                transform: translateX(20px);
            }

            .MuiSwitch-switchBase.Mui-disabled {
                color: #bdbdbd;
            }

            .MuiSwitch-switchBase.Mui-checked + .MuiSwitch-track {
                opacity: 0.5;
            }

            .MuiSwitch-switchBase.Mui-disabled + .MuiSwitch-track {
                opacity: 0.12;
            }

        .MuiSwitch-colorPrimary.Mui-checked {
            color: #3f51b5;
        }

        .MuiSwitch-colorPrimary.Mui-disabled {
            color: #bdbdbd;
        }

        .MuiSwitch-colorPrimary.Mui-checked + .MuiSwitch-track {
            background-color: #3f51b5;
        }

        .MuiSwitch-colorPrimary.Mui-disabled + .MuiSwitch-track {
            background-color: #000;
        }

        .MuiSwitch-colorPrimary.Mui-checked:hover {
            background-color: rgba(63, 81, 181, 0.04);
        }

        @media (hover: none) {
            .MuiSwitch-colorPrimary.Mui-checked:hover {
                background-color: transparent;
            }
        }

        .MuiSwitch-colorSecondary.Mui-checked {
            color: #f50057;
        }

        .MuiSwitch-colorSecondary.Mui-disabled {
            color: #bdbdbd;
        }

        .MuiSwitch-colorSecondary.Mui-checked + .MuiSwitch-track {
            background-color: #f50057;
        }

        .MuiSwitch-colorSecondary.Mui-disabled + .MuiSwitch-track {
            background-color: #000;
        }

        .MuiSwitch-colorSecondary.Mui-checked:hover {
            background-color: rgba(245, 0, 87, 0.04);
        }

        @media (hover: none) {
            .MuiSwitch-colorSecondary.Mui-checked:hover {
                background-color: transparent;
            }
        }

        .MuiSwitch-sizeSmall {
            width: 40px;
            height: 24px;
            padding: 7px;
        }

            .MuiSwitch-sizeSmall .MuiSwitch-thumb {
                width: 16px;
                height: 16px;
            }

            .MuiSwitch-sizeSmall .MuiSwitch-switchBase {
                padding: 4px;
            }

                .MuiSwitch-sizeSmall .MuiSwitch-switchBase.Mui-checked {
                    transform: translateX(16px);
                }

        .MuiSwitch-input {
            left: -100%;
            width: 300%;
        }

        .MuiSwitch-thumb {
            width: 20px;
            height: 20px;
            box-shadow: 0px 2px 1px -1px rgba(0,0,0,0.2),0px 1px 1px 0px rgba(0,0,0,0.14),0px 1px 3px 0px rgba(0,0,0,0.12);
            border-radius: 50%;
            background-color: currentColor;
        }

        .MuiSwitch-track {
            width: 100%;
            height: 100%;
            opacity: 0.38;
            z-index: -1;
            transition: opacity 150ms cubic-bezier(0.4, 0, 0.2, 1) 0ms,background-color 150ms cubic-bezier(0.4, 0, 0.2, 1) 0ms;
            border-radius: 7px;
            background-color: #000;
        }

        .MuiGrid-container {
            width: 100%;
            display: flex;
            flex-wrap: wrap;
            box-sizing: border-box;
        }

        .MuiGrid-item {
            margin: 0;
            box-sizing: border-box;
        }

        .MuiGrid-zeroMinWidth {
            min-width: 0;
        }

        .MuiGrid-direction-xs-column {
            flex-direction: column;
        }

        .MuiGrid-direction-xs-column-reverse {
            flex-direction: column-reverse;
        }

        .MuiGrid-direction-xs-row-reverse {
            flex-direction: row-reverse;
        }

        .MuiGrid-wrap-xs-nowrap {
            flex-wrap: nowrap;
        }

        .MuiGrid-wrap-xs-wrap-reverse {
            flex-wrap: wrap-reverse;
        }

        .MuiGrid-align-items-xs-center {
            align-items: center;
        }

        .MuiGrid-align-items-xs-flex-start {
            align-items: flex-start;
        }

        .MuiGrid-align-items-xs-flex-end {
            align-items: flex-end;
        }

        .MuiGrid-align-items-xs-baseline {
            align-items: baseline;
        }

        .MuiGrid-align-content-xs-center {
            align-content: center;
        }

        .MuiGrid-align-content-xs-flex-start {
            align-content: flex-start;
        }

        .MuiGrid-align-content-xs-flex-end {
            align-content: flex-end;
        }

        .MuiGrid-align-content-xs-space-between {
            align-content: space-between;
        }

        .MuiGrid-align-content-xs-space-around {
            align-content: space-around;
        }

        .MuiGrid-justify-xs-center {
            justify-content: center;
        }

        .MuiGrid-justify-xs-flex-end {
            justify-content: flex-end;
        }

        .MuiGrid-justify-xs-space-between {
            justify-content: space-between;
        }

        .MuiGrid-justify-xs-space-around {
            justify-content: space-around;
        }

        .MuiGrid-justify-xs-space-evenly {
            justify-content: space-evenly;
        }

        .MuiGrid-spacing-xs-1 {
            width: calc(100% + 8px);
            margin: -4px;
        }

            .MuiGrid-spacing-xs-1 > .MuiGrid-item {
                padding: 4px;
            }

        .MuiGrid-spacing-xs-2 {
            width: calc(100% + 16px);
            margin: -8px;
        }

            .MuiGrid-spacing-xs-2 > .MuiGrid-item {
                padding: 8px;
            }

        .MuiGrid-spacing-xs-3 {
            width: calc(100% + 24px);
            margin: -12px;
        }

            .MuiGrid-spacing-xs-3 > .MuiGrid-item {
                padding: 12px;
            }

        .MuiGrid-spacing-xs-4 {
            width: calc(100% + 32px);
            margin: -16px;
        }

            .MuiGrid-spacing-xs-4 > .MuiGrid-item {
                padding: 16px;
            }

        .MuiGrid-spacing-xs-5 {
            width: calc(100% + 40px);
            margin: -20px;
        }

            .MuiGrid-spacing-xs-5 > .MuiGrid-item {
                padding: 20px;
            }

        .MuiGrid-spacing-xs-6 {
            width: calc(100% + 48px);
            margin: -24px;
        }

            .MuiGrid-spacing-xs-6 > .MuiGrid-item {
                padding: 24px;
            }

        .MuiGrid-spacing-xs-7 {
            width: calc(100% + 56px);
            margin: -28px;
        }

            .MuiGrid-spacing-xs-7 > .MuiGrid-item {
                padding: 28px;
            }

        .MuiGrid-spacing-xs-8 {
            width: calc(100% + 64px);
            margin: -32px;
        }

            .MuiGrid-spacing-xs-8 > .MuiGrid-item {
                padding: 32px;
            }

        .MuiGrid-spacing-xs-9 {
            width: calc(100% + 72px);
            margin: -36px;
        }

            .MuiGrid-spacing-xs-9 > .MuiGrid-item {
                padding: 36px;
            }

        .MuiGrid-spacing-xs-10 {
            width: calc(100% + 80px);
            margin: -40px;
        }

            .MuiGrid-spacing-xs-10 > .MuiGrid-item {
                padding: 40px;
            }

        .MuiGrid-grid-xs-auto {
            flex-grow: 0;
            max-width: none;
            flex-basis: auto;
        }

        .MuiGrid-grid-xs-true {
            flex-grow: 1;
            max-width: 100%;
            flex-basis: 0;
        }

        .MuiGrid-grid-xs-1 {
            flex-grow: 0;
            max-width: 8.333333%;
            flex-basis: 8.333333%;
        }

        .MuiGrid-grid-xs-2 {
            flex-grow: 0;
            max-width: 16.666667%;
            flex-basis: 16.666667%;
        }

        .MuiGrid-grid-xs-3 {
            flex-grow: 0;
            max-width: 25%;
            flex-basis: 25%;
        }

        .MuiGrid-grid-xs-4 {
            flex-grow: 0;
            max-width: 33.333333%;
            flex-basis: 33.333333%;
        }

        .MuiGrid-grid-xs-5 {
            flex-grow: 0;
            max-width: 41.666667%;
            flex-basis: 41.666667%;
        }

        .MuiGrid-grid-xs-6 {
            flex-grow: 0;
            max-width: 50%;
            flex-basis: 50%;
        }

        .MuiGrid-grid-xs-7 {
            flex-grow: 0;
            max-width: 58.333333%;
            flex-basis: 58.333333%;
        }

        .MuiGrid-grid-xs-8 {
            flex-grow: 0;
            max-width: 66.666667%;
            flex-basis: 66.666667%;
        }

        .MuiGrid-grid-xs-9 {
            flex-grow: 0;
            max-width: 75%;
            flex-basis: 75%;
        }

        .MuiGrid-grid-xs-10 {
            flex-grow: 0;
            max-width: 83.333333%;
            flex-basis: 83.333333%;
        }

        .MuiGrid-grid-xs-11 {
            flex-grow: 0;
            max-width: 91.666667%;
            flex-basis: 91.666667%;
        }

        .MuiGrid-grid-xs-12 {
            flex-grow: 0;
            max-width: 100%;
            flex-basis: 100%;
        }

        @media (min-width:600px) {
            .MuiGrid-grid-sm-auto {
                flex-grow: 0;
                max-width: none;
                flex-basis: auto;
            }

            .MuiGrid-grid-sm-true {
                flex-grow: 1;
                max-width: 100%;
                flex-basis: 0;
            }

            .MuiGrid-grid-sm-1 {
                flex-grow: 0;
                max-width: 8.333333%;
                flex-basis: 8.333333%;
            }

            .MuiGrid-grid-sm-2 {
                flex-grow: 0;
                max-width: 16.666667%;
                flex-basis: 16.666667%;
            }

            .MuiGrid-grid-sm-3 {
                flex-grow: 0;
                max-width: 25%;
                flex-basis: 25%;
            }

            .MuiGrid-grid-sm-4 {
                flex-grow: 0;
                max-width: 33.333333%;
                flex-basis: 33.333333%;
            }

            .MuiGrid-grid-sm-5 {
                flex-grow: 0;
                max-width: 41.666667%;
                flex-basis: 41.666667%;
            }

            .MuiGrid-grid-sm-6 {
                flex-grow: 0;
                max-width: 50%;
                flex-basis: 50%;
            }

            .MuiGrid-grid-sm-7 {
                flex-grow: 0;
                max-width: 58.333333%;
                flex-basis: 58.333333%;
            }

            .MuiGrid-grid-sm-8 {
                flex-grow: 0;
                max-width: 66.666667%;
                flex-basis: 66.666667%;
            }

            .MuiGrid-grid-sm-9 {
                flex-grow: 0;
                max-width: 75%;
                flex-basis: 75%;
            }

            .MuiGrid-grid-sm-10 {
                flex-grow: 0;
                max-width: 83.333333%;
                flex-basis: 83.333333%;
            }

            .MuiGrid-grid-sm-11 {
                flex-grow: 0;
                max-width: 91.666667%;
                flex-basis: 91.666667%;
            }

            .MuiGrid-grid-sm-12 {
                flex-grow: 0;
                max-width: 100%;
                flex-basis: 100%;
            }
        }

        @media (min-width:960px) {
            .MuiGrid-grid-md-auto {
                flex-grow: 0;
                max-width: none;
                flex-basis: auto;
            }

            .MuiGrid-grid-md-true {
                flex-grow: 1;
                max-width: 100%;
                flex-basis: 0;
            }

            .MuiGrid-grid-md-1 {
                flex-grow: 0;
                max-width: 8.333333%;
                flex-basis: 8.333333%;
            }

            .MuiGrid-grid-md-2 {
                flex-grow: 0;
                max-width: 16.666667%;
                flex-basis: 16.666667%;
            }

            .MuiGrid-grid-md-3 {
                flex-grow: 0;
                max-width: 25%;
                flex-basis: 25%;
            }

            .MuiGrid-grid-md-4 {
                flex-grow: 0;
                max-width: 33.333333%;
                flex-basis: 33.333333%;
            }

            .MuiGrid-grid-md-5 {
                flex-grow: 0;
                max-width: 41.666667%;
                flex-basis: 41.666667%;
            }

            .MuiGrid-grid-md-6 {
                flex-grow: 0;
                max-width: 50%;
                flex-basis: 50%;
            }

            .MuiGrid-grid-md-7 {
                flex-grow: 0;
                max-width: 58.333333%;
                flex-basis: 58.333333%;
            }

            .MuiGrid-grid-md-8 {
                flex-grow: 0;
                max-width: 66.666667%;
                flex-basis: 66.666667%;
            }

            .MuiGrid-grid-md-9 {
                flex-grow: 0;
                max-width: 75%;
                flex-basis: 75%;
            }

            .MuiGrid-grid-md-10 {
                flex-grow: 0;
                max-width: 83.333333%;
                flex-basis: 83.333333%;
            }

            .MuiGrid-grid-md-11 {
                flex-grow: 0;
                max-width: 91.666667%;
                flex-basis: 91.666667%;
            }

            .MuiGrid-grid-md-12 {
                flex-grow: 0;
                max-width: 100%;
                flex-basis: 100%;
            }
        }

        @media (min-width:1280px) {
            .MuiGrid-grid-lg-auto {
                flex-grow: 0;
                max-width: none;
                flex-basis: auto;
            }

            .MuiGrid-grid-lg-true {
                flex-grow: 1;
                max-width: 100%;
                flex-basis: 0;
            }

            .MuiGrid-grid-lg-1 {
                flex-grow: 0;
                max-width: 8.333333%;
                flex-basis: 8.333333%;
            }

            .MuiGrid-grid-lg-2 {
                flex-grow: 0;
                max-width: 16.666667%;
                flex-basis: 16.666667%;
            }

            .MuiGrid-grid-lg-3 {
                flex-grow: 0;
                max-width: 25%;
                flex-basis: 25%;
            }

            .MuiGrid-grid-lg-4 {
                flex-grow: 0;
                max-width: 33.333333%;
                flex-basis: 33.333333%;
            }

            .MuiGrid-grid-lg-5 {
                flex-grow: 0;
                max-width: 41.666667%;
                flex-basis: 41.666667%;
            }

            .MuiGrid-grid-lg-6 {
                flex-grow: 0;
                max-width: 50%;
                flex-basis: 50%;
            }

            .MuiGrid-grid-lg-7 {
                flex-grow: 0;
                max-width: 58.333333%;
                flex-basis: 58.333333%;
            }

            .MuiGrid-grid-lg-8 {
                flex-grow: 0;
                max-width: 66.666667%;
                flex-basis: 66.666667%;
            }

            .MuiGrid-grid-lg-9 {
                flex-grow: 0;
                max-width: 75%;
                flex-basis: 75%;
            }

            .MuiGrid-grid-lg-10 {
                flex-grow: 0;
                max-width: 83.333333%;
                flex-basis: 83.333333%;
            }

            .MuiGrid-grid-lg-11 {
                flex-grow: 0;
                max-width: 91.666667%;
                flex-basis: 91.666667%;
            }

            .MuiGrid-grid-lg-12 {
                flex-grow: 0;
                max-width: 100%;
                flex-basis: 100%;
            }
        }

        @media (min-width:1920px) {
            .MuiGrid-grid-xl-auto {
                flex-grow: 0;
                max-width: none;
                flex-basis: auto;
            }

            .MuiGrid-grid-xl-true {
                flex-grow: 1;
                max-width: 100%;
                flex-basis: 0;
            }

            .MuiGrid-grid-xl-1 {
                flex-grow: 0;
                max-width: 8.333333%;
                flex-basis: 8.333333%;
            }

            .MuiGrid-grid-xl-2 {
                flex-grow: 0;
                max-width: 16.666667%;
                flex-basis: 16.666667%;
            }

            .MuiGrid-grid-xl-3 {
                flex-grow: 0;
                max-width: 25%;
                flex-basis: 25%;
            }

            .MuiGrid-grid-xl-4 {
                flex-grow: 0;
                max-width: 33.333333%;
                flex-basis: 33.333333%;
            }

            .MuiGrid-grid-xl-5 {
                flex-grow: 0;
                max-width: 41.666667%;
                flex-basis: 41.666667%;
            }

            .MuiGrid-grid-xl-6 {
                flex-grow: 0;
                max-width: 50%;
                flex-basis: 50%;
            }

            .MuiGrid-grid-xl-7 {
                flex-grow: 0;
                max-width: 58.333333%;
                flex-basis: 58.333333%;
            }

            .MuiGrid-grid-xl-8 {
                flex-grow: 0;
                max-width: 66.666667%;
                flex-basis: 66.666667%;
            }

            .MuiGrid-grid-xl-9 {
                flex-grow: 0;
                max-width: 75%;
                flex-basis: 75%;
            }

            .MuiGrid-grid-xl-10 {
                flex-grow: 0;
                max-width: 83.333333%;
                flex-basis: 83.333333%;
            }

            .MuiGrid-grid-xl-11 {
                flex-grow: 0;
                max-width: 91.666667%;
                flex-basis: 91.666667%;
            }

            .MuiGrid-grid-xl-12 {
                flex-grow: 0;
                max-width: 100%;
                flex-basis: 100%;
            }
        }

        .MuiCheckbox-root {
            color: rgba(0, 0, 0, 0.54);
        }

        .MuiCheckbox-colorPrimary.Mui-checked {
            color: #3f51b5;
        }

        .MuiCheckbox-colorPrimary.Mui-disabled {
            color: rgba(0, 0, 0, 0.26);
        }

        .MuiCheckbox-colorPrimary.Mui-checked:hover {
            background-color: rgba(63, 81, 181, 0.04);
        }

        @media (hover: none) {
            .MuiCheckbox-colorPrimary.Mui-checked:hover {
                background-color: transparent;
            }
        }

        .MuiCheckbox-colorSecondary.Mui-checked {
            color: #f50057;
        }

        .MuiCheckbox-colorSecondary.Mui-disabled {
            color: rgba(0, 0, 0, 0.26);
        }

        .MuiCheckbox-colorSecondary.Mui-checked:hover {
            background-color: rgba(245, 0, 87, 0.04);
        }

        @media (hover: none) {
            .MuiCheckbox-colorSecondary.Mui-checked:hover {
                background-color: transparent;
            }
        }

        .MuiTable-root {
            width: 100%;
            display: table;
            border-spacing: 0;
            border-collapse: collapse;
        }

            .MuiTable-root caption {
                color: rgba(0, 0, 0, 0.54);
                padding: 16px;
                font-size: 0.875rem;
                text-align: left;
                font-family: "Roboto", "Helvetica", "Arial", sans-serif;
                font-weight: 400;
                line-height: 1.43;
                caption-side: bottom;
                letter-spacing: 0.01071em;
            }

        .MuiTable-stickyHeader {
            border-collapse: separate;
        }

        .MuiTableBody-root {
            display: table-row-group;
        }

        .MuiTableCell-root {
            display: table-cell;
            padding: 16px;
            font-size: 0.875rem;
            text-align: left;
            font-family: "Roboto", "Helvetica", "Arial", sans-serif;
            font-weight: 400;
            line-height: 1.43;
            border-bottom: 1px solid rgba(224, 224, 224, 1);
            letter-spacing: 0.01071em;
            vertical-align: inherit;
        }

        .MuiTableCell-head {
            color: rgba(0, 0, 0, 0.87);
            font-weight: 500;
            line-height: 1.5rem;
        }

        .MuiTableCell-body {
            color: rgba(0, 0, 0, 0.87);
        }

        .MuiTableCell-footer {
            color: rgba(0, 0, 0, 0.54);
            font-size: 0.75rem;
            line-height: 1.3125rem;
        }

        .MuiTableCell-sizeSmall {
            padding: 6px 24px 6px 16px;
        }

            .MuiTableCell-sizeSmall:last-child {
                padding-right: 16px;
            }

            .MuiTableCell-sizeSmall.MuiTableCell-paddingCheckbox {
                width: 24px;
                padding: 0 12px 0 16px;
            }

                .MuiTableCell-sizeSmall.MuiTableCell-paddingCheckbox:last-child {
                    padding-left: 12px;
                    padding-right: 16px;
                }

                .MuiTableCell-sizeSmall.MuiTableCell-paddingCheckbox > * {
                    padding: 0;
                }

        .MuiTableCell-paddingCheckbox {
            width: 48px;
            padding: 0 0 0 4px;
        }

            .MuiTableCell-paddingCheckbox:last-child {
                padding-left: 0;
                padding-right: 4px;
            }

        .MuiTableCell-paddingNone {
            padding: 0;
        }

            .MuiTableCell-paddingNone:last-child {
                padding: 0;
            }

        .MuiTableCell-alignLeft {
            text-align: left;
        }

        .MuiTableCell-alignCenter {
            text-align: center;
        }

        .MuiTableCell-alignRight {
            text-align: right;
            flex-direction: row-reverse;
        }

        .MuiTableCell-alignJustify {
            text-align: justify;
        }

        .MuiTableCell-stickyHeader {
            top: 0;
            left: 0;
            z-index: 2;
            position: sticky;
            background-color: #fafafa;
        }

        .MuiTableHead-root {
            display: table-header-group;
        }

        .MuiTableRow-root {
            color: inherit;
            display: table-row;
            outline: 0;
            vertical-align: middle;
        }

            .MuiTableRow-root.MuiTableRow-hover:hover {
                background-color: rgba(0, 0, 0, 0.04);
            }

            .MuiTableRow-root.Mui-selected, .MuiTableRow-root.Mui-selected:hover {
                background-color: rgba(245, 0, 87, 0.08);
            }

        .jss471 {
            width: 100%;
            bottom: 0;
            height: 2px;
            position: absolute;
            transition: all 300ms cubic-bezier(0.4, 0, 0.2, 1) 0ms;
        }

        .jss472 {
            background-color: #3f51b5;
        }

        .jss473 {
            background-color: #f50057;
        }

        .jss474 {
            right: 0;
            width: 2px;
            height: 100%;
        }

        .MuiTabs-root {
            display: flex;
            overflow: hidden;
            min-height: 48px;
            -webkit-overflow-scrolling: touch;
        }

        .MuiTabs-vertical {
            flex-direction: column;
        }

        .MuiTabs-flexContainer {
            display: flex;
        }

        .MuiTabs-flexContainerVertical {
            flex-direction: column;
        }

        .MuiTabs-centered {
            justify-content: center;
        }

        .MuiTabs-scroller {
            flex: 1 1 auto;
            display: inline-block;
            position: relative;
            white-space: nowrap;
        }

        .MuiTabs-fixed {
            width: 100%;
            overflow-x: hidden;
        }

        .MuiTabs-scrollable {
            overflow-x: scroll;
            scrollbar-width: none;
        }

            .MuiTabs-scrollable::-webkit-scrollbar {
                display: none;
            }

        @media (max-width:599.95px) {
            .MuiTabs-scrollButtonsDesktop {
                display: none;
            }
        }

        .MuiTab-root {
            padding: 6px 12px;
            overflow: hidden;
            position: relative;
            font-size: 0.875rem;
            max-width: 264px;
            min-width: 72px;
            box-sizing: border-box;
            min-height: 48px;
            text-align: center;
            flex-shrink: 0;
            font-family: "Roboto", "Helvetica", "Arial", sans-serif;
            font-weight: 500;
            line-height: 1.75;
            white-space: normal;
            letter-spacing: 0.02857em;
            text-transform: uppercase;
        }

        @media (min-width:600px) {
            .MuiTab-root {
                min-width: 160px;
            }
        }

        .MuiTab-labelIcon {
            min-height: 72px;
            padding-top: 9px;
        }

            .MuiTab-labelIcon .MuiTab-wrapper > *:first-child {
                margin-bottom: 6px;
            }

        .MuiTab-textColorInherit {
            color: inherit;
            opacity: 0.7;
        }

            .MuiTab-textColorInherit.Mui-selected {
                opacity: 1;
            }

            .MuiTab-textColorInherit.Mui-disabled {
                opacity: 0.5;
            }

        .MuiTab-textColorPrimary {
            color: rgba(0, 0, 0, 0.54);
        }

            .MuiTab-textColorPrimary.Mui-selected {
                color: #3f51b5;
            }

            .MuiTab-textColorPrimary.Mui-disabled {
                color: rgba(0, 0, 0, 0.38);
            }

        .MuiTab-textColorSecondary {
            color: rgba(0, 0, 0, 0.54);
        }

            .MuiTab-textColorSecondary.Mui-selected {
                color: #f50057;
            }

            .MuiTab-textColorSecondary.Mui-disabled {
                color: rgba(0, 0, 0, 0.38);
            }

        .MuiTab-fullWidth {
            flex-grow: 1;
            max-width: none;
            flex-basis: 0;
            flex-shrink: 1;
        }

        .MuiTab-wrapped {
            font-size: 0.75rem;
            line-height: 1.5;
        }

        .MuiTab-wrapper {
            width: 100%;
            display: inline-flex;
            align-items: center;
            flex-direction: column;
            justify-content: center;
        }

        .MuiTooltip-popper {
            z-index: 1500;
            pointer-events: none;
        }

        .MuiTooltip-popperInteractive {
            pointer-events: auto;
        }

        .MuiTooltip-popperArrow[x-placement*="bottom"] .MuiTooltip-arrow {
            top: 0;
            left: 0;
            margin-top: -0.71em;
            margin-left: 4px;
            margin-right: 4px;
        }

        .MuiTooltip-popperArrow[x-placement*="top"] .MuiTooltip-arrow {
            left: 0;
            bottom: 0;
            margin-left: 4px;
            margin-right: 4px;
            margin-bottom: -0.71em;
        }

        .MuiTooltip-popperArrow[x-placement*="right"] .MuiTooltip-arrow {
            left: 0;
            width: 0.71em;
            height: 1em;
            margin-top: 4px;
            margin-left: -0.71em;
            margin-bottom: 4px;
        }

        .MuiTooltip-popperArrow[x-placement*="left"] .MuiTooltip-arrow {
            right: 0;
            width: 0.71em;
            height: 1em;
            margin-top: 4px;
            margin-right: -0.71em;
            margin-bottom: 4px;
        }

            .MuiTooltip-popperArrow[x-placement*="left"] .MuiTooltip-arrow::before {
                transform-origin: 0 0;
            }

        .MuiTooltip-popperArrow[x-placement*="right"] .MuiTooltip-arrow::before {
            transform-origin: 100% 100%;
        }

        .MuiTooltip-popperArrow[x-placement*="top"] .MuiTooltip-arrow::before {
            transform-origin: 100% 0;
        }

        .MuiTooltip-popperArrow[x-placement*="bottom"] .MuiTooltip-arrow::before {
            transform-origin: 0 100%;
        }

        .MuiTooltip-tooltip {
            color: #fff;
            padding: 4px 8px;
            font-size: 0.625rem;
            max-width: 300px;
            word-wrap: break-word;
            font-family: "Roboto", "Helvetica", "Arial", sans-serif;
            font-weight: 500;
            line-height: 1.4em;
            border-radius: 4px;
            background-color: rgba(97, 97, 97, 0.9);
        }

        .MuiTooltip-tooltipArrow {
            margin: 0;
            position: relative;
        }

        .MuiTooltip-arrow {
            color: rgba(97, 97, 97, 0.9);
            width: 1em;
            height: 0.71em;
            overflow: hidden;
            position: absolute;
            box-sizing: border-box;
        }

            .MuiTooltip-arrow::before {
                width: 100%;
                height: 100%;
                margin: auto;
                content: "";
                display: block;
                transform: rotate(45deg);
                background-color: currentColor;
            }

        .MuiTooltip-touch {
            padding: 8px 16px;
            font-size: 0.875rem;
            font-weight: 400;
            line-height: 1.14286em;
        }

        .MuiTooltip-tooltipPlacementLeft {
            margin: 0 24px;
            transform-origin: right center;
        }

        @media (min-width:600px) {
            .MuiTooltip-tooltipPlacementLeft {
                margin: 0 14px;
            }
        }

        .MuiTooltip-tooltipPlacementRight {
            margin: 0 24px;
            transform-origin: left center;
        }

        @media (min-width:600px) {
            .MuiTooltip-tooltipPlacementRight {
                margin: 0 14px;
            }
        }

        .MuiTooltip-tooltipPlacementTop {
            margin: 24px 0;
            transform-origin: center bottom;
        }

        @media (min-width:600px) {
            .MuiTooltip-tooltipPlacementTop {
                margin: 14px 0;
            }
        }

        .MuiTooltip-tooltipPlacementBottom {
            margin: 24px 0;
            transform-origin: center top;
        }

        @media (min-width:600px) {
            .MuiTooltip-tooltipPlacementBottom {
                margin: 14px 0;
            }
        }

        .jss1 {
            top: 0;
            height: 100vh;
            position: relative;
        }

            .jss1:after {
                clear: both;
                content: " ";
                display: table;
            }

        .jss2 {
            float: right;
            width: 100%;
            overflow: auto;
            position: relative;
            max-height: 100%;
            transition: all 0.33s cubic-bezier(0.685, 0.0473, 0.346, 1);
            overflow-scrolling: touch;
            transition-duration: .2s, .2s, .35s;
            transition-property: top, bottom, width;
            transition-timing-function: linear, linear, ease;
        }

        @media (min-width:960px) {
            .jss2 {
                width: calc(100% - 260px);
            }
        }

        .jss3 {
            padding: 30px 15px;
            margin-top: 70px;
            min-height: calc(100vh - 123px);
        }

        .jss4 {
            margin-left: auto;
            margin-right: auto;
            padding-left: 15px;
            padding-right: 15px;
        }

            .jss4:before, .jss4:after {
                content: " ";
                display: table;
            }

            .jss4:after {
                clear: both;
            }

        .jss5 {
            margin-top: 70px;
        }

        @media (min-width:960px) {
            .jss6 {
                width: calc(100% - 80px);
            }
        }

        .jss7 {
            overflow: hidden !important;
        }

        .jss79 {
            color: #555555;
            width: 100%;
            border: 0;
            display: block;
            padding: 10px 0;
            z-index: 1029;
            position: absolute;
            box-shadow: none;
            min-height: 50px;
            transition: all 150ms ease 0s;
            padding-top: 10px;
            border-bottom: 0;
            border-radius: 3px;
            margin-bottom: 0;
            background-color: transparent;
        }

        .jss80 {
            min-height: 50px;
            margin-left: auto;
            margin-right: auto;
            padding-left: 15px;
            padding-right: 15px;
        }

            .jss80:before, .jss80:after {
                content: " ";
                display: table;
            }

            .jss80:after {
                clear: both;
            }

        .jss81 {
            flex: 1;
        }

        .jss82 {
            color: inherit;
            margin: 0 !important;
            font-size: 18px;
            font-family: "Roboto", "Helvetica", "Arial", sans-serif;
            font-weight: 300;
            line-height: 30px;
            padding-top: 0.625rem;
            border-radius: 3px;
            letter-spacing: unset;
            padding-bottom: 0.625rem;
            text-transform: none;
        }

            .jss82:hover, .jss82:focus {
                background: transparent;
            }

        .jss83 {
            color: #FFF;
            border: 0;
            padding: 10px 0;
            box-shadow: 0 10px 20px -12px rgba(0, 0, 0, 0.42), 0 3px 20px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 0, 0, 0.2);
            transition: all 150ms ease 0s;
            border-radius: 3px;
            background-color: #9c27b0;
        }

        .jss84 {
            color: #FFF;
            border: 0;
            padding: 10px 0;
            box-shadow: 0 10px 20px -12px rgba(0, 0, 0, 0.42), 0 3px 20px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 0, 0, 0.2);
            transition: all 150ms ease 0s;
            border-radius: 3px;
            background-color: #00acc1;
        }

        .jss85 {
            color: #FFF;
            border: 0;
            padding: 10px 0;
            box-shadow: 0 10px 20px -12px rgba(0, 0, 0, 0.42), 0 3px 20px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 0, 0, 0.2);
            transition: all 150ms ease 0s;
            border-radius: 3px;
            background-color: #4caf50;
        }

        .jss86 {
            color: #FFF;
            border: 0;
            padding: 10px 0;
            box-shadow: 0 10px 20px -12px rgba(0, 0, 0, 0.42), 0 3px 20px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 0, 0, 0.2);
            transition: all 150ms ease 0s;
            border-radius: 3px;
            background-color: #ff9800;
        }

        .jss87 {
            color: #FFF;
            border: 0;
            padding: 10px 0;
            box-shadow: 0 10px 20px -12px rgba(0, 0, 0, 0.42), 0 3px 20px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 0, 0, 0.2);
            transition: all 150ms ease 0s;
            border-radius: 3px;
            background-color: #f44336;
        }

        .jss88 {
            color: #555555;
            float: left;
            display: block;
            padding: 0 0 0 15px;
        }

        .jss89 {
            padding: 0 15px 0 0 !important;
        }

        .jss90 {
            width: 20px;
            height: 17px;
        }

        .jss91 {
            color: #FFF;
            border: none;
            cursor: pointer;
            margin: .3125rem 1px;
            padding: 12px 30px;
            position: relative;
            font-size: 12px;
            min-width: auto;
            box-shadow: 0 2px 2px 0 rgba(153, 153, 153, 0.14), 0 3px 1px -2px rgba(153, 153, 153, 0.2), 0 1px 5px 0 rgba(153, 153, 153, 0.12);
            min-height: auto;
            text-align: center;
            transition: box-shadow 0.2s cubic-bezier(0.4, 0, 1, 1), background-color 0.2s cubic-bezier(0.4, 0, 0.2, 1);
            font-weight: 400;
            line-height: 1.42857143;
            white-space: nowrap;
            will-change: box-shadow, transform;
            touch-action: manipulation;
            border-radius: 3px;
            letter-spacing: 0;
            text-transform: uppercase;
            vertical-align: middle;
            background-color: #999;
        }

            .jss91:hover, .jss91:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(153, 153, 153, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(153, 153, 153, 0.2);
                background-color: #999;
            }

            .jss91 .fab, .jss91 .fas, .jss91 .far, .jss91 .fal, .jss91 .material-icons {
                top: 0;
                display: inline-block;
                position: relative;
                font-size: 1.1rem;
                margin-top: -1em;
                margin-right: 4px;
                margin-bottom: -1em;
                vertical-align: middle;
            }

            .jss91 svg {
                top: 0;
                width: 18px;
                height: 18px;
                display: inline-block;
                position: relative;
                margin-right: 4px;
                vertical-align: middle;
            }

            .jss91.jss119 .fab, .jss91.jss119 .fas, .jss91.jss119 .far, .jss91.jss119 .fal, .jss91.jss119 .material-icons {
                top: 0px;
                left: 0px;
                width: 100%;
                height: 100%;
                position: absolute;
                font-size: 20px;
                transform: none;
                margin-top: 0px;
                line-height: 41px;
            }

        .jss92 {
            width: 100%;
        }

        .jss93 {
            box-shadow: 0 2px 2px 0 rgba(156, 39, 176, 0.14), 0 3px 1px -2px rgba(156, 39, 176, 0.2), 0 1px 5px 0 rgba(156, 39, 176, 0.12);
            background-color: #9c27b0;
        }

            .jss93:hover, .jss93:focus {
                box-shadow: 0 14px 26px -12px rgba(156, 39, 176, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(156, 39, 176, 0.2);
                background-color: #9c27b0;
            }

        .jss94 {
            box-shadow: 0 2px 2px 0 rgba(0, 172, 193, 0.14), 0 3px 1px -2px rgba(0, 172, 193, 0.2), 0 1px 5px 0 rgba(0, 172, 193, 0.12);
            background-color: #00acc1;
        }

            .jss94:hover, .jss94:focus {
                box-shadow: 0 14px 26px -12px rgba(0, 172, 193, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 172, 193, 0.2);
                background-color: #00acc1;
            }

        .jss95 {
            box-shadow: 0 2px 2px 0 rgba(76, 175, 80, 0.14), 0 3px 1px -2px rgba(76, 175, 80, 0.2), 0 1px 5px 0 rgba(76, 175, 80, 0.12);
            background-color: #4caf50;
        }

            .jss95:hover, .jss95:focus {
                box-shadow: 0 14px 26px -12px rgba(76, 175, 80, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(76, 175, 80, 0.2);
                background-color: #4caf50;
            }

        .jss96 {
            box-shadow: 0 2px 2px 0 rgba(255, 152, 0, 0.14), 0 3px 1px -2px rgba(255, 152, 0, 0.2), 0 1px 5px 0 rgba(255, 152, 0, 0.12);
            background-color: #ff9800;
        }

            .jss96:hover, .jss96:focus {
                box-shadow: 0 14px 26px -12px rgba(255, 152, 0, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(255, 152, 0, 0.2);
                background-color: #ff9800;
            }

        .jss97 {
            box-shadow: 0 2px 2px 0 rgba(244, 67, 54, 0.14), 0 3px 1px -2px rgba(244, 67, 54, 0.2), 0 1px 5px 0 rgba(244, 67, 54, 0.12);
            background-color: #f44336;
        }

            .jss97:hover, .jss97:focus {
                box-shadow: 0 14px 26px -12px rgba(244, 67, 54, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(244, 67, 54, 0.2);
                background-color: #f44336;
            }

        .jss98 {
            box-shadow: 0 2px 2px 0 rgba(233, 30, 99, 0.14), 0 3px 1px -2px rgba(233, 30, 99, 0.2), 0 1px 5px 0 rgba(233, 30, 99, 0.12);
            background-color: #e91e63;
        }

            .jss98:hover, .jss98:focus {
                box-shadow: 0 14px 26px -12px rgba(233, 30, 99, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(233, 30, 99, 0.2);
                background-color: #e91e63;
            }

        .jss99, .jss99:focus, .jss99:hover {
            color: #999;
            background-color: #FFF;
        }

        .jss100 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(85, 172, 238, 0.14), 0 3px 1px -2px rgba(85, 172, 238, 0.2), 0 1px 5px 0 rgba(85, 172, 238, 0.12);
            background-color: #55acee;
        }

            .jss100:hover, .jss100:focus, .jss100:visited {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(85, 172, 238, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(85, 172, 238, 0.2);
                background-color: #55acee;
            }

        .jss101 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(59, 89, 152, 0.14), 0 3px 1px -2px rgba(59, 89, 152, 0.2), 0 1px 5px 0 rgba(59, 89, 152, 0.12);
            background-color: #3b5998;
        }

            .jss101:hover, .jss101:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(59, 89, 152, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(59, 89, 152, 0.2);
                background-color: #3b5998;
            }

        .jss102 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(221, 75, 57, 0.14), 0 3px 1px -2px rgba(221, 75, 57, 0.2), 0 1px 5px 0 rgba(221, 75, 57, 0.12);
            background-color: #dd4b39;
        }

            .jss102:hover, .jss102:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(221, 75, 57, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(221, 75, 57, 0.2);
                background-color: #dd4b39;
            }

        .jss103 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(9, 118, 180, 0.14), 0 3px 1px -2px rgba(9, 118, 180, 0.2), 0 1px 5px 0 rgba(9, 118, 180, 0.12);
            background-color: #0976b4;
        }

            .jss103:hover, .jss103:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(9, 118, 180, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(9, 118, 180, 0.2);
                background-color: #0976b4;
            }

        .jss104 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(204, 33, 39, 0.14), 0 3px 1px -2px rgba(204, 33, 39, 0.2), 0 1px 5px 0 rgba(204, 33, 39, 0.12);
            background-color: #cc2127;
        }

            .jss104:hover, .jss104:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(204, 33, 39, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(204, 33, 39, 0.2);
                background-color: #cc2127;
            }

        .jss105 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(229, 45, 39, 0.14), 0 3px 1px -2px rgba(229, 45, 39, 0.2), 0 1px 5px 0 rgba(229, 45, 39, 0.12);
            background-color: #e52d27;
        }

            .jss105:hover, .jss105:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(229, 45, 39, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(229, 45, 39, 0.2);
                background-color: #e52d27;
            }

        .jss106 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(53, 70, 92, 0.14), 0 3px 1px -2px rgba(53, 70, 92, 0.2), 0 1px 5px 0 rgba(53, 70, 92, 0.12);
            background-color: #35465c;
        }

            .jss106:hover, .jss106:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(53, 70, 92, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(53, 70, 92, 0.2);
                background-color: #35465c;
            }

        .jss107 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(85, 85, 85, 0.14), 0 3px 1px -2px rgba(85, 85, 85, 0.2), 0 1px 5px 0 rgba(85, 85, 85, 0.12);
            background-color: #333;
        }

            .jss107:hover, .jss107:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(85, 85, 85, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(85, 85, 85, 0.2);
                background-color: #333;
            }

        .jss108 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(23, 105, 255, 0.14), 0 3px 1px -2px rgba(23, 105, 255, 0.2), 0 1px 5px 0 rgba(23, 105, 255, 0.12);
            background-color: #1769ff;
        }

            .jss108:hover, .jss108:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(23, 105, 255, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(23, 105, 255, 0.2);
                background-color: #1769ff;
            }

        .jss109 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(234, 76, 137, 0.14), 0 3px 1px -2px rgba(234, 76, 137, 0.2), 0 1px 5px 0 rgba(234, 76, 137, 0.12);
            background-color: #ea4c89;
        }

            .jss109:hover, .jss109:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(234, 76, 137, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(234, 76, 137, 0.2);
                background-color: #ea4c89;
            }

        .jss110 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(255, 69, 0, 0.14), 0 3px 1px -2px rgba(255, 69, 0, 0.2), 0 1px 5px 0 rgba(255, 69, 0, 0.12);
            background-color: #ff4500;
        }

            .jss110:hover, .jss110:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(255, 69, 0, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(255, 69, 0, 0.2);
                background-color: #ff4500;
            }

        .jss111, .jss111:focus, .jss111:hover {
            color: #FFF;
            background: transparent;
            box-shadow: none;
        }

            .jss111.jss110, .jss111.jss110:focus, .jss111.jss110:hover, .jss111.jss110:visited {
                color: #ff4500;
            }

            .jss111.jss109, .jss111.jss109:focus, .jss111.jss109:hover, .jss111.jss109:visited {
                color: #ea4c89;
            }

            .jss111.jss108, .jss111.jss108:focus, .jss111.jss108:hover, .jss111.jss108:visited {
                color: #1769ff;
            }

            .jss111.jss107, .jss111.jss107:focus, .jss111.jss107:hover, .jss111.jss107:visited {
                color: #333;
            }

            .jss111.jss106, .jss111.jss106:focus, .jss111.jss106:hover, .jss111.jss106:visited {
                color: #35465c;
            }

            .jss111.jss105, .jss111.jss105:focus, .jss111.jss105:hover, .jss111.jss105:visited {
                color: #e52d27;
            }

            .jss111.jss104, .jss111.jss104:focus, .jss111.jss104:hover, .jss111.jss104:visited {
                color: #cc2127;
            }

            .jss111.jss103, .jss111.jss103:focus, .jss111.jss103:hover, .jss111.jss103:visited {
                color: #0976b4;
            }

            .jss111.jss102, .jss111.jss102:focus, .jss111.jss102:hover, .jss111.jss102:visited {
                color: #dd4b39;
            }

            .jss111.jss101, .jss111.jss101:focus, .jss111.jss101:hover, .jss111.jss101:visited {
                color: #3b5998;
            }

            .jss111.jss100, .jss111.jss100:focus, .jss111.jss100:hover, .jss111.jss100:visited {
                color: #55acee;
            }

            .jss111.jss97, .jss111.jss97:focus, .jss111.jss97:hover, .jss111.jss97:visited {
                color: #f44336;
            }

            .jss111.jss98, .jss111.jss98:focus, .jss111.jss98:hover, .jss111.jss98:visited {
                color: #e91e63;
            }

            .jss111.jss96, .jss111.jss96:focus, .jss111.jss96:hover, .jss111.jss96:visited {
                color: #ff9800;
            }

            .jss111.jss95, .jss111.jss95:focus, .jss111.jss95:hover, .jss111.jss95:visited {
                color: #4caf50;
            }

            .jss111.jss94, .jss111.jss94:focus, .jss111.jss94:hover, .jss111.jss94:visited {
                color: #00acc1;
            }

            .jss111.jss93, .jss111.jss93:focus, .jss111.jss93:hover, .jss111.jss93:visited {
                color: #9c27b0;
            }

        .jss112, .jss112:focus, .jss112:hover {
            color: inherit;
            background: transparent;
            box-shadow: none;
        }

        .jss113 {
            opacity: 0.65;
            pointer-events: none;
        }

        .jss114 {
            padding: 1.125rem 2.25rem;
            font-size: 0.875rem;
            line-height: 1.333333;
            border-radius: 0.2rem;
        }

            .jss114.jss119 .fab, .jss114.jss119 .fas, .jss114.jss119 .far, .jss114.jss119 .fal, .jss114.jss119 svg, .jss114.jss119 .material-icons {
                margin-top: -4px;
            }

        .jss115 {
            padding: 0.40625rem 1.25rem;
            font-size: 0.6875rem;
            line-height: 1.5;
            border-radius: 0.2rem;
        }

            .jss115.jss119 .fab, .jss115.jss119 .fas, .jss115.jss119 .far, .jss115.jss119 .fal, .jss115.jss119 svg, .jss115.jss119 .material-icons {
                margin-top: 1px;
            }

        .jss116 {
            border-radius: 30px;
        }

        .jss117 {
            width: 100% !important;
        }

        .jss118, .jss118:hover, .jss118:focus {
            color: #999;
            box-shadow: none;
            background-color: transparent;
        }

        .jss119 {
            width: 41px;
            height: 41px;
            font-size: 20px;
            min-width: 41px;
            padding-left: 12px;
            padding-right: 12px;
        }

            .jss119 .fab, .jss119 .fas, .jss119 .far, .jss119 .fal, .jss119 svg, .jss119 .material-icons {
                margin-right: 0px;
            }

            .jss119.jss114 {
                width: 57px;
                height: 57px;
                min-width: 57px;
                line-height: 56px;
            }

            .jss119.jss115 {
                width: 30px;
                height: 30px;
                min-width: 30px;
            }

                .jss119.jss115 .fab, .jss119.jss115 .fas, .jss119.jss115 .far, .jss119.jss115 .fal, .jss119.jss115 .material-icons {
                    font-size: 17px;
                    line-height: 29px;
                }

                .jss119.jss115 svg {
                    width: 17px;
                    height: 17px;
                }

            .jss119.jss114 .fab, .jss119.jss114 .fas, .jss119.jss114 .far, .jss119.jss114 .fal, .jss119.jss114 .material-icons {
                font-size: 32px;
                line-height: 56px;
            }

            .jss119.jss114 svg {
                width: 32px;
                height: 32px;
            }

        .jss120 {
            color: #FFF;
            border: none;
            cursor: pointer;
            margin: .3125rem 1px;
            padding: 12px 30px;
            position: relative;
            font-size: 12px;
            min-width: auto;
            box-shadow: 0 2px 2px 0 rgba(153, 153, 153, 0.14), 0 3px 1px -2px rgba(153, 153, 153, 0.2), 0 1px 5px 0 rgba(153, 153, 153, 0.12);
            min-height: auto;
            text-align: center;
            transition: box-shadow 0.2s cubic-bezier(0.4, 0, 1, 1), background-color 0.2s cubic-bezier(0.4, 0, 0.2, 1);
            font-weight: 400;
            line-height: 1.42857143;
            white-space: nowrap;
            will-change: box-shadow, transform;
            touch-action: manipulation;
            border-radius: 3px;
            letter-spacing: 0;
            text-transform: uppercase;
            vertical-align: middle;
            background-color: #999;
        }

            .jss120:hover, .jss120:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(153, 153, 153, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(153, 153, 153, 0.2);
                background-color: #999;
            }

            .jss120 .fab, .jss120 .fas, .jss120 .far, .jss120 .fal, .jss120 .material-icons {
                top: 0;
                display: inline-block;
                position: relative;
                font-size: 1.1rem;
                margin-top: -1em;
                margin-right: 4px;
                margin-bottom: -1em;
                vertical-align: middle;
            }

            .jss120 svg {
                top: 0;
                width: 18px;
                height: 18px;
                display: inline-block;
                position: relative;
                margin-right: 4px;
                vertical-align: middle;
            }

            .jss120.jss148 .fab, .jss120.jss148 .fas, .jss120.jss148 .far, .jss120.jss148 .fal, .jss120.jss148 .material-icons {
                top: 0px;
                left: 0px;
                width: 100%;
                height: 100%;
                position: absolute;
                font-size: 20px;
                transform: none;
                margin-top: 0px;
                line-height: 41px;
            }

        .jss121 {
            width: 100%;
        }

        .jss122 {
            box-shadow: 0 2px 2px 0 rgba(156, 39, 176, 0.14), 0 3px 1px -2px rgba(156, 39, 176, 0.2), 0 1px 5px 0 rgba(156, 39, 176, 0.12);
            background-color: #9c27b0;
        }

            .jss122:hover, .jss122:focus {
                box-shadow: 0 14px 26px -12px rgba(156, 39, 176, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(156, 39, 176, 0.2);
                background-color: #9c27b0;
            }

        .jss123 {
            box-shadow: 0 2px 2px 0 rgba(0, 172, 193, 0.14), 0 3px 1px -2px rgba(0, 172, 193, 0.2), 0 1px 5px 0 rgba(0, 172, 193, 0.12);
            background-color: #00acc1;
        }

            .jss123:hover, .jss123:focus {
                box-shadow: 0 14px 26px -12px rgba(0, 172, 193, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 172, 193, 0.2);
                background-color: #00acc1;
            }

        .jss124 {
            box-shadow: 0 2px 2px 0 rgba(76, 175, 80, 0.14), 0 3px 1px -2px rgba(76, 175, 80, 0.2), 0 1px 5px 0 rgba(76, 175, 80, 0.12);
            background-color: #4caf50;
        }

            .jss124:hover, .jss124:focus {
                box-shadow: 0 14px 26px -12px rgba(76, 175, 80, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(76, 175, 80, 0.2);
                background-color: #4caf50;
            }

        .jss125 {
            box-shadow: 0 2px 2px 0 rgba(255, 152, 0, 0.14), 0 3px 1px -2px rgba(255, 152, 0, 0.2), 0 1px 5px 0 rgba(255, 152, 0, 0.12);
            background-color: #ff9800;
        }

            .jss125:hover, .jss125:focus {
                box-shadow: 0 14px 26px -12px rgba(255, 152, 0, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(255, 152, 0, 0.2);
                background-color: #ff9800;
            }

        .jss126 {
            box-shadow: 0 2px 2px 0 rgba(244, 67, 54, 0.14), 0 3px 1px -2px rgba(244, 67, 54, 0.2), 0 1px 5px 0 rgba(244, 67, 54, 0.12);
            background-color: #f44336;
        }

            .jss126:hover, .jss126:focus {
                box-shadow: 0 14px 26px -12px rgba(244, 67, 54, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(244, 67, 54, 0.2);
                background-color: #f44336;
            }

        .jss127 {
            box-shadow: 0 2px 2px 0 rgba(233, 30, 99, 0.14), 0 3px 1px -2px rgba(233, 30, 99, 0.2), 0 1px 5px 0 rgba(233, 30, 99, 0.12);
            background-color: #e91e63;
        }

            .jss127:hover, .jss127:focus {
                box-shadow: 0 14px 26px -12px rgba(233, 30, 99, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(233, 30, 99, 0.2);
                background-color: #e91e63;
            }

        .jss128, .jss128:focus, .jss128:hover {
            color: #999;
            background-color: #FFF;
        }

        .jss129 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(85, 172, 238, 0.14), 0 3px 1px -2px rgba(85, 172, 238, 0.2), 0 1px 5px 0 rgba(85, 172, 238, 0.12);
            background-color: #55acee;
        }

            .jss129:hover, .jss129:focus, .jss129:visited {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(85, 172, 238, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(85, 172, 238, 0.2);
                background-color: #55acee;
            }

        .jss130 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(59, 89, 152, 0.14), 0 3px 1px -2px rgba(59, 89, 152, 0.2), 0 1px 5px 0 rgba(59, 89, 152, 0.12);
            background-color: #3b5998;
        }

            .jss130:hover, .jss130:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(59, 89, 152, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(59, 89, 152, 0.2);
                background-color: #3b5998;
            }

        .jss131 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(221, 75, 57, 0.14), 0 3px 1px -2px rgba(221, 75, 57, 0.2), 0 1px 5px 0 rgba(221, 75, 57, 0.12);
            background-color: #dd4b39;
        }

            .jss131:hover, .jss131:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(221, 75, 57, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(221, 75, 57, 0.2);
                background-color: #dd4b39;
            }

        .jss132 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(9, 118, 180, 0.14), 0 3px 1px -2px rgba(9, 118, 180, 0.2), 0 1px 5px 0 rgba(9, 118, 180, 0.12);
            background-color: #0976b4;
        }

            .jss132:hover, .jss132:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(9, 118, 180, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(9, 118, 180, 0.2);
                background-color: #0976b4;
            }

        .jss133 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(204, 33, 39, 0.14), 0 3px 1px -2px rgba(204, 33, 39, 0.2), 0 1px 5px 0 rgba(204, 33, 39, 0.12);
            background-color: #cc2127;
        }

            .jss133:hover, .jss133:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(204, 33, 39, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(204, 33, 39, 0.2);
                background-color: #cc2127;
            }

        .jss134 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(229, 45, 39, 0.14), 0 3px 1px -2px rgba(229, 45, 39, 0.2), 0 1px 5px 0 rgba(229, 45, 39, 0.12);
            background-color: #e52d27;
        }

            .jss134:hover, .jss134:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(229, 45, 39, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(229, 45, 39, 0.2);
                background-color: #e52d27;
            }

        .jss135 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(53, 70, 92, 0.14), 0 3px 1px -2px rgba(53, 70, 92, 0.2), 0 1px 5px 0 rgba(53, 70, 92, 0.12);
            background-color: #35465c;
        }

            .jss135:hover, .jss135:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(53, 70, 92, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(53, 70, 92, 0.2);
                background-color: #35465c;
            }

        .jss136 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(85, 85, 85, 0.14), 0 3px 1px -2px rgba(85, 85, 85, 0.2), 0 1px 5px 0 rgba(85, 85, 85, 0.12);
            background-color: #333;
        }

            .jss136:hover, .jss136:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(85, 85, 85, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(85, 85, 85, 0.2);
                background-color: #333;
            }

        .jss137 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(23, 105, 255, 0.14), 0 3px 1px -2px rgba(23, 105, 255, 0.2), 0 1px 5px 0 rgba(23, 105, 255, 0.12);
            background-color: #1769ff;
        }

            .jss137:hover, .jss137:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(23, 105, 255, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(23, 105, 255, 0.2);
                background-color: #1769ff;
            }

        .jss138 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(234, 76, 137, 0.14), 0 3px 1px -2px rgba(234, 76, 137, 0.2), 0 1px 5px 0 rgba(234, 76, 137, 0.12);
            background-color: #ea4c89;
        }

            .jss138:hover, .jss138:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(234, 76, 137, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(234, 76, 137, 0.2);
                background-color: #ea4c89;
            }

        .jss139 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(255, 69, 0, 0.14), 0 3px 1px -2px rgba(255, 69, 0, 0.2), 0 1px 5px 0 rgba(255, 69, 0, 0.12);
            background-color: #ff4500;
        }

            .jss139:hover, .jss139:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(255, 69, 0, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(255, 69, 0, 0.2);
                background-color: #ff4500;
            }

        .jss140, .jss140:focus, .jss140:hover {
            color: #FFF;
            background: transparent;
            box-shadow: none;
        }

            .jss140.jss139, .jss140.jss139:focus, .jss140.jss139:hover, .jss140.jss139:visited {
                color: #ff4500;
            }

            .jss140.jss138, .jss140.jss138:focus, .jss140.jss138:hover, .jss140.jss138:visited {
                color: #ea4c89;
            }

            .jss140.jss137, .jss140.jss137:focus, .jss140.jss137:hover, .jss140.jss137:visited {
                color: #1769ff;
            }

            .jss140.jss136, .jss140.jss136:focus, .jss140.jss136:hover, .jss140.jss136:visited {
                color: #333;
            }

            .jss140.jss135, .jss140.jss135:focus, .jss140.jss135:hover, .jss140.jss135:visited {
                color: #35465c;
            }

            .jss140.jss134, .jss140.jss134:focus, .jss140.jss134:hover, .jss140.jss134:visited {
                color: #e52d27;
            }

            .jss140.jss133, .jss140.jss133:focus, .jss140.jss133:hover, .jss140.jss133:visited {
                color: #cc2127;
            }

            .jss140.jss132, .jss140.jss132:focus, .jss140.jss132:hover, .jss140.jss132:visited {
                color: #0976b4;
            }

            .jss140.jss131, .jss140.jss131:focus, .jss140.jss131:hover, .jss140.jss131:visited {
                color: #dd4b39;
            }

            .jss140.jss130, .jss140.jss130:focus, .jss140.jss130:hover, .jss140.jss130:visited {
                color: #3b5998;
            }

            .jss140.jss129, .jss140.jss129:focus, .jss140.jss129:hover, .jss140.jss129:visited {
                color: #55acee;
            }

            .jss140.jss126, .jss140.jss126:focus, .jss140.jss126:hover, .jss140.jss126:visited {
                color: #f44336;
            }

            .jss140.jss127, .jss140.jss127:focus, .jss140.jss127:hover, .jss140.jss127:visited {
                color: #e91e63;
            }

            .jss140.jss125, .jss140.jss125:focus, .jss140.jss125:hover, .jss140.jss125:visited {
                color: #ff9800;
            }

            .jss140.jss124, .jss140.jss124:focus, .jss140.jss124:hover, .jss140.jss124:visited {
                color: #4caf50;
            }

            .jss140.jss123, .jss140.jss123:focus, .jss140.jss123:hover, .jss140.jss123:visited {
                color: #00acc1;
            }

            .jss140.jss122, .jss140.jss122:focus, .jss140.jss122:hover, .jss140.jss122:visited {
                color: #9c27b0;
            }

        .jss141, .jss141:focus, .jss141:hover {
            color: inherit;
            background: transparent;
            box-shadow: none;
        }

        .jss142 {
            opacity: 0.65;
            pointer-events: none;
        }

        .jss143 {
            padding: 1.125rem 2.25rem;
            font-size: 0.875rem;
            line-height: 1.333333;
            border-radius: 0.2rem;
        }

            .jss143.jss148 .fab, .jss143.jss148 .fas, .jss143.jss148 .far, .jss143.jss148 .fal, .jss143.jss148 svg, .jss143.jss148 .material-icons {
                margin-top: -4px;
            }

        .jss144 {
            padding: 0.40625rem 1.25rem;
            font-size: 0.6875rem;
            line-height: 1.5;
            border-radius: 0.2rem;
        }

            .jss144.jss148 .fab, .jss144.jss148 .fas, .jss144.jss148 .far, .jss144.jss148 .fal, .jss144.jss148 svg, .jss144.jss148 .material-icons {
                margin-top: 1px;
            }

        .jss145 {
            border-radius: 30px;
        }

        .jss146 {
            width: 100% !important;
        }

        .jss147, .jss147:hover, .jss147:focus {
            color: #999;
            box-shadow: none;
            background-color: transparent;
        }

        .jss148 {
            width: 41px;
            height: 41px;
            font-size: 20px;
            min-width: 41px;
            padding-left: 12px;
            padding-right: 12px;
        }

            .jss148 .fab, .jss148 .fas, .jss148 .far, .jss148 .fal, .jss148 svg, .jss148 .material-icons {
                margin-right: 0px;
            }

            .jss148.jss143 {
                width: 57px;
                height: 57px;
                min-width: 57px;
                line-height: 56px;
            }

            .jss148.jss144 {
                width: 30px;
                height: 30px;
                min-width: 30px;
            }

                .jss148.jss144 .fab, .jss148.jss144 .fas, .jss148.jss144 .far, .jss148.jss144 .fal, .jss148.jss144 .material-icons {
                    font-size: 17px;
                    line-height: 29px;
                }

                .jss148.jss144 svg {
                    width: 17px;
                    height: 17px;
                }

            .jss148.jss143 .fab, .jss148.jss143 .fas, .jss148.jss143 .far, .jss148.jss143 .fal, .jss148.jss143 .material-icons {
                font-size: 32px;
                line-height: 56px;
            }

            .jss148.jss143 svg {
                width: 32px;
                height: 32px;
            }

        .jss149 {
            display: none !important;
            pointer-events: none;
        }

        @media (max-width:959.95px) {
            .jss150 {
                top: unset !important;
                left: unset !important;
                position: static !important;
                transform: none !important;
                will-change: unset !important;
            }

                .jss150 > div {
                    padding: 0px !important;
                    box-shadow: none !important;
                    margin-top: 0px !important;
                    transition: none !important;
                    margin-left: 0rem;
                    margin-right: 0rem;
                    margin-bottom: 0px !important;
                    background-color: transparent !important;
                }

                    .jss150 > div ul li {
                        color: #FFF !important;
                        margin: 10px 15px 0 !important;
                        padding: 10px 15px !important;
                    }

                        .jss150 > div ul li:hover {
                            box-shadow: none;
                            background-color: hsla(0,0%,78%,.2);
                        }
        }

        .jss151 > div > button:first-child > span:first-child, .jss151 > div > a:first-child > span:first-child {
            width: 100%;
        }

        .jss152 > div > button, .jss152 > div > a {
            color: inherit !important;
            margin: 0px !important;
            padding: 10px 20px !important;
        }

            .jss152 > div > button > span:first-child, .jss152 > div > a > span:first-child {
                width: 100%;
                justify-content: flex-start;
            }

        .jss153 > button:first-child > span:first-child, .jss153 > a:first-child > span:first-child {
            display: inline-block;
        }

        .jss153 .jss168 {
            margin-left: 0px;
        }

        .jss154 {
            top: 100%;
            border: 0;
            margin: 2px 0 0;
            padding: 5px 0;
            z-index: 1000;
            font-size: 14px;
            min-width: 160px;
            box-shadow: 0 2px 5px 0 rgba(0, 0, 0, 0.26);
            list-style: none;
            text-align: left;
            border-radius: 3px;
            background-clip: padding-box;
            background-color: #FFF;
        }

        .jss155 {
            padding: 0;
        }

        .jss156 {
            z-index: 1200;
        }

        @media (max-width:959.95px) {
            .jss156 {
                color: black;
                float: none;
                width: auto;
                border: 0;
                z-index: 1640;
                position: static;
                box-shadow: none;
                margin-top: 0;
                background-color: transparent;
            }
        }

        .jss157 {
            clear: both;
            color: #333;
            height: 100%;
            margin: 0 5px;
            display: block;
            padding: 10px 20px;
            position: relative;
            font-size: 13px;
            min-height: unset;
            transition: all 150ms linear;
            font-family: "Roboto", "Helvetica", "Arial", sans-serif;
            font-weight: 400;
            line-height: 1.5em;
            white-space: nowrap;
            border-radius: 2px;
        }

        .jss158:hover {
            color: #FFF;
            box-shadow: 0 4px 20px 0px rgba(0, 0, 0, 0.14), 0 7px 10px -5px rgba(33, 33, 33, 0.4);
            background-color: #212121;
        }

        .jss159:hover {
            color: #FFF;
            box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(156, 39, 176,.4);
            background-color: #9c27b0;
        }

        .jss160:hover {
            color: #FFF;
            box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(0, 172, 193,.4);
            background-color: #00acc1;
        }

        .jss161:hover {
            color: #FFF;
            box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(76, 175, 80,.4);
            background-color: #4caf50;
        }

        .jss162:hover {
            color: #FFF;
            box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(255, 152, 0,.4);
            background-color: #ff9800;
        }

        .jss163:hover {
            color: #FFF;
            box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(244, 67, 54,.4);
            background-color: #f44336;
        }

        .jss164:hover {
            color: #FFF;
            box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(233, 30, 99,.4);
            background-color: #e91e63;
        }

        .jss165 {
            text-align: right;
        }

        .jss166 {
            height: 1px;
            margin: 5px 0;
            overflow: hidden;
            background-color: rgba(0, 0, 0, 0.12);
        }

        .jss167 {
            width: 20px;
            height: 20px;
        }

        .jss168 {
            width: 0;
            height: 0;
            display: inline-block;
            border-top: 4px solid;
            transition: all 150ms ease-in;
            border-left: 4px solid transparent;
            margin-left: 4px;
            border-right: 4px solid transparent;
            vertical-align: middle;
        }

        .jss169 {
            transform: rotate(180deg);
        }

        .jss170 {
            transform: rotate(180deg);
        }

        .jss171 {
            margin-right: 4px;
        }

        .jss172 {
            color: #777;
            display: block;
            padding: 0.1875rem 1.25rem;
            font-size: 0.75rem;
            margin-top: 10px;
            min-height: unset;
            font-weight: inherit;
            line-height: 1.428571;
            white-space: nowrap;
        }

            .jss172:hover, .jss172:focus {
                cursor: auto;
                background-color: transparent;
            }

        .jss173 {
            padding: 0;
        }

        .jss174 {
            margin: 0;
            padding-top: 7px;
            padding-bottom: 7px;
        }

        @media (max-width:959.95px) {
            .jss174 {
                float: none !important;
                width: auto;
                margin: 10px 15px;
                padding: 10px 15px;
                padding-top: 1px;
                padding-bottom: 1px;
            }
        }

        .jss175 {
            padding-top: 2px;
        }

        @media (max-width:959.95px) {
            .jss176 {
                margin-right: 18px !important;
            }
        }

        @media (min-width:960px) {
            .jss176 {
                margin-left: 12px;
            }
        }

        .jss177 {
            margin: 0 !important;
            z-index: 4;
            font-size: 14px;
            font-family: "Roboto", "Helvetica", "Arial", sans-serif;
            font-weight: 300;
            line-height: 1.5em;
            text-transform: none;
        }

        @media (max-width:959.95px) {
            .jss178 {
                width: auto;
                height: auto;
                margin: 5px 15px 0;
                display: flex;
            }

                .jss178 svg {
                    width: 30px;
                    height: 24px;
                    margin-left: 3px;
                    margin-right: 19px;
                }

                .jss178 .fab, .jss178 .fas, .jss178 .far, .jss178 .fal, .jss178 .material-icons {
                    width: 30px;
                    font-size: 24px;
                    line-height: 30px;
                    margin-left: 3px;
                    margin-right: 19px;
                }
        }

        @media (max-width:959.95px) {
            .jss179 {
                top: -50px !important;
                float: right;
                margin-right: 38px;
            }
        }

        .jss180 {
            z-index: 4;
        }

        .jss181 {
            width: 17px;
            z-index: 4;
        }

        .jss182 {
            width: 20px;
            height: 20px;
            z-index: 4;
        }

        @media (max-width:959.95px) {
            .jss182 {
                color: inherit;
                width: 30px;
                height: 30px;
                display: block;
                opacity: 0.8;
                margin-left: -5px;
                margin-right: 16px;
            }
        }

        .jss183 {
            z-index: 4;
        }

        @media (min-width:960px) {
            .jss183 {
                top: 5px;
                color: #FFF;
                right: 5px;
                border: 1px solid #FFF;
                height: 16px;
                display: block;
                position: absolute;
                font-size: 9px;
                min-width: 16px;
                background: #f44336;
                text-align: center;
                line-height: 14px;
                border-radius: 10px;
                vertical-align: middle;
            }
        }

        @media (max-width:959.95px) {
            .jss183 {
                font-size: 14px;
                font-family: "Roboto", "Helvetica", "Arial", sans-serif;
                font-weight: 300;
                line-height: 1.5em;
                margin-right: 8px;
            }
        }

        @media (min-width:960px) {
            .jss184 {
                padding-left: 16px;
            }
        }

        @media (max-width:959.95px) {
            .jss185 {
                width: -webkit-fill-available;
                margin: 10px 15px 0;
                display: block;
                padding: 10px 15px;
                position: relative;
                align-items: center;
                justify-content: flex-end;
            }
        }

        @media (max-width:959.95px) {
            .jss186 {
                display: flex;
                flex-direction: row-reverse;
                justify-content: initial;
            }
        }

        @media (max-width:959.95px) {
            .jss187 {
                margin-left: 16px !important;
                margin-right: -5px !important;
            }
        }

        @media (min-width:960px) {
            .jss188 {
                display: inline-block;
            }
        }

        .jss189 {
            width: 20px !important;
            height: 20px !important;
        }

        .jss190:before {
            border-color: transparent !important;
        }

        .jss191:hover:not(.jss190):before, .jss191:before {
            border-color: #D2D2D2 !important;
            border-width: 1px !important;
        }

        .jss191:after {
            border-color: #9c27b0;
        }

        .jss191 + p {
            font-weight: 300;
        }

        .jss192:after {
            border-color: #f44336;
        }

        .jss193:after {
            border-color: #4caf50;
        }

        .jss194 {
            top: 10px;
            color: #AAAAAA !important;
            font-size: 14px;
            font-family: "Roboto", "Helvetica", "Arial", sans-serif;
            font-weight: 400;
            line-height: 1.42857;
            letter-spacing: unset;
        }

            .jss194 + .jss191 {
                margin-top: 0px;
            }

        .jss195 {
            color: #f44336 !important;
        }

        .jss196 {
            color: #4caf50 !important;
        }

        .jss197 {
            margin: 0 0 17px 0;
            position: relative;
            padding-top: 27px;
            vertical-align: unset;
        }

            .jss197 svg, .jss197 .fab, .jss197 .far, .jss197 .fal, .jss197 .fas, .jss197 .material-icons {
                color: #495057;
            }

        .jss198:hover:not(.jss190):before, .jss198:before {
            background-color: #FFF;
        }

        .jss198:after {
            background-color: #FFF;
        }

        .jss199 {
            color: #495057;
            height: unset;
        }

            .jss199, .jss199::placeholder {
                opacity: 1;
                font-size: 14px;
                font-family: "Roboto", "Helvetica", "Arial", sans-serif;
                font-weight: 400;
                line-height: 1.42857;
            }

                .jss199::placeholder {
                    color: #AAAAAA;
                }

        .jss200, .jss200::placeholder {
            color: #FFF;
            opacity: 1;
        }

        .jss201 {
            color: #FFF;
            border: none;
            cursor: pointer;
            margin: .3125rem 1px;
            padding: 12px 30px;
            position: relative;
            font-size: 12px;
            min-width: auto;
            box-shadow: 0 2px 2px 0 rgba(153, 153, 153, 0.14), 0 3px 1px -2px rgba(153, 153, 153, 0.2), 0 1px 5px 0 rgba(153, 153, 153, 0.12);
            min-height: auto;
            text-align: center;
            transition: box-shadow 0.2s cubic-bezier(0.4, 0, 1, 1), background-color 0.2s cubic-bezier(0.4, 0, 0.2, 1);
            font-weight: 400;
            line-height: 1.42857143;
            white-space: nowrap;
            will-change: box-shadow, transform;
            touch-action: manipulation;
            border-radius: 3px;
            letter-spacing: 0;
            text-transform: uppercase;
            vertical-align: middle;
            background-color: #999;
        }

            .jss201:hover, .jss201:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(153, 153, 153, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(153, 153, 153, 0.2);
                background-color: #999;
            }

            .jss201 .fab, .jss201 .fas, .jss201 .far, .jss201 .fal, .jss201 .material-icons {
                top: 0;
                display: inline-block;
                position: relative;
                font-size: 1.1rem;
                margin-top: -1em;
                margin-right: 4px;
                margin-bottom: -1em;
                vertical-align: middle;
            }

            .jss201 svg {
                top: 0;
                width: 18px;
                height: 18px;
                display: inline-block;
                position: relative;
                margin-right: 4px;
                vertical-align: middle;
            }

            .jss201.jss229 .fab, .jss201.jss229 .fas, .jss201.jss229 .far, .jss201.jss229 .fal, .jss201.jss229 .material-icons {
                top: 0px;
                left: 0px;
                width: 100%;
                height: 100%;
                position: absolute;
                font-size: 20px;
                transform: none;
                margin-top: 0px;
                line-height: 41px;
            }

        .jss202 {
            width: 100%;
        }

        .jss203 {
            box-shadow: 0 2px 2px 0 rgba(156, 39, 176, 0.14), 0 3px 1px -2px rgba(156, 39, 176, 0.2), 0 1px 5px 0 rgba(156, 39, 176, 0.12);
            background-color: #9c27b0;
        }

            .jss203:hover, .jss203:focus {
                box-shadow: 0 14px 26px -12px rgba(156, 39, 176, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(156, 39, 176, 0.2);
                background-color: #9c27b0;
            }

        .jss204 {
            box-shadow: 0 2px 2px 0 rgba(0, 172, 193, 0.14), 0 3px 1px -2px rgba(0, 172, 193, 0.2), 0 1px 5px 0 rgba(0, 172, 193, 0.12);
            background-color: #00acc1;
        }

            .jss204:hover, .jss204:focus {
                box-shadow: 0 14px 26px -12px rgba(0, 172, 193, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 172, 193, 0.2);
                background-color: #00acc1;
            }

        .jss205 {
            box-shadow: 0 2px 2px 0 rgba(76, 175, 80, 0.14), 0 3px 1px -2px rgba(76, 175, 80, 0.2), 0 1px 5px 0 rgba(76, 175, 80, 0.12);
            background-color: #4caf50;
        }

            .jss205:hover, .jss205:focus {
                box-shadow: 0 14px 26px -12px rgba(76, 175, 80, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(76, 175, 80, 0.2);
                background-color: #4caf50;
            }

        .jss206 {
            box-shadow: 0 2px 2px 0 rgba(255, 152, 0, 0.14), 0 3px 1px -2px rgba(255, 152, 0, 0.2), 0 1px 5px 0 rgba(255, 152, 0, 0.12);
            background-color: #ff9800;
        }

            .jss206:hover, .jss206:focus {
                box-shadow: 0 14px 26px -12px rgba(255, 152, 0, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(255, 152, 0, 0.2);
                background-color: #ff9800;
            }

        .jss207 {
            box-shadow: 0 2px 2px 0 rgba(244, 67, 54, 0.14), 0 3px 1px -2px rgba(244, 67, 54, 0.2), 0 1px 5px 0 rgba(244, 67, 54, 0.12);
            background-color: #f44336;
        }

            .jss207:hover, .jss207:focus {
                box-shadow: 0 14px 26px -12px rgba(244, 67, 54, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(244, 67, 54, 0.2);
                background-color: #f44336;
            }

        .jss208 {
            box-shadow: 0 2px 2px 0 rgba(233, 30, 99, 0.14), 0 3px 1px -2px rgba(233, 30, 99, 0.2), 0 1px 5px 0 rgba(233, 30, 99, 0.12);
            background-color: #e91e63;
        }

            .jss208:hover, .jss208:focus {
                box-shadow: 0 14px 26px -12px rgba(233, 30, 99, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(233, 30, 99, 0.2);
                background-color: #e91e63;
            }

        .jss209, .jss209:focus, .jss209:hover {
            color: #999;
            background-color: #FFF;
        }

        .jss210 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(85, 172, 238, 0.14), 0 3px 1px -2px rgba(85, 172, 238, 0.2), 0 1px 5px 0 rgba(85, 172, 238, 0.12);
            background-color: #55acee;
        }

            .jss210:hover, .jss210:focus, .jss210:visited {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(85, 172, 238, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(85, 172, 238, 0.2);
                background-color: #55acee;
            }

        .jss211 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(59, 89, 152, 0.14), 0 3px 1px -2px rgba(59, 89, 152, 0.2), 0 1px 5px 0 rgba(59, 89, 152, 0.12);
            background-color: #3b5998;
        }

            .jss211:hover, .jss211:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(59, 89, 152, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(59, 89, 152, 0.2);
                background-color: #3b5998;
            }

        .jss212 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(221, 75, 57, 0.14), 0 3px 1px -2px rgba(221, 75, 57, 0.2), 0 1px 5px 0 rgba(221, 75, 57, 0.12);
            background-color: #dd4b39;
        }

            .jss212:hover, .jss212:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(221, 75, 57, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(221, 75, 57, 0.2);
                background-color: #dd4b39;
            }

        .jss213 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(9, 118, 180, 0.14), 0 3px 1px -2px rgba(9, 118, 180, 0.2), 0 1px 5px 0 rgba(9, 118, 180, 0.12);
            background-color: #0976b4;
        }

            .jss213:hover, .jss213:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(9, 118, 180, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(9, 118, 180, 0.2);
                background-color: #0976b4;
            }

        .jss214 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(204, 33, 39, 0.14), 0 3px 1px -2px rgba(204, 33, 39, 0.2), 0 1px 5px 0 rgba(204, 33, 39, 0.12);
            background-color: #cc2127;
        }

            .jss214:hover, .jss214:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(204, 33, 39, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(204, 33, 39, 0.2);
                background-color: #cc2127;
            }

        .jss215 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(229, 45, 39, 0.14), 0 3px 1px -2px rgba(229, 45, 39, 0.2), 0 1px 5px 0 rgba(229, 45, 39, 0.12);
            background-color: #e52d27;
        }

            .jss215:hover, .jss215:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(229, 45, 39, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(229, 45, 39, 0.2);
                background-color: #e52d27;
            }

        .jss216 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(53, 70, 92, 0.14), 0 3px 1px -2px rgba(53, 70, 92, 0.2), 0 1px 5px 0 rgba(53, 70, 92, 0.12);
            background-color: #35465c;
        }

            .jss216:hover, .jss216:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(53, 70, 92, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(53, 70, 92, 0.2);
                background-color: #35465c;
            }

        .jss217 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(85, 85, 85, 0.14), 0 3px 1px -2px rgba(85, 85, 85, 0.2), 0 1px 5px 0 rgba(85, 85, 85, 0.12);
            background-color: #333;
        }

            .jss217:hover, .jss217:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(85, 85, 85, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(85, 85, 85, 0.2);
                background-color: #333;
            }

        .jss218 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(23, 105, 255, 0.14), 0 3px 1px -2px rgba(23, 105, 255, 0.2), 0 1px 5px 0 rgba(23, 105, 255, 0.12);
            background-color: #1769ff;
        }

            .jss218:hover, .jss218:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(23, 105, 255, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(23, 105, 255, 0.2);
                background-color: #1769ff;
            }

        .jss219 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(234, 76, 137, 0.14), 0 3px 1px -2px rgba(234, 76, 137, 0.2), 0 1px 5px 0 rgba(234, 76, 137, 0.12);
            background-color: #ea4c89;
        }

            .jss219:hover, .jss219:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(234, 76, 137, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(234, 76, 137, 0.2);
                background-color: #ea4c89;
            }

        .jss220 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(255, 69, 0, 0.14), 0 3px 1px -2px rgba(255, 69, 0, 0.2), 0 1px 5px 0 rgba(255, 69, 0, 0.12);
            background-color: #ff4500;
        }

            .jss220:hover, .jss220:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(255, 69, 0, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(255, 69, 0, 0.2);
                background-color: #ff4500;
            }

        .jss221, .jss221:focus, .jss221:hover {
            color: #FFF;
            background: transparent;
            box-shadow: none;
        }

            .jss221.jss220, .jss221.jss220:focus, .jss221.jss220:hover, .jss221.jss220:visited {
                color: #ff4500;
            }

            .jss221.jss219, .jss221.jss219:focus, .jss221.jss219:hover, .jss221.jss219:visited {
                color: #ea4c89;
            }

            .jss221.jss218, .jss221.jss218:focus, .jss221.jss218:hover, .jss221.jss218:visited {
                color: #1769ff;
            }

            .jss221.jss217, .jss221.jss217:focus, .jss221.jss217:hover, .jss221.jss217:visited {
                color: #333;
            }

            .jss221.jss216, .jss221.jss216:focus, .jss221.jss216:hover, .jss221.jss216:visited {
                color: #35465c;
            }

            .jss221.jss215, .jss221.jss215:focus, .jss221.jss215:hover, .jss221.jss215:visited {
                color: #e52d27;
            }

            .jss221.jss214, .jss221.jss214:focus, .jss221.jss214:hover, .jss221.jss214:visited {
                color: #cc2127;
            }

            .jss221.jss213, .jss221.jss213:focus, .jss221.jss213:hover, .jss221.jss213:visited {
                color: #0976b4;
            }

            .jss221.jss212, .jss221.jss212:focus, .jss221.jss212:hover, .jss221.jss212:visited {
                color: #dd4b39;
            }

            .jss221.jss211, .jss221.jss211:focus, .jss221.jss211:hover, .jss221.jss211:visited {
                color: #3b5998;
            }

            .jss221.jss210, .jss221.jss210:focus, .jss221.jss210:hover, .jss221.jss210:visited {
                color: #55acee;
            }

            .jss221.jss207, .jss221.jss207:focus, .jss221.jss207:hover, .jss221.jss207:visited {
                color: #f44336;
            }

            .jss221.jss208, .jss221.jss208:focus, .jss221.jss208:hover, .jss221.jss208:visited {
                color: #e91e63;
            }

            .jss221.jss206, .jss221.jss206:focus, .jss221.jss206:hover, .jss221.jss206:visited {
                color: #ff9800;
            }

            .jss221.jss205, .jss221.jss205:focus, .jss221.jss205:hover, .jss221.jss205:visited {
                color: #4caf50;
            }

            .jss221.jss204, .jss221.jss204:focus, .jss221.jss204:hover, .jss221.jss204:visited {
                color: #00acc1;
            }

            .jss221.jss203, .jss221.jss203:focus, .jss221.jss203:hover, .jss221.jss203:visited {
                color: #9c27b0;
            }

        .jss222, .jss222:focus, .jss222:hover {
            color: inherit;
            background: transparent;
            box-shadow: none;
        }

        .jss223 {
            opacity: 0.65;
            pointer-events: none;
        }

        .jss224 {
            padding: 1.125rem 2.25rem;
            font-size: 0.875rem;
            line-height: 1.333333;
            border-radius: 0.2rem;
        }

            .jss224.jss229 .fab, .jss224.jss229 .fas, .jss224.jss229 .far, .jss224.jss229 .fal, .jss224.jss229 svg, .jss224.jss229 .material-icons {
                margin-top: -4px;
            }

        .jss225 {
            padding: 0.40625rem 1.25rem;
            font-size: 0.6875rem;
            line-height: 1.5;
            border-radius: 0.2rem;
        }

            .jss225.jss229 .fab, .jss225.jss229 .fas, .jss225.jss229 .far, .jss225.jss229 .fal, .jss225.jss229 svg, .jss225.jss229 .material-icons {
                margin-top: 1px;
            }

        .jss226 {
            border-radius: 30px;
        }

        .jss227 {
            width: 100% !important;
        }

        .jss228, .jss228:hover, .jss228:focus {
            color: #999;
            box-shadow: none;
            background-color: transparent;
        }

        .jss229 {
            width: 41px;
            height: 41px;
            font-size: 20px;
            min-width: 41px;
            padding-left: 12px;
            padding-right: 12px;
        }

            .jss229 .fab, .jss229 .fas, .jss229 .far, .jss229 .fal, .jss229 svg, .jss229 .material-icons {
                margin-right: 0px;
            }

            .jss229.jss224 {
                width: 57px;
                height: 57px;
                min-width: 57px;
                line-height: 56px;
            }

            .jss229.jss225 {
                width: 30px;
                height: 30px;
                min-width: 30px;
            }

                .jss229.jss225 .fab, .jss229.jss225 .fas, .jss229.jss225 .far, .jss229.jss225 .fal, .jss229.jss225 .material-icons {
                    font-size: 17px;
                    line-height: 29px;
                }

                .jss229.jss225 svg {
                    width: 17px;
                    height: 17px;
                }

            .jss229.jss224 .fab, .jss229.jss224 .fas, .jss229.jss224 .far, .jss229.jss224 .fal, .jss229.jss224 .material-icons {
                font-size: 32px;
                line-height: 56px;
            }

            .jss229.jss224 svg {
                width: 32px;
                height: 32px;
            }

        .jss230 {
            color: #FFF;
            border: none;
            cursor: pointer;
            margin: .3125rem 1px;
            padding: 12px 30px;
            position: relative;
            font-size: 12px;
            min-width: auto;
            box-shadow: 0 2px 2px 0 rgba(153, 153, 153, 0.14), 0 3px 1px -2px rgba(153, 153, 153, 0.2), 0 1px 5px 0 rgba(153, 153, 153, 0.12);
            min-height: auto;
            text-align: center;
            transition: box-shadow 0.2s cubic-bezier(0.4, 0, 1, 1), background-color 0.2s cubic-bezier(0.4, 0, 0.2, 1);
            font-weight: 400;
            line-height: 1.42857143;
            white-space: nowrap;
            will-change: box-shadow, transform;
            touch-action: manipulation;
            border-radius: 3px;
            letter-spacing: 0;
            text-transform: uppercase;
            vertical-align: middle;
            background-color: #999;
        }

            .jss230:hover, .jss230:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(153, 153, 153, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(153, 153, 153, 0.2);
                background-color: #999;
            }

            .jss230 .fab, .jss230 .fas, .jss230 .far, .jss230 .fal, .jss230 .material-icons {
                top: 0;
                display: inline-block;
                position: relative;
                font-size: 1.1rem;
                margin-top: -1em;
                margin-right: 4px;
                margin-bottom: -1em;
                vertical-align: middle;
            }

            .jss230 svg {
                top: 0;
                width: 18px;
                height: 18px;
                display: inline-block;
                position: relative;
                margin-right: 4px;
                vertical-align: middle;
            }

            .jss230.jss258 .fab, .jss230.jss258 .fas, .jss230.jss258 .far, .jss230.jss258 .fal, .jss230.jss258 .material-icons {
                top: 0px;
                left: 0px;
                width: 100%;
                height: 100%;
                position: absolute;
                font-size: 20px;
                transform: none;
                margin-top: 0px;
                line-height: 41px;
            }

        .jss231 {
            width: 100%;
        }

        .jss232 {
            box-shadow: 0 2px 2px 0 rgba(156, 39, 176, 0.14), 0 3px 1px -2px rgba(156, 39, 176, 0.2), 0 1px 5px 0 rgba(156, 39, 176, 0.12);
            background-color: #9c27b0;
        }

            .jss232:hover, .jss232:focus {
                box-shadow: 0 14px 26px -12px rgba(156, 39, 176, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(156, 39, 176, 0.2);
                background-color: #9c27b0;
            }

        .jss233 {
            box-shadow: 0 2px 2px 0 rgba(0, 172, 193, 0.14), 0 3px 1px -2px rgba(0, 172, 193, 0.2), 0 1px 5px 0 rgba(0, 172, 193, 0.12);
            background-color: #00acc1;
        }

            .jss233:hover, .jss233:focus {
                box-shadow: 0 14px 26px -12px rgba(0, 172, 193, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 172, 193, 0.2);
                background-color: #00acc1;
            }

        .jss234 {
            box-shadow: 0 2px 2px 0 rgba(76, 175, 80, 0.14), 0 3px 1px -2px rgba(76, 175, 80, 0.2), 0 1px 5px 0 rgba(76, 175, 80, 0.12);
            background-color: #4caf50;
        }

            .jss234:hover, .jss234:focus {
                box-shadow: 0 14px 26px -12px rgba(76, 175, 80, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(76, 175, 80, 0.2);
                background-color: #4caf50;
            }

        .jss235 {
            box-shadow: 0 2px 2px 0 rgba(255, 152, 0, 0.14), 0 3px 1px -2px rgba(255, 152, 0, 0.2), 0 1px 5px 0 rgba(255, 152, 0, 0.12);
            background-color: #ff9800;
        }

            .jss235:hover, .jss235:focus {
                box-shadow: 0 14px 26px -12px rgba(255, 152, 0, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(255, 152, 0, 0.2);
                background-color: #ff9800;
            }

        .jss236 {
            box-shadow: 0 2px 2px 0 rgba(244, 67, 54, 0.14), 0 3px 1px -2px rgba(244, 67, 54, 0.2), 0 1px 5px 0 rgba(244, 67, 54, 0.12);
            background-color: #f44336;
        }

            .jss236:hover, .jss236:focus {
                box-shadow: 0 14px 26px -12px rgba(244, 67, 54, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(244, 67, 54, 0.2);
                background-color: #f44336;
            }

        .jss237 {
            box-shadow: 0 2px 2px 0 rgba(233, 30, 99, 0.14), 0 3px 1px -2px rgba(233, 30, 99, 0.2), 0 1px 5px 0 rgba(233, 30, 99, 0.12);
            background-color: #e91e63;
        }

            .jss237:hover, .jss237:focus {
                box-shadow: 0 14px 26px -12px rgba(233, 30, 99, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(233, 30, 99, 0.2);
                background-color: #e91e63;
            }

        .jss238, .jss238:focus, .jss238:hover {
            color: #999;
            background-color: #FFF;
        }

        .jss239 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(85, 172, 238, 0.14), 0 3px 1px -2px rgba(85, 172, 238, 0.2), 0 1px 5px 0 rgba(85, 172, 238, 0.12);
            background-color: #55acee;
        }

            .jss239:hover, .jss239:focus, .jss239:visited {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(85, 172, 238, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(85, 172, 238, 0.2);
                background-color: #55acee;
            }

        .jss240 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(59, 89, 152, 0.14), 0 3px 1px -2px rgba(59, 89, 152, 0.2), 0 1px 5px 0 rgba(59, 89, 152, 0.12);
            background-color: #3b5998;
        }

            .jss240:hover, .jss240:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(59, 89, 152, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(59, 89, 152, 0.2);
                background-color: #3b5998;
            }

        .jss241 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(221, 75, 57, 0.14), 0 3px 1px -2px rgba(221, 75, 57, 0.2), 0 1px 5px 0 rgba(221, 75, 57, 0.12);
            background-color: #dd4b39;
        }

            .jss241:hover, .jss241:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(221, 75, 57, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(221, 75, 57, 0.2);
                background-color: #dd4b39;
            }

        .jss242 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(9, 118, 180, 0.14), 0 3px 1px -2px rgba(9, 118, 180, 0.2), 0 1px 5px 0 rgba(9, 118, 180, 0.12);
            background-color: #0976b4;
        }

            .jss242:hover, .jss242:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(9, 118, 180, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(9, 118, 180, 0.2);
                background-color: #0976b4;
            }

        .jss243 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(204, 33, 39, 0.14), 0 3px 1px -2px rgba(204, 33, 39, 0.2), 0 1px 5px 0 rgba(204, 33, 39, 0.12);
            background-color: #cc2127;
        }

            .jss243:hover, .jss243:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(204, 33, 39, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(204, 33, 39, 0.2);
                background-color: #cc2127;
            }

        .jss244 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(229, 45, 39, 0.14), 0 3px 1px -2px rgba(229, 45, 39, 0.2), 0 1px 5px 0 rgba(229, 45, 39, 0.12);
            background-color: #e52d27;
        }

            .jss244:hover, .jss244:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(229, 45, 39, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(229, 45, 39, 0.2);
                background-color: #e52d27;
            }

        .jss245 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(53, 70, 92, 0.14), 0 3px 1px -2px rgba(53, 70, 92, 0.2), 0 1px 5px 0 rgba(53, 70, 92, 0.12);
            background-color: #35465c;
        }

            .jss245:hover, .jss245:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(53, 70, 92, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(53, 70, 92, 0.2);
                background-color: #35465c;
            }

        .jss246 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(85, 85, 85, 0.14), 0 3px 1px -2px rgba(85, 85, 85, 0.2), 0 1px 5px 0 rgba(85, 85, 85, 0.12);
            background-color: #333;
        }

            .jss246:hover, .jss246:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(85, 85, 85, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(85, 85, 85, 0.2);
                background-color: #333;
            }

        .jss247 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(23, 105, 255, 0.14), 0 3px 1px -2px rgba(23, 105, 255, 0.2), 0 1px 5px 0 rgba(23, 105, 255, 0.12);
            background-color: #1769ff;
        }

            .jss247:hover, .jss247:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(23, 105, 255, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(23, 105, 255, 0.2);
                background-color: #1769ff;
            }

        .jss248 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(234, 76, 137, 0.14), 0 3px 1px -2px rgba(234, 76, 137, 0.2), 0 1px 5px 0 rgba(234, 76, 137, 0.12);
            background-color: #ea4c89;
        }

            .jss248:hover, .jss248:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(234, 76, 137, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(234, 76, 137, 0.2);
                background-color: #ea4c89;
            }

        .jss249 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(255, 69, 0, 0.14), 0 3px 1px -2px rgba(255, 69, 0, 0.2), 0 1px 5px 0 rgba(255, 69, 0, 0.12);
            background-color: #ff4500;
        }

            .jss249:hover, .jss249:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(255, 69, 0, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(255, 69, 0, 0.2);
                background-color: #ff4500;
            }

        .jss250, .jss250:focus, .jss250:hover {
            color: #FFF;
            background: transparent;
            box-shadow: none;
        }

            .jss250.jss249, .jss250.jss249:focus, .jss250.jss249:hover, .jss250.jss249:visited {
                color: #ff4500;
            }

            .jss250.jss248, .jss250.jss248:focus, .jss250.jss248:hover, .jss250.jss248:visited {
                color: #ea4c89;
            }

            .jss250.jss247, .jss250.jss247:focus, .jss250.jss247:hover, .jss250.jss247:visited {
                color: #1769ff;
            }

            .jss250.jss246, .jss250.jss246:focus, .jss250.jss246:hover, .jss250.jss246:visited {
                color: #333;
            }

            .jss250.jss245, .jss250.jss245:focus, .jss250.jss245:hover, .jss250.jss245:visited {
                color: #35465c;
            }

            .jss250.jss244, .jss250.jss244:focus, .jss250.jss244:hover, .jss250.jss244:visited {
                color: #e52d27;
            }

            .jss250.jss243, .jss250.jss243:focus, .jss250.jss243:hover, .jss250.jss243:visited {
                color: #cc2127;
            }

            .jss250.jss242, .jss250.jss242:focus, .jss250.jss242:hover, .jss250.jss242:visited {
                color: #0976b4;
            }

            .jss250.jss241, .jss250.jss241:focus, .jss250.jss241:hover, .jss250.jss241:visited {
                color: #dd4b39;
            }

            .jss250.jss240, .jss250.jss240:focus, .jss250.jss240:hover, .jss250.jss240:visited {
                color: #3b5998;
            }

            .jss250.jss239, .jss250.jss239:focus, .jss250.jss239:hover, .jss250.jss239:visited {
                color: #55acee;
            }

            .jss250.jss236, .jss250.jss236:focus, .jss250.jss236:hover, .jss250.jss236:visited {
                color: #f44336;
            }

            .jss250.jss237, .jss250.jss237:focus, .jss250.jss237:hover, .jss250.jss237:visited {
                color: #e91e63;
            }

            .jss250.jss235, .jss250.jss235:focus, .jss250.jss235:hover, .jss250.jss235:visited {
                color: #ff9800;
            }

            .jss250.jss234, .jss250.jss234:focus, .jss250.jss234:hover, .jss250.jss234:visited {
                color: #4caf50;
            }

            .jss250.jss233, .jss250.jss233:focus, .jss250.jss233:hover, .jss250.jss233:visited {
                color: #00acc1;
            }

            .jss250.jss232, .jss250.jss232:focus, .jss250.jss232:hover, .jss250.jss232:visited {
                color: #9c27b0;
            }

        .jss251, .jss251:focus, .jss251:hover {
            color: inherit;
            background: transparent;
            box-shadow: none;
        }

        .jss252 {
            opacity: 0.65;
            pointer-events: none;
        }

        .jss253 {
            padding: 1.125rem 2.25rem;
            font-size: 0.875rem;
            line-height: 1.333333;
            border-radius: 0.2rem;
        }

            .jss253.jss258 .fab, .jss253.jss258 .fas, .jss253.jss258 .far, .jss253.jss258 .fal, .jss253.jss258 svg, .jss253.jss258 .material-icons {
                margin-top: -4px;
            }

        .jss254 {
            padding: 0.40625rem 1.25rem;
            font-size: 0.6875rem;
            line-height: 1.5;
            border-radius: 0.2rem;
        }

            .jss254.jss258 .fab, .jss254.jss258 .fas, .jss254.jss258 .far, .jss254.jss258 .fal, .jss254.jss258 svg, .jss254.jss258 .material-icons {
                margin-top: 1px;
            }

        .jss255 {
            border-radius: 30px;
        }

        .jss256 {
            width: 100% !important;
        }

        .jss257, .jss257:hover, .jss257:focus {
            color: #999;
            box-shadow: none;
            background-color: transparent;
        }

        .jss258 {
            width: 41px;
            height: 41px;
            font-size: 20px;
            min-width: 41px;
            padding-left: 12px;
            padding-right: 12px;
        }

            .jss258 .fab, .jss258 .fas, .jss258 .far, .jss258 .fal, .jss258 svg, .jss258 .material-icons {
                margin-right: 0px;
            }

            .jss258.jss253 {
                width: 57px;
                height: 57px;
                min-width: 57px;
                line-height: 56px;
            }

            .jss258.jss254 {
                width: 30px;
                height: 30px;
                min-width: 30px;
            }

                .jss258.jss254 .fab, .jss258.jss254 .fas, .jss258.jss254 .far, .jss258.jss254 .fal, .jss258.jss254 .material-icons {
                    font-size: 17px;
                    line-height: 29px;
                }

                .jss258.jss254 svg {
                    width: 17px;
                    height: 17px;
                }

            .jss258.jss253 .fab, .jss258.jss253 .fas, .jss258.jss253 .far, .jss258.jss253 .fal, .jss258.jss253 .material-icons {
                font-size: 32px;
                line-height: 56px;
            }

            .jss258.jss253 svg {
                width: 32px;
                height: 32px;
            }

        .jss259 {
            color: #FFF;
            border: none;
            cursor: pointer;
            margin: .3125rem 1px;
            padding: 12px 30px;
            position: relative;
            font-size: 12px;
            min-width: auto;
            box-shadow: 0 2px 2px 0 rgba(153, 153, 153, 0.14), 0 3px 1px -2px rgba(153, 153, 153, 0.2), 0 1px 5px 0 rgba(153, 153, 153, 0.12);
            min-height: auto;
            text-align: center;
            transition: box-shadow 0.2s cubic-bezier(0.4, 0, 1, 1), background-color 0.2s cubic-bezier(0.4, 0, 0.2, 1);
            font-weight: 400;
            line-height: 1.42857143;
            white-space: nowrap;
            will-change: box-shadow, transform;
            touch-action: manipulation;
            border-radius: 3px;
            letter-spacing: 0;
            text-transform: uppercase;
            vertical-align: middle;
            background-color: #999;
        }

            .jss259:hover, .jss259:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(153, 153, 153, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(153, 153, 153, 0.2);
                background-color: #999;
            }

            .jss259 .fab, .jss259 .fas, .jss259 .far, .jss259 .fal, .jss259 .material-icons {
                top: 0;
                display: inline-block;
                position: relative;
                font-size: 1.1rem;
                margin-top: -1em;
                margin-right: 4px;
                margin-bottom: -1em;
                vertical-align: middle;
            }

            .jss259 svg {
                top: 0;
                width: 18px;
                height: 18px;
                display: inline-block;
                position: relative;
                margin-right: 4px;
                vertical-align: middle;
            }

            .jss259.jss287 .fab, .jss259.jss287 .fas, .jss259.jss287 .far, .jss259.jss287 .fal, .jss259.jss287 .material-icons {
                top: 0px;
                left: 0px;
                width: 100%;
                height: 100%;
                position: absolute;
                font-size: 20px;
                transform: none;
                margin-top: 0px;
                line-height: 41px;
            }

        .jss260 {
            width: 100%;
        }

        .jss261 {
            box-shadow: 0 2px 2px 0 rgba(156, 39, 176, 0.14), 0 3px 1px -2px rgba(156, 39, 176, 0.2), 0 1px 5px 0 rgba(156, 39, 176, 0.12);
            background-color: #9c27b0;
        }

            .jss261:hover, .jss261:focus {
                box-shadow: 0 14px 26px -12px rgba(156, 39, 176, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(156, 39, 176, 0.2);
                background-color: #9c27b0;
            }

        .jss262 {
            box-shadow: 0 2px 2px 0 rgba(0, 172, 193, 0.14), 0 3px 1px -2px rgba(0, 172, 193, 0.2), 0 1px 5px 0 rgba(0, 172, 193, 0.12);
            background-color: #00acc1;
        }

            .jss262:hover, .jss262:focus {
                box-shadow: 0 14px 26px -12px rgba(0, 172, 193, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 172, 193, 0.2);
                background-color: #00acc1;
            }

        .jss263 {
            box-shadow: 0 2px 2px 0 rgba(76, 175, 80, 0.14), 0 3px 1px -2px rgba(76, 175, 80, 0.2), 0 1px 5px 0 rgba(76, 175, 80, 0.12);
            background-color: #4caf50;
        }

            .jss263:hover, .jss263:focus {
                box-shadow: 0 14px 26px -12px rgba(76, 175, 80, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(76, 175, 80, 0.2);
                background-color: #4caf50;
            }

        .jss264 {
            box-shadow: 0 2px 2px 0 rgba(255, 152, 0, 0.14), 0 3px 1px -2px rgba(255, 152, 0, 0.2), 0 1px 5px 0 rgba(255, 152, 0, 0.12);
            background-color: #ff9800;
        }

            .jss264:hover, .jss264:focus {
                box-shadow: 0 14px 26px -12px rgba(255, 152, 0, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(255, 152, 0, 0.2);
                background-color: #ff9800;
            }

        .jss265 {
            box-shadow: 0 2px 2px 0 rgba(244, 67, 54, 0.14), 0 3px 1px -2px rgba(244, 67, 54, 0.2), 0 1px 5px 0 rgba(244, 67, 54, 0.12);
            background-color: #f44336;
        }

            .jss265:hover, .jss265:focus {
                box-shadow: 0 14px 26px -12px rgba(244, 67, 54, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(244, 67, 54, 0.2);
                background-color: #f44336;
            }

        .jss266 {
            box-shadow: 0 2px 2px 0 rgba(233, 30, 99, 0.14), 0 3px 1px -2px rgba(233, 30, 99, 0.2), 0 1px 5px 0 rgba(233, 30, 99, 0.12);
            background-color: #e91e63;
        }

            .jss266:hover, .jss266:focus {
                box-shadow: 0 14px 26px -12px rgba(233, 30, 99, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(233, 30, 99, 0.2);
                background-color: #e91e63;
            }

        .jss267, .jss267:focus, .jss267:hover {
            color: #999;
            background-color: #FFF;
        }

        .jss268 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(85, 172, 238, 0.14), 0 3px 1px -2px rgba(85, 172, 238, 0.2), 0 1px 5px 0 rgba(85, 172, 238, 0.12);
            background-color: #55acee;
        }

            .jss268:hover, .jss268:focus, .jss268:visited {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(85, 172, 238, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(85, 172, 238, 0.2);
                background-color: #55acee;
            }

        .jss269 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(59, 89, 152, 0.14), 0 3px 1px -2px rgba(59, 89, 152, 0.2), 0 1px 5px 0 rgba(59, 89, 152, 0.12);
            background-color: #3b5998;
        }

            .jss269:hover, .jss269:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(59, 89, 152, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(59, 89, 152, 0.2);
                background-color: #3b5998;
            }

        .jss270 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(221, 75, 57, 0.14), 0 3px 1px -2px rgba(221, 75, 57, 0.2), 0 1px 5px 0 rgba(221, 75, 57, 0.12);
            background-color: #dd4b39;
        }

            .jss270:hover, .jss270:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(221, 75, 57, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(221, 75, 57, 0.2);
                background-color: #dd4b39;
            }

        .jss271 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(9, 118, 180, 0.14), 0 3px 1px -2px rgba(9, 118, 180, 0.2), 0 1px 5px 0 rgba(9, 118, 180, 0.12);
            background-color: #0976b4;
        }

            .jss271:hover, .jss271:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(9, 118, 180, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(9, 118, 180, 0.2);
                background-color: #0976b4;
            }

        .jss272 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(204, 33, 39, 0.14), 0 3px 1px -2px rgba(204, 33, 39, 0.2), 0 1px 5px 0 rgba(204, 33, 39, 0.12);
            background-color: #cc2127;
        }

            .jss272:hover, .jss272:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(204, 33, 39, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(204, 33, 39, 0.2);
                background-color: #cc2127;
            }

        .jss273 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(229, 45, 39, 0.14), 0 3px 1px -2px rgba(229, 45, 39, 0.2), 0 1px 5px 0 rgba(229, 45, 39, 0.12);
            background-color: #e52d27;
        }

            .jss273:hover, .jss273:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(229, 45, 39, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(229, 45, 39, 0.2);
                background-color: #e52d27;
            }

        .jss274 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(53, 70, 92, 0.14), 0 3px 1px -2px rgba(53, 70, 92, 0.2), 0 1px 5px 0 rgba(53, 70, 92, 0.12);
            background-color: #35465c;
        }

            .jss274:hover, .jss274:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(53, 70, 92, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(53, 70, 92, 0.2);
                background-color: #35465c;
            }

        .jss275 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(85, 85, 85, 0.14), 0 3px 1px -2px rgba(85, 85, 85, 0.2), 0 1px 5px 0 rgba(85, 85, 85, 0.12);
            background-color: #333;
        }

            .jss275:hover, .jss275:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(85, 85, 85, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(85, 85, 85, 0.2);
                background-color: #333;
            }

        .jss276 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(23, 105, 255, 0.14), 0 3px 1px -2px rgba(23, 105, 255, 0.2), 0 1px 5px 0 rgba(23, 105, 255, 0.12);
            background-color: #1769ff;
        }

            .jss276:hover, .jss276:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(23, 105, 255, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(23, 105, 255, 0.2);
                background-color: #1769ff;
            }

        .jss277 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(234, 76, 137, 0.14), 0 3px 1px -2px rgba(234, 76, 137, 0.2), 0 1px 5px 0 rgba(234, 76, 137, 0.12);
            background-color: #ea4c89;
        }

            .jss277:hover, .jss277:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(234, 76, 137, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(234, 76, 137, 0.2);
                background-color: #ea4c89;
            }

        .jss278 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(255, 69, 0, 0.14), 0 3px 1px -2px rgba(255, 69, 0, 0.2), 0 1px 5px 0 rgba(255, 69, 0, 0.12);
            background-color: #ff4500;
        }

            .jss278:hover, .jss278:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(255, 69, 0, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(255, 69, 0, 0.2);
                background-color: #ff4500;
            }

        .jss279, .jss279:focus, .jss279:hover {
            color: #FFF;
            background: transparent;
            box-shadow: none;
        }

            .jss279.jss278, .jss279.jss278:focus, .jss279.jss278:hover, .jss279.jss278:visited {
                color: #ff4500;
            }

            .jss279.jss277, .jss279.jss277:focus, .jss279.jss277:hover, .jss279.jss277:visited {
                color: #ea4c89;
            }

            .jss279.jss276, .jss279.jss276:focus, .jss279.jss276:hover, .jss279.jss276:visited {
                color: #1769ff;
            }

            .jss279.jss275, .jss279.jss275:focus, .jss279.jss275:hover, .jss279.jss275:visited {
                color: #333;
            }

            .jss279.jss274, .jss279.jss274:focus, .jss279.jss274:hover, .jss279.jss274:visited {
                color: #35465c;
            }

            .jss279.jss273, .jss279.jss273:focus, .jss279.jss273:hover, .jss279.jss273:visited {
                color: #e52d27;
            }

            .jss279.jss272, .jss279.jss272:focus, .jss279.jss272:hover, .jss279.jss272:visited {
                color: #cc2127;
            }

            .jss279.jss271, .jss279.jss271:focus, .jss279.jss271:hover, .jss279.jss271:visited {
                color: #0976b4;
            }

            .jss279.jss270, .jss279.jss270:focus, .jss279.jss270:hover, .jss279.jss270:visited {
                color: #dd4b39;
            }

            .jss279.jss269, .jss279.jss269:focus, .jss279.jss269:hover, .jss279.jss269:visited {
                color: #3b5998;
            }

            .jss279.jss268, .jss279.jss268:focus, .jss279.jss268:hover, .jss279.jss268:visited {
                color: #55acee;
            }

            .jss279.jss265, .jss279.jss265:focus, .jss279.jss265:hover, .jss279.jss265:visited {
                color: #f44336;
            }

            .jss279.jss266, .jss279.jss266:focus, .jss279.jss266:hover, .jss279.jss266:visited {
                color: #e91e63;
            }

            .jss279.jss264, .jss279.jss264:focus, .jss279.jss264:hover, .jss279.jss264:visited {
                color: #ff9800;
            }

            .jss279.jss263, .jss279.jss263:focus, .jss279.jss263:hover, .jss279.jss263:visited {
                color: #4caf50;
            }

            .jss279.jss262, .jss279.jss262:focus, .jss279.jss262:hover, .jss279.jss262:visited {
                color: #00acc1;
            }

            .jss279.jss261, .jss279.jss261:focus, .jss279.jss261:hover, .jss279.jss261:visited {
                color: #9c27b0;
            }

        .jss280, .jss280:focus, .jss280:hover {
            color: inherit;
            background: transparent;
            box-shadow: none;
        }

        .jss281 {
            opacity: 0.65;
            pointer-events: none;
        }

        .jss282 {
            padding: 1.125rem 2.25rem;
            font-size: 0.875rem;
            line-height: 1.333333;
            border-radius: 0.2rem;
        }

            .jss282.jss287 .fab, .jss282.jss287 .fas, .jss282.jss287 .far, .jss282.jss287 .fal, .jss282.jss287 svg, .jss282.jss287 .material-icons {
                margin-top: -4px;
            }

        .jss283 {
            padding: 0.40625rem 1.25rem;
            font-size: 0.6875rem;
            line-height: 1.5;
            border-radius: 0.2rem;
        }

            .jss283.jss287 .fab, .jss283.jss287 .fas, .jss283.jss287 .far, .jss283.jss287 .fal, .jss283.jss287 svg, .jss283.jss287 .material-icons {
                margin-top: 1px;
            }

        .jss284 {
            border-radius: 30px;
        }

        .jss285 {
            width: 100% !important;
        }

        .jss286, .jss286:hover, .jss286:focus {
            color: #999;
            box-shadow: none;
            background-color: transparent;
        }

        .jss287 {
            width: 41px;
            height: 41px;
            font-size: 20px;
            min-width: 41px;
            padding-left: 12px;
            padding-right: 12px;
        }

            .jss287 .fab, .jss287 .fas, .jss287 .far, .jss287 .fal, .jss287 svg, .jss287 .material-icons {
                margin-right: 0px;
            }

            .jss287.jss282 {
                width: 57px;
                height: 57px;
                min-width: 57px;
                line-height: 56px;
            }

            .jss287.jss283 {
                width: 30px;
                height: 30px;
                min-width: 30px;
            }

                .jss287.jss283 .fab, .jss287.jss283 .fas, .jss287.jss283 .far, .jss287.jss283 .fal, .jss287.jss283 .material-icons {
                    font-size: 17px;
                    line-height: 29px;
                }

                .jss287.jss283 svg {
                    width: 17px;
                    height: 17px;
                }

            .jss287.jss282 .fab, .jss287.jss282 .fas, .jss287.jss282 .far, .jss287.jss282 .fal, .jss287.jss282 .material-icons {
                font-size: 32px;
                line-height: 56px;
            }

            .jss287.jss282 svg {
                width: 32px;
                height: 32px;
            }

        .jss288 {
            color: #FFF;
            border: none;
            cursor: pointer;
            margin: .3125rem 1px;
            padding: 12px 30px;
            position: relative;
            font-size: 12px;
            min-width: auto;
            box-shadow: 0 2px 2px 0 rgba(153, 153, 153, 0.14), 0 3px 1px -2px rgba(153, 153, 153, 0.2), 0 1px 5px 0 rgba(153, 153, 153, 0.12);
            min-height: auto;
            text-align: center;
            transition: box-shadow 0.2s cubic-bezier(0.4, 0, 1, 1), background-color 0.2s cubic-bezier(0.4, 0, 0.2, 1);
            font-weight: 400;
            line-height: 1.42857143;
            white-space: nowrap;
            will-change: box-shadow, transform;
            touch-action: manipulation;
            border-radius: 3px;
            letter-spacing: 0;
            text-transform: uppercase;
            vertical-align: middle;
            background-color: #999;
        }

            .jss288:hover, .jss288:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(153, 153, 153, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(153, 153, 153, 0.2);
                background-color: #999;
            }

            .jss288 .fab, .jss288 .fas, .jss288 .far, .jss288 .fal, .jss288 .material-icons {
                top: 0;
                display: inline-block;
                position: relative;
                font-size: 1.1rem;
                margin-top: -1em;
                margin-right: 4px;
                margin-bottom: -1em;
                vertical-align: middle;
            }

            .jss288 svg {
                top: 0;
                width: 18px;
                height: 18px;
                display: inline-block;
                position: relative;
                margin-right: 4px;
                vertical-align: middle;
            }

            .jss288.jss316 .fab, .jss288.jss316 .fas, .jss288.jss316 .far, .jss288.jss316 .fal, .jss288.jss316 .material-icons {
                top: 0px;
                left: 0px;
                width: 100%;
                height: 100%;
                position: absolute;
                font-size: 20px;
                transform: none;
                margin-top: 0px;
                line-height: 41px;
            }

        .jss289 {
            width: 100%;
        }

        .jss290 {
            box-shadow: 0 2px 2px 0 rgba(156, 39, 176, 0.14), 0 3px 1px -2px rgba(156, 39, 176, 0.2), 0 1px 5px 0 rgba(156, 39, 176, 0.12);
            background-color: #9c27b0;
        }

            .jss290:hover, .jss290:focus {
                box-shadow: 0 14px 26px -12px rgba(156, 39, 176, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(156, 39, 176, 0.2);
                background-color: #9c27b0;
            }

        .jss291 {
            box-shadow: 0 2px 2px 0 rgba(0, 172, 193, 0.14), 0 3px 1px -2px rgba(0, 172, 193, 0.2), 0 1px 5px 0 rgba(0, 172, 193, 0.12);
            background-color: #00acc1;
        }

            .jss291:hover, .jss291:focus {
                box-shadow: 0 14px 26px -12px rgba(0, 172, 193, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 172, 193, 0.2);
                background-color: #00acc1;
            }

        .jss292 {
            box-shadow: 0 2px 2px 0 rgba(76, 175, 80, 0.14), 0 3px 1px -2px rgba(76, 175, 80, 0.2), 0 1px 5px 0 rgba(76, 175, 80, 0.12);
            background-color: #4caf50;
        }

            .jss292:hover, .jss292:focus {
                box-shadow: 0 14px 26px -12px rgba(76, 175, 80, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(76, 175, 80, 0.2);
                background-color: #4caf50;
            }

        .jss293 {
            box-shadow: 0 2px 2px 0 rgba(255, 152, 0, 0.14), 0 3px 1px -2px rgba(255, 152, 0, 0.2), 0 1px 5px 0 rgba(255, 152, 0, 0.12);
            background-color: #ff9800;
        }

            .jss293:hover, .jss293:focus {
                box-shadow: 0 14px 26px -12px rgba(255, 152, 0, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(255, 152, 0, 0.2);
                background-color: #ff9800;
            }

        .jss294 {
            box-shadow: 0 2px 2px 0 rgba(244, 67, 54, 0.14), 0 3px 1px -2px rgba(244, 67, 54, 0.2), 0 1px 5px 0 rgba(244, 67, 54, 0.12);
            background-color: #f44336;
        }

            .jss294:hover, .jss294:focus {
                box-shadow: 0 14px 26px -12px rgba(244, 67, 54, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(244, 67, 54, 0.2);
                background-color: #f44336;
            }

        .jss295 {
            box-shadow: 0 2px 2px 0 rgba(233, 30, 99, 0.14), 0 3px 1px -2px rgba(233, 30, 99, 0.2), 0 1px 5px 0 rgba(233, 30, 99, 0.12);
            background-color: #e91e63;
        }

            .jss295:hover, .jss295:focus {
                box-shadow: 0 14px 26px -12px rgba(233, 30, 99, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(233, 30, 99, 0.2);
                background-color: #e91e63;
            }

        .jss296, .jss296:focus, .jss296:hover {
            color: #999;
            background-color: #FFF;
        }

        .jss297 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(85, 172, 238, 0.14), 0 3px 1px -2px rgba(85, 172, 238, 0.2), 0 1px 5px 0 rgba(85, 172, 238, 0.12);
            background-color: #55acee;
        }

            .jss297:hover, .jss297:focus, .jss297:visited {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(85, 172, 238, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(85, 172, 238, 0.2);
                background-color: #55acee;
            }

        .jss298 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(59, 89, 152, 0.14), 0 3px 1px -2px rgba(59, 89, 152, 0.2), 0 1px 5px 0 rgba(59, 89, 152, 0.12);
            background-color: #3b5998;
        }

            .jss298:hover, .jss298:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(59, 89, 152, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(59, 89, 152, 0.2);
                background-color: #3b5998;
            }

        .jss299 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(221, 75, 57, 0.14), 0 3px 1px -2px rgba(221, 75, 57, 0.2), 0 1px 5px 0 rgba(221, 75, 57, 0.12);
            background-color: #dd4b39;
        }

            .jss299:hover, .jss299:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(221, 75, 57, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(221, 75, 57, 0.2);
                background-color: #dd4b39;
            }

        .jss300 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(9, 118, 180, 0.14), 0 3px 1px -2px rgba(9, 118, 180, 0.2), 0 1px 5px 0 rgba(9, 118, 180, 0.12);
            background-color: #0976b4;
        }

            .jss300:hover, .jss300:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(9, 118, 180, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(9, 118, 180, 0.2);
                background-color: #0976b4;
            }

        .jss301 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(204, 33, 39, 0.14), 0 3px 1px -2px rgba(204, 33, 39, 0.2), 0 1px 5px 0 rgba(204, 33, 39, 0.12);
            background-color: #cc2127;
        }

            .jss301:hover, .jss301:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(204, 33, 39, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(204, 33, 39, 0.2);
                background-color: #cc2127;
            }

        .jss302 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(229, 45, 39, 0.14), 0 3px 1px -2px rgba(229, 45, 39, 0.2), 0 1px 5px 0 rgba(229, 45, 39, 0.12);
            background-color: #e52d27;
        }

            .jss302:hover, .jss302:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(229, 45, 39, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(229, 45, 39, 0.2);
                background-color: #e52d27;
            }

        .jss303 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(53, 70, 92, 0.14), 0 3px 1px -2px rgba(53, 70, 92, 0.2), 0 1px 5px 0 rgba(53, 70, 92, 0.12);
            background-color: #35465c;
        }

            .jss303:hover, .jss303:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(53, 70, 92, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(53, 70, 92, 0.2);
                background-color: #35465c;
            }

        .jss304 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(85, 85, 85, 0.14), 0 3px 1px -2px rgba(85, 85, 85, 0.2), 0 1px 5px 0 rgba(85, 85, 85, 0.12);
            background-color: #333;
        }

            .jss304:hover, .jss304:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(85, 85, 85, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(85, 85, 85, 0.2);
                background-color: #333;
            }

        .jss305 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(23, 105, 255, 0.14), 0 3px 1px -2px rgba(23, 105, 255, 0.2), 0 1px 5px 0 rgba(23, 105, 255, 0.12);
            background-color: #1769ff;
        }

            .jss305:hover, .jss305:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(23, 105, 255, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(23, 105, 255, 0.2);
                background-color: #1769ff;
            }

        .jss306 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(234, 76, 137, 0.14), 0 3px 1px -2px rgba(234, 76, 137, 0.2), 0 1px 5px 0 rgba(234, 76, 137, 0.12);
            background-color: #ea4c89;
        }

            .jss306:hover, .jss306:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(234, 76, 137, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(234, 76, 137, 0.2);
                background-color: #ea4c89;
            }

        .jss307 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(255, 69, 0, 0.14), 0 3px 1px -2px rgba(255, 69, 0, 0.2), 0 1px 5px 0 rgba(255, 69, 0, 0.12);
            background-color: #ff4500;
        }

            .jss307:hover, .jss307:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(255, 69, 0, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(255, 69, 0, 0.2);
                background-color: #ff4500;
            }

        .jss308, .jss308:focus, .jss308:hover {
            color: #FFF;
            background: transparent;
            box-shadow: none;
        }

            .jss308.jss307, .jss308.jss307:focus, .jss308.jss307:hover, .jss308.jss307:visited {
                color: #ff4500;
            }

            .jss308.jss306, .jss308.jss306:focus, .jss308.jss306:hover, .jss308.jss306:visited {
                color: #ea4c89;
            }

            .jss308.jss305, .jss308.jss305:focus, .jss308.jss305:hover, .jss308.jss305:visited {
                color: #1769ff;
            }

            .jss308.jss304, .jss308.jss304:focus, .jss308.jss304:hover, .jss308.jss304:visited {
                color: #333;
            }

            .jss308.jss303, .jss308.jss303:focus, .jss308.jss303:hover, .jss308.jss303:visited {
                color: #35465c;
            }

            .jss308.jss302, .jss308.jss302:focus, .jss308.jss302:hover, .jss308.jss302:visited {
                color: #e52d27;
            }

            .jss308.jss301, .jss308.jss301:focus, .jss308.jss301:hover, .jss308.jss301:visited {
                color: #cc2127;
            }

            .jss308.jss300, .jss308.jss300:focus, .jss308.jss300:hover, .jss308.jss300:visited {
                color: #0976b4;
            }

            .jss308.jss299, .jss308.jss299:focus, .jss308.jss299:hover, .jss308.jss299:visited {
                color: #dd4b39;
            }

            .jss308.jss298, .jss308.jss298:focus, .jss308.jss298:hover, .jss308.jss298:visited {
                color: #3b5998;
            }

            .jss308.jss297, .jss308.jss297:focus, .jss308.jss297:hover, .jss308.jss297:visited {
                color: #55acee;
            }

            .jss308.jss294, .jss308.jss294:focus, .jss308.jss294:hover, .jss308.jss294:visited {
                color: #f44336;
            }

            .jss308.jss295, .jss308.jss295:focus, .jss308.jss295:hover, .jss308.jss295:visited {
                color: #e91e63;
            }

            .jss308.jss293, .jss308.jss293:focus, .jss308.jss293:hover, .jss308.jss293:visited {
                color: #ff9800;
            }

            .jss308.jss292, .jss308.jss292:focus, .jss308.jss292:hover, .jss308.jss292:visited {
                color: #4caf50;
            }

            .jss308.jss291, .jss308.jss291:focus, .jss308.jss291:hover, .jss308.jss291:visited {
                color: #00acc1;
            }

            .jss308.jss290, .jss308.jss290:focus, .jss308.jss290:hover, .jss308.jss290:visited {
                color: #9c27b0;
            }

        .jss309, .jss309:focus, .jss309:hover {
            color: inherit;
            background: transparent;
            box-shadow: none;
        }

        .jss310 {
            opacity: 0.65;
            pointer-events: none;
        }

        .jss311 {
            padding: 1.125rem 2.25rem;
            font-size: 0.875rem;
            line-height: 1.333333;
            border-radius: 0.2rem;
        }

            .jss311.jss316 .fab, .jss311.jss316 .fas, .jss311.jss316 .far, .jss311.jss316 .fal, .jss311.jss316 svg, .jss311.jss316 .material-icons {
                margin-top: -4px;
            }

        .jss312 {
            padding: 0.40625rem 1.25rem;
            font-size: 0.6875rem;
            line-height: 1.5;
            border-radius: 0.2rem;
        }

            .jss312.jss316 .fab, .jss312.jss316 .fas, .jss312.jss316 .far, .jss312.jss316 .fal, .jss312.jss316 svg, .jss312.jss316 .material-icons {
                margin-top: 1px;
            }

        .jss313 {
            border-radius: 30px;
        }

        .jss314 {
            width: 100% !important;
        }

        .jss315, .jss315:hover, .jss315:focus {
            color: #999;
            box-shadow: none;
            background-color: transparent;
        }

        .jss316 {
            width: 41px;
            height: 41px;
            font-size: 20px;
            min-width: 41px;
            padding-left: 12px;
            padding-right: 12px;
        }

            .jss316 .fab, .jss316 .fas, .jss316 .far, .jss316 .fal, .jss316 svg, .jss316 .material-icons {
                margin-right: 0px;
            }

            .jss316.jss311 {
                width: 57px;
                height: 57px;
                min-width: 57px;
                line-height: 56px;
            }

            .jss316.jss312 {
                width: 30px;
                height: 30px;
                min-width: 30px;
            }

                .jss316.jss312 .fab, .jss316.jss312 .fas, .jss316.jss312 .far, .jss316.jss312 .fal, .jss316.jss312 .material-icons {
                    font-size: 17px;
                    line-height: 29px;
                }

                .jss316.jss312 svg {
                    width: 17px;
                    height: 17px;
                }

            .jss316.jss311 .fab, .jss316.jss311 .fas, .jss316.jss311 .far, .jss316.jss311 .fal, .jss316.jss311 .material-icons {
                font-size: 32px;
                line-height: 56px;
            }

            .jss316.jss311 svg {
                width: 32px;
                height: 32px;
            }

        .jss317 {
            color: #FFF;
            border: none;
            cursor: pointer;
            margin: .3125rem 1px;
            padding: 12px 30px;
            position: relative;
            font-size: 12px;
            min-width: auto;
            box-shadow: 0 2px 2px 0 rgba(153, 153, 153, 0.14), 0 3px 1px -2px rgba(153, 153, 153, 0.2), 0 1px 5px 0 rgba(153, 153, 153, 0.12);
            min-height: auto;
            text-align: center;
            transition: box-shadow 0.2s cubic-bezier(0.4, 0, 1, 1), background-color 0.2s cubic-bezier(0.4, 0, 0.2, 1);
            font-weight: 400;
            line-height: 1.42857143;
            white-space: nowrap;
            will-change: box-shadow, transform;
            touch-action: manipulation;
            border-radius: 3px;
            letter-spacing: 0;
            text-transform: uppercase;
            vertical-align: middle;
            background-color: #999;
        }

            .jss317:hover, .jss317:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(153, 153, 153, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(153, 153, 153, 0.2);
                background-color: #999;
            }

            .jss317 .fab, .jss317 .fas, .jss317 .far, .jss317 .fal, .jss317 .material-icons {
                top: 0;
                display: inline-block;
                position: relative;
                font-size: 1.1rem;
                margin-top: -1em;
                margin-right: 4px;
                margin-bottom: -1em;
                vertical-align: middle;
            }

            .jss317 svg {
                top: 0;
                width: 18px;
                height: 18px;
                display: inline-block;
                position: relative;
                margin-right: 4px;
                vertical-align: middle;
            }

            .jss317.jss345 .fab, .jss317.jss345 .fas, .jss317.jss345 .far, .jss317.jss345 .fal, .jss317.jss345 .material-icons {
                top: 0px;
                left: 0px;
                width: 100%;
                height: 100%;
                position: absolute;
                font-size: 20px;
                transform: none;
                margin-top: 0px;
                line-height: 41px;
            }

        .jss318 {
            width: 100%;
        }

        .jss319 {
            box-shadow: 0 2px 2px 0 rgba(156, 39, 176, 0.14), 0 3px 1px -2px rgba(156, 39, 176, 0.2), 0 1px 5px 0 rgba(156, 39, 176, 0.12);
            background-color: #9c27b0;
        }

            .jss319:hover, .jss319:focus {
                box-shadow: 0 14px 26px -12px rgba(156, 39, 176, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(156, 39, 176, 0.2);
                background-color: #9c27b0;
            }

        .jss320 {
            box-shadow: 0 2px 2px 0 rgba(0, 172, 193, 0.14), 0 3px 1px -2px rgba(0, 172, 193, 0.2), 0 1px 5px 0 rgba(0, 172, 193, 0.12);
            background-color: #00acc1;
        }

            .jss320:hover, .jss320:focus {
                box-shadow: 0 14px 26px -12px rgba(0, 172, 193, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 172, 193, 0.2);
                background-color: #00acc1;
            }

        .jss321 {
            box-shadow: 0 2px 2px 0 rgba(76, 175, 80, 0.14), 0 3px 1px -2px rgba(76, 175, 80, 0.2), 0 1px 5px 0 rgba(76, 175, 80, 0.12);
            background-color: #4caf50;
        }

            .jss321:hover, .jss321:focus {
                box-shadow: 0 14px 26px -12px rgba(76, 175, 80, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(76, 175, 80, 0.2);
                background-color: #4caf50;
            }

        .jss322 {
            box-shadow: 0 2px 2px 0 rgba(255, 152, 0, 0.14), 0 3px 1px -2px rgba(255, 152, 0, 0.2), 0 1px 5px 0 rgba(255, 152, 0, 0.12);
            background-color: #ff9800;
        }

            .jss322:hover, .jss322:focus {
                box-shadow: 0 14px 26px -12px rgba(255, 152, 0, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(255, 152, 0, 0.2);
                background-color: #ff9800;
            }

        .jss323 {
            box-shadow: 0 2px 2px 0 rgba(244, 67, 54, 0.14), 0 3px 1px -2px rgba(244, 67, 54, 0.2), 0 1px 5px 0 rgba(244, 67, 54, 0.12);
            background-color: #f44336;
        }

            .jss323:hover, .jss323:focus {
                box-shadow: 0 14px 26px -12px rgba(244, 67, 54, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(244, 67, 54, 0.2);
                background-color: #f44336;
            }

        .jss324 {
            box-shadow: 0 2px 2px 0 rgba(233, 30, 99, 0.14), 0 3px 1px -2px rgba(233, 30, 99, 0.2), 0 1px 5px 0 rgba(233, 30, 99, 0.12);
            background-color: #e91e63;
        }

            .jss324:hover, .jss324:focus {
                box-shadow: 0 14px 26px -12px rgba(233, 30, 99, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(233, 30, 99, 0.2);
                background-color: #e91e63;
            }

        .jss325, .jss325:focus, .jss325:hover {
            color: #999;
            background-color: #FFF;
        }

        .jss326 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(85, 172, 238, 0.14), 0 3px 1px -2px rgba(85, 172, 238, 0.2), 0 1px 5px 0 rgba(85, 172, 238, 0.12);
            background-color: #55acee;
        }

            .jss326:hover, .jss326:focus, .jss326:visited {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(85, 172, 238, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(85, 172, 238, 0.2);
                background-color: #55acee;
            }

        .jss327 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(59, 89, 152, 0.14), 0 3px 1px -2px rgba(59, 89, 152, 0.2), 0 1px 5px 0 rgba(59, 89, 152, 0.12);
            background-color: #3b5998;
        }

            .jss327:hover, .jss327:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(59, 89, 152, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(59, 89, 152, 0.2);
                background-color: #3b5998;
            }

        .jss328 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(221, 75, 57, 0.14), 0 3px 1px -2px rgba(221, 75, 57, 0.2), 0 1px 5px 0 rgba(221, 75, 57, 0.12);
            background-color: #dd4b39;
        }

            .jss328:hover, .jss328:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(221, 75, 57, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(221, 75, 57, 0.2);
                background-color: #dd4b39;
            }

        .jss329 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(9, 118, 180, 0.14), 0 3px 1px -2px rgba(9, 118, 180, 0.2), 0 1px 5px 0 rgba(9, 118, 180, 0.12);
            background-color: #0976b4;
        }

            .jss329:hover, .jss329:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(9, 118, 180, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(9, 118, 180, 0.2);
                background-color: #0976b4;
            }

        .jss330 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(204, 33, 39, 0.14), 0 3px 1px -2px rgba(204, 33, 39, 0.2), 0 1px 5px 0 rgba(204, 33, 39, 0.12);
            background-color: #cc2127;
        }

            .jss330:hover, .jss330:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(204, 33, 39, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(204, 33, 39, 0.2);
                background-color: #cc2127;
            }

        .jss331 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(229, 45, 39, 0.14), 0 3px 1px -2px rgba(229, 45, 39, 0.2), 0 1px 5px 0 rgba(229, 45, 39, 0.12);
            background-color: #e52d27;
        }

            .jss331:hover, .jss331:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(229, 45, 39, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(229, 45, 39, 0.2);
                background-color: #e52d27;
            }

        .jss332 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(53, 70, 92, 0.14), 0 3px 1px -2px rgba(53, 70, 92, 0.2), 0 1px 5px 0 rgba(53, 70, 92, 0.12);
            background-color: #35465c;
        }

            .jss332:hover, .jss332:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(53, 70, 92, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(53, 70, 92, 0.2);
                background-color: #35465c;
            }

        .jss333 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(85, 85, 85, 0.14), 0 3px 1px -2px rgba(85, 85, 85, 0.2), 0 1px 5px 0 rgba(85, 85, 85, 0.12);
            background-color: #333;
        }

            .jss333:hover, .jss333:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(85, 85, 85, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(85, 85, 85, 0.2);
                background-color: #333;
            }

        .jss334 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(23, 105, 255, 0.14), 0 3px 1px -2px rgba(23, 105, 255, 0.2), 0 1px 5px 0 rgba(23, 105, 255, 0.12);
            background-color: #1769ff;
        }

            .jss334:hover, .jss334:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(23, 105, 255, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(23, 105, 255, 0.2);
                background-color: #1769ff;
            }

        .jss335 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(234, 76, 137, 0.14), 0 3px 1px -2px rgba(234, 76, 137, 0.2), 0 1px 5px 0 rgba(234, 76, 137, 0.12);
            background-color: #ea4c89;
        }

            .jss335:hover, .jss335:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(234, 76, 137, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(234, 76, 137, 0.2);
                background-color: #ea4c89;
            }

        .jss336 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(255, 69, 0, 0.14), 0 3px 1px -2px rgba(255, 69, 0, 0.2), 0 1px 5px 0 rgba(255, 69, 0, 0.12);
            background-color: #ff4500;
        }

            .jss336:hover, .jss336:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(255, 69, 0, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(255, 69, 0, 0.2);
                background-color: #ff4500;
            }

        .jss337, .jss337:focus, .jss337:hover {
            color: #FFF;
            background: transparent;
            box-shadow: none;
        }

            .jss337.jss336, .jss337.jss336:focus, .jss337.jss336:hover, .jss337.jss336:visited {
                color: #ff4500;
            }

            .jss337.jss335, .jss337.jss335:focus, .jss337.jss335:hover, .jss337.jss335:visited {
                color: #ea4c89;
            }

            .jss337.jss334, .jss337.jss334:focus, .jss337.jss334:hover, .jss337.jss334:visited {
                color: #1769ff;
            }

            .jss337.jss333, .jss337.jss333:focus, .jss337.jss333:hover, .jss337.jss333:visited {
                color: #333;
            }

            .jss337.jss332, .jss337.jss332:focus, .jss337.jss332:hover, .jss337.jss332:visited {
                color: #35465c;
            }

            .jss337.jss331, .jss337.jss331:focus, .jss337.jss331:hover, .jss337.jss331:visited {
                color: #e52d27;
            }

            .jss337.jss330, .jss337.jss330:focus, .jss337.jss330:hover, .jss337.jss330:visited {
                color: #cc2127;
            }

            .jss337.jss329, .jss337.jss329:focus, .jss337.jss329:hover, .jss337.jss329:visited {
                color: #0976b4;
            }

            .jss337.jss328, .jss337.jss328:focus, .jss337.jss328:hover, .jss337.jss328:visited {
                color: #dd4b39;
            }

            .jss337.jss327, .jss337.jss327:focus, .jss337.jss327:hover, .jss337.jss327:visited {
                color: #3b5998;
            }

            .jss337.jss326, .jss337.jss326:focus, .jss337.jss326:hover, .jss337.jss326:visited {
                color: #55acee;
            }

            .jss337.jss323, .jss337.jss323:focus, .jss337.jss323:hover, .jss337.jss323:visited {
                color: #f44336;
            }

            .jss337.jss324, .jss337.jss324:focus, .jss337.jss324:hover, .jss337.jss324:visited {
                color: #e91e63;
            }

            .jss337.jss322, .jss337.jss322:focus, .jss337.jss322:hover, .jss337.jss322:visited {
                color: #ff9800;
            }

            .jss337.jss321, .jss337.jss321:focus, .jss337.jss321:hover, .jss337.jss321:visited {
                color: #4caf50;
            }

            .jss337.jss320, .jss337.jss320:focus, .jss337.jss320:hover, .jss337.jss320:visited {
                color: #00acc1;
            }

            .jss337.jss319, .jss337.jss319:focus, .jss337.jss319:hover, .jss337.jss319:visited {
                color: #9c27b0;
            }

        .jss338, .jss338:focus, .jss338:hover {
            color: inherit;
            background: transparent;
            box-shadow: none;
        }

        .jss339 {
            opacity: 0.65;
            pointer-events: none;
        }

        .jss340 {
            padding: 1.125rem 2.25rem;
            font-size: 0.875rem;
            line-height: 1.333333;
            border-radius: 0.2rem;
        }

            .jss340.jss345 .fab, .jss340.jss345 .fas, .jss340.jss345 .far, .jss340.jss345 .fal, .jss340.jss345 svg, .jss340.jss345 .material-icons {
                margin-top: -4px;
            }

        .jss341 {
            padding: 0.40625rem 1.25rem;
            font-size: 0.6875rem;
            line-height: 1.5;
            border-radius: 0.2rem;
        }

            .jss341.jss345 .fab, .jss341.jss345 .fas, .jss341.jss345 .far, .jss341.jss345 .fal, .jss341.jss345 svg, .jss341.jss345 .material-icons {
                margin-top: 1px;
            }

        .jss342 {
            border-radius: 30px;
        }

        .jss343 {
            width: 100% !important;
        }

        .jss344, .jss344:hover, .jss344:focus {
            color: #999;
            box-shadow: none;
            background-color: transparent;
        }

        .jss345 {
            width: 41px;
            height: 41px;
            font-size: 20px;
            min-width: 41px;
            padding-left: 12px;
            padding-right: 12px;
        }

            .jss345 .fab, .jss345 .fas, .jss345 .far, .jss345 .fal, .jss345 svg, .jss345 .material-icons {
                margin-right: 0px;
            }

            .jss345.jss340 {
                width: 57px;
                height: 57px;
                min-width: 57px;
                line-height: 56px;
            }

            .jss345.jss341 {
                width: 30px;
                height: 30px;
                min-width: 30px;
            }

                .jss345.jss341 .fab, .jss345.jss341 .fas, .jss345.jss341 .far, .jss345.jss341 .fal, .jss345.jss341 .material-icons {
                    font-size: 17px;
                    line-height: 29px;
                }

                .jss345.jss341 svg {
                    width: 17px;
                    height: 17px;
                }

            .jss345.jss340 .fab, .jss345.jss340 .fas, .jss345.jss340 .far, .jss345.jss340 .fal, .jss345.jss340 .material-icons {
                font-size: 32px;
                line-height: 56px;
            }

            .jss345.jss340 svg {
                width: 32px;
                height: 32px;
            }

        .jss346 {
            color: #3C4858;
            margin-top: 0;
            min-height: auto;
            font-family: 'Roboto', 'Helvetica', 'Arial', sans-serif;
            font-weight: 300;
            margin-bottom: 3px;
            text-decoration: none;
        }

            .jss346 small {
                color: #777;
                font-size: 65%;
                font-weight: 400;
                line-height: 1;
            }

            .jss346 a {
                color: #3C4858;
                margin-top: .625rem;
                min-height: auto;
                font-family: 'Roboto', 'Helvetica', 'Arial', sans-serif;
                font-weight: 300;
                margin-bottom: 0.75rem;
                text-decoration: none;
            }

                .jss346 a small {
                    color: #777;
                    font-size: 65%;
                    font-weight: 400;
                    line-height: 1;
                }

        .jss347 {
            color: #FFFFFF;
            margin-top: 0;
            min-height: auto;
            font-family: 'Roboto', 'Helvetica', 'Arial', sans-serif;
            font-weight: 300;
            margin-bottom: 3px;
            text-decoration: none;
        }

            .jss347 small {
                color: #777;
                font-size: 65%;
                font-weight: 400;
                line-height: 1;
            }

            .jss347 a {
                color: #3C4858;
                margin-top: .625rem;
                min-height: auto;
                font-family: 'Roboto', 'Helvetica', 'Arial', sans-serif;
                font-weight: 300;
                margin-bottom: 0.75rem;
                text-decoration: none;
            }

                .jss347 a small {
                    color: #777;
                    font-size: 65%;
                    font-weight: 400;
                    line-height: 1;
                }

        .jss348 {
            color: rgba(255, 255, 255, 0.8);
            margin: 0;
            font-size: .875rem;
        }

        .jss349 {
            color: #999999;
            margin-top: 10px;
        }

        .jss350 {
            color: #333333;
            width: 130px;
            border: 1px solid #E5E5E5;
            height: 130px;
            margin: 10px auto 0;
            line-height: 174px;
            border-radius: 50%;
        }

            .jss350 svg {
                width: 55px;
                height: 55px;
            }

            .jss350 .fab, .jss350 .fas, .jss350 .far, .jss350 .fal, .jss350 .material-icons {
                width: 55px;
                font-size: 55px;
            }

        .jss351 {
            color: #e91e63, #ec407a, #d81b60, #eb3573, #c2185b;
        }

        .jss352 {
            margin-top: 30px;
        }

        .jss353 {
            margin-top: 30px;
        }

            .jss353 svg {
                width: 40px;
                height: 40px;
            }

        .jss354 {
            color: #999999;
            font-style: italic;
        }

        .jss355 {
            width: calc(100% + 30px);
            margin: 0 -15px;
        }

        .jss356 {
            padding: 0 15px !important;
        }

        .jss357 {
            color: rgba(0, 0, 0, 0.87);
            width: 100%;
            border: 0;
            display: flex;
            position: relative;
            font-size: .875rem;
            min-width: 0;
            word-wrap: break-word;
            background: #FFF;
            box-shadow: 0 1px 4px 0 rgba(0, 0, 0, 0.14);
            margin-top: 30px;
            border-radius: 6px;
            margin-bottom: 30px;
            flex-direction: column;
        }

        .jss358 {
            background: transparent;
            box-shadow: none;
        }

        .jss359 {
            margin-top: 30px;
            text-align: center;
        }

        .jss360 {
            margin-top: 60px;
        }

        .jss361 {
            box-shadow: 0 16px 38px -12px rgba(0, 0, 0, 0.56), 0 4px 25px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 0, 0, 0.2);
        }

        .jss362 {
            text-align: center;
            background-size: cover;
            background-position: center center;
        }

            .jss362:after {
                top: 0;
                left: 0;
                width: 100%;
                height: 100%;
                content: "";
                display: block;
                z-index: 1;
                position: absolute;
                border-radius: 6px;
                background-color: rgba(0, 0, 0, 0.56);
            }

            .jss362 small {
                color: rgba(255, 255, 255, 0.7) !important;
            }

        .jss363 {
            text-align: center;
        }

            .jss363:after {
                background-color: rgba(0, 0, 0, 0.7) !important;
            }

            .jss363 ul {
                margin: 10px auto;
                padding: 0;
                max-width: 240px;
                list-style: none;
            }

                .jss363 ul li {
                    color: #999;
                    padding: 12px 0px;
                    text-align: center;
                    border-bottom: 1px solid rgba(153, 153, 153,0.3);
                }

                    .jss363 ul li:last-child {
                        border: 0;
                    }

                    .jss363 ul li b {
                        color: #3C4858;
                    }

            .jss363 h1 {
                margin-top: 30px;
            }

                .jss363 h1 small {
                    height: 0;
                    display: inline-flex;
                    font-size: 18px;
                }

                    .jss363 h1 small:first-child {
                        top: -17px;
                        position: relative;
                        font-size: 26px;
                    }

            .jss363 ul li svg, .jss363 ul li .fab, .jss363 ul li .fas, .jss363 ul li .far, .jss363 ul li .fal, .jss363 ul li .material-icons {
                top: 7px;
                position: relative;
            }

        .jss364 ul li {
            color: #FFF;
            border-color: rgba(255, 255, 255,0.3);
        }

            .jss364 ul li b, .jss364 ul li svg, .jss364 ul li .fab, .jss364 ul li .fas, .jss364 ul li .far, .jss364 ul li .fal, .jss364 ul li .material-icons {
                color: #FFF;
                font-weight: 700;
            }

        .jss365 {
            margin-top: 30px;
        }

        .jss366 {
            color: #FFF;
            background: linear-gradient(60deg,#ab47bc,#7b1fa2);
        }

            .jss366 h1 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss367 {
            color: #FFF;
            background: linear-gradient(60deg,#26c6da,#0097a7);
        }

            .jss367 h1 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss368 {
            color: #FFF;
            background: linear-gradient(60deg,#66bb6a,#388e3c);
        }

            .jss368 h1 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss369 {
            color: #FFF;
            background: linear-gradient(60deg,#ffa726,#f57c00);
        }

            .jss369 h1 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss370 {
            color: #FFF;
            background: linear-gradient(60deg,#ef5350,#d32f2f);
        }

            .jss370 h1 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss371 {
            color: #FFF;
            background: linear-gradient(60deg,#ec407a,#c2185b);
        }

            .jss371 h1 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss372 p {
            margin-top: 0px;
            padding-top: 0px;
        }

        .jss373 {
            transform: translate3d(0, 0, 0);
            transition: all 300ms linear;
        }

        .jss374 {
            padding: 0.75rem 1.25rem;
            z-index: 3 !important;
            background: transparent;
            border-bottom: none;
            margin-bottom: 0;
        }

            .jss374.jss375, .jss374.jss376, .jss374.jss377, .jss374.jss378, .jss374.jss380, .jss374.jss379, .jss374.jss382, .jss374.jss383, .jss374.jss384, .jss374.jss385, .jss374.jss386, .jss374.jss387, .jss374.jss388 {
                color: #FFF;
                margin: 0 15px;
                padding: 0;
                position: relative;
            }

            .jss374:first-child {
                border-radius: calc(.25rem - 1px) calc(.25rem - 1px) 0 0;
            }

            .jss374.jss379 svg {
                width: 36px;
                height: 36px;
                margin: 10px 10px 4px;
                font-size: 36px;
                text-align: center;
                line-height: 56px;
            }

            .jss374.jss379 .fab, .jss374.jss379 .fas, .jss374.jss379 .far, .jss374.jss379 .fal, .jss374.jss379 .material-icons {
                width: 56px;
                height: 56px;
                overflow: unset;
                font-size: 36px;
                text-align: center;
                line-height: 56px;
                margin-bottom: 1px;
            }

            .jss374.jss379.jss380 {
                text-align: right;
            }

            .jss374.jss376 {
                margin-top: -30px;
                margin-left: 15px;
                margin-right: 15px;
                border-radius: 6px;
            }

            .jss374.jss381 {
                display: inline-block;
            }

            .jss374.jss382:not(.jss380):not(.jss376):not(.jss381), .jss374.jss383:not(.jss380):not(.jss376):not(.jss381), .jss374.jss384:not(.jss380):not(.jss376):not(.jss381), .jss374.jss385:not(.jss380):not(.jss376):not(.jss381), .jss374.jss386:not(.jss380):not(.jss376):not(.jss381), .jss374.jss387:not(.jss380):not(.jss376):not(.jss381), .jss374.jss388:not(.jss380):not(.jss376):not(.jss381) {
                padding: 15px;
                margin-top: -20px;
                border-radius: 3px;
            }

        .jss375 {
            margin-left: 0px;
            margin-right: 0px;
        }

            .jss375.jss376 {
                margin: 0 !important;
            }

        .jss376 {
            padding: 0;
            z-index: 1;
            position: relative;
        }

            .jss376 img {
                width: 100%;
                box-shadow: 0 5px 15px -8px rgba(0, 0, 0, 0.24), 0 8px 10px -5px rgba(0, 0, 0, 0.2);
                border-radius: 6px;
                pointer-events: none;
            }

            .jss376 a {
                display: block;
            }

        .jss377 {
            margin: 0 15px;
            margin-top: -20px;
        }

        .jss378 {
            width: 100%;
            padding: 20px 0;
            margin-top: -40px;
            margin-left: 20px;
            margin-right: 20px;
            margin-bottom: 15px;
        }

        .jss379 .jss380 {
            text-align: right;
        }

        .jss379 h1, .jss379 h2, .jss379 h3, .jss379 h4, .jss379 h5, .jss379 h6 {
            margin: 0 !important;
        }

        .jss380.jss382, .jss380.jss383, .jss380.jss384, .jss380.jss385, .jss380.jss386, .jss380.jss387, .jss380.jss388 {
            background: transparent;
            box-shadow: none;
        }

        .jss380 .fab, .jss380 .fas, .jss380 .far, .jss380 .fal, .jss380 .material-icons {
            width: 33px;
            height: 33px;
            text-align: center;
            line-height: 33px;
        }

        .jss380 svg {
            width: 24px;
            height: 24px;
            margin: 5px 4px 0px;
            text-align: center;
            line-height: 33px;
        }

        .jss382 {
            color: #FFF;
        }

            .jss382:not(.jss381):not(.jss380) {
                background: linear-gradient(60deg, #ffa726, #fb8c00);
                box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(255, 152, 0,.4);
            }

        .jss383 {
            color: #FFF;
        }

            .jss383:not(.jss381):not(.jss380) {
                background: linear-gradient(60deg, #66bb6a, #43a047);
                box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(76, 175, 80,.4);
            }

        .jss384 {
            color: #FFF;
        }

            .jss384:not(.jss381):not(.jss380) {
                background: linear-gradient(60deg, #ef5350, #e53935);
                box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(244, 67, 54,.4);
            }

        .jss385 {
            color: #FFF;
        }

            .jss385:not(.jss381):not(.jss380) {
                background: linear-gradient(60deg, #26c6da, #00acc1);
                box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(0, 172, 193,.4);
            }

        .jss386 {
            color: #FFF;
        }

            .jss386:not(.jss381):not(.jss380) {
                background: linear-gradient(60deg, #ab47bc, #8e24aa);
                box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(156, 39, 176,.4);
            }

        .jss387 {
            color: #FFF;
        }

            .jss387:not(.jss381):not(.jss380) {
                background: linear-gradient(60deg, #ec407a, #d81b60);
                box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(233, 30, 99,.4);
            }

        .jss388 {
            color: #FFF;
        }

            .jss388:not(.jss381):not(.jss380) {
                background: linear-gradient(60deg, #263238, #212121);
                box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(33, 33, 33,.4);
            }

        .jss389 {
            float: none;
            display: inline-block;
            padding: 15px;
            margin-top: -20px;
            margin-right: 0;
            border-radius: 3px;
            background-color: #999;
        }

        .jss390 {
            background: linear-gradient(60deg, #ffa726, #fb8c00);
            box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(255, 152, 0,.4);
        }

        .jss391 {
            background: linear-gradient(60deg, #66bb6a, #43a047);
            box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(76, 175, 80,.4);
        }

        .jss392 {
            background: linear-gradient(60deg, #ef5350, #e53935);
            box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(244, 67, 54,.4);
        }

        .jss393 {
            background: linear-gradient(60deg, #26c6da, #00acc1);
            box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(0, 172, 193,.4);
        }

        .jss394 {
            background: linear-gradient(60deg, #ab47bc, #8e24aa);
            box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(156, 39, 176,.4);
        }

        .jss395 {
            background: linear-gradient(60deg, #ec407a, #d81b60);
            box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(233, 30, 99,.4);
        }

        .jss396 {
            flex: 1 1 auto;
            padding: 0.9375rem 20px;
            position: relative;
            -webkit-box-flex: 1;
        }

        .jss397 {
            margin: 0 auto;
            z-index: 2;
            position: relative;
            max-width: 440px;
            min-height: 280px;
            padding-top: 40px;
            padding-bottom: 40px;
        }

        .jss398 {
            padding-left: 5px;
            padding-right: 5px;
        }

        .jss399 {
            padding-left: 15px;
            padding-right: 15px;
        }

            .jss399 form {
                margin: 0;
            }

        .jss400 {
            margin: 0px !important;
            padding: 15px !important;
        }

        .jss401 {
            padding: 0px 30px 0px 30px;
        }

        .jss402 {
            border-radius: 6px;
        }

            .jss402 h1 small, .jss402 h2 small, .jss402 h3 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss403 {
            margin-top: 15px;
        }

        .jss404 {
            padding: 0px !important;
        }

        .jss405 {
            color: #ff9800;
        }

        .jss406 {
            color: #9c27b0;
        }

        .jss407 {
            color: #f44336;
        }

        .jss408 {
            color: #4caf50;
        }

        .jss409 {
            color: #00acc1;
        }

        .jss410 {
            color: #e91e63;
        }

        .jss411 {
            color: #999;
        }

        .jss412 {
            text-align: right;
        }

        .jss413 {
            width: 100%;
            overflow: auto;
            max-width: 100%;
            margin-bottom: 0;
            border-spacing: 0;
            border-collapse: collapse;
            background-color: transparent;
        }

        .jss414 {
            font-size: 0.9em !important;
            text-transform: uppercase !important;
        }

        .jss415 {
            font-size: 1.25em !important;
        }

        .jss416 {
            color: rgba(0, 0, 0, 0.87);
            border: none !important;
        }

        .jss417 {
            padding: 12px 8px !important;
            position: relative;
            font-size: 1em;
            border-top: 1px solid #DDD;
            font-family: "Roboto", "Helvetica", "Arial", sans-serif;
            font-weight: 300;
            line-height: 1.42857143;
            border-bottom: none;
            vertical-align: middle;
        }

        @media (max-width:959.95px) {
            .jss417 {
                min-width: 32px;
                min-height: 24px;
            }
        }

        .jss418 {
            font-size: 1.25em;
            text-align: right;
            font-weight: 500;
            padding-top: 14px;
        }

        .jss419 {
            font-size: 26px;
            margin-top: 5px;
            text-align: right;
            font-weight: 300;
        }

        .jss420 {
            min-height: 0.1%;
            overflow-x: auto;
        }

        .jss421 {
            background-color: #f9f9f9;
        }

        .jss422:hover {
            background-color: #f5f5f5;
        }

        .jss423 {
            background-color: #fcf8e3;
        }

            .jss423:hover {
                background-color: #faf2cc;
            }

        .jss424 {
            background-color: #f2dede;
        }

            .jss424:hover {
                background-color: #ebcccc;
            }

        .jss425 {
            background-color: #dff0d8;
        }

            .jss425:hover {
                background-color: #d0e9c6;
            }

        .jss426 {
            background-color: #d9edf7;
        }

            .jss426:hover {
                background-color: #c4e3f3;
            }

        .jss427 {
            height: 48px;
        }

        .jss428 {
            height: 56px;
        }

        .jss429 {
            padding: 0 15px !important;
        }

        .jss430 {
            float: left;
            padding: 10px 10px 10px 0px;
            line-height: 24px;
        }

        .jss431 {
            float: right;
            padding: 10px 0px 10px 10px !important;
        }

        .jss432 {
            display: none !important;
        }

        .jss433 {
            min-height: unset !important;
        }

            .jss433 .jss434 {
                font-size: 0.875rem;
            }

        .jss434 {
            color: #FFF !important;
            width: unset !important;
            border: 0 !important;
            height: unset !important;
            padding: 10px 15px;
            max-width: unset !important;
            min-width: unset !important;
            max-height: unset !important;
            min-height: unset !important;
            line-height: 24px;
            margin-left: 4px;
            border-radius: 3px;
        }

            .jss434:last-child {
                margin-left: 0px;
            }

        .jss435 {
            padding: 0px;
        }

        .jss436 {
            font-size: 12px;
            font-weight: 500;
        }

        .jss437 {
            transition: 0.2s background-color 0.1s;
            background-color: rgba(255, 255, 255, 0.2);
        }

        .jss438 {
            width: unset !important;
            height: unset !important;
            display: inline-block;
            font-size: 12px;
            max-width: unset !important;
            min-width: unset !important;
            max-height: unset !important;
            min-height: unset !important;
            font-weight: 500;
            line-height: 24px;
        }

            .jss438 > svg, .jss438 > .fab, .jss438 > .fas, .jss438 > .far, .jss438 > .fal, .jss438 > .material-icons {
                margin: -1px 5px 0 0 !important;
                vertical-align: middle;
            }

        .jss439 {
            color: rgba(0, 0, 0, 0.87);
            width: 100%;
            border: 0;
            display: flex;
            position: relative;
            font-size: .875rem;
            min-width: 0;
            word-wrap: break-word;
            background: #FFF;
            box-shadow: 0 1px 4px 0 rgba(0, 0, 0, 0.14);
            margin-top: 30px;
            border-radius: 6px;
            margin-bottom: 30px;
            flex-direction: column;
        }

        .jss440 {
            background: transparent;
            box-shadow: none;
        }

        .jss441 {
            margin-top: 30px;
            text-align: center;
        }

        .jss442 {
            margin-top: 60px;
        }

        .jss443 {
            box-shadow: 0 16px 38px -12px rgba(0, 0, 0, 0.56), 0 4px 25px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 0, 0, 0.2);
        }

        .jss444 {
            text-align: center;
            background-size: cover;
            background-position: center center;
        }

            .jss444:after {
                top: 0;
                left: 0;
                width: 100%;
                height: 100%;
                content: "";
                display: block;
                z-index: 1;
                position: absolute;
                border-radius: 6px;
                background-color: rgba(0, 0, 0, 0.56);
            }

            .jss444 small {
                color: rgba(255, 255, 255, 0.7) !important;
            }

        .jss445 {
            text-align: center;
        }

            .jss445:after {
                background-color: rgba(0, 0, 0, 0.7) !important;
            }

            .jss445 ul {
                margin: 10px auto;
                padding: 0;
                max-width: 240px;
                list-style: none;
            }

                .jss445 ul li {
                    color: #999;
                    padding: 12px 0px;
                    text-align: center;
                    border-bottom: 1px solid rgba(153, 153, 153,0.3);
                }

                    .jss445 ul li:last-child {
                        border: 0;
                    }

                    .jss445 ul li b {
                        color: #3C4858;
                    }

            .jss445 h1 {
                margin-top: 30px;
            }

                .jss445 h1 small {
                    height: 0;
                    display: inline-flex;
                    font-size: 18px;
                }

                    .jss445 h1 small:first-child {
                        top: -17px;
                        position: relative;
                        font-size: 26px;
                    }

            .jss445 ul li svg, .jss445 ul li .fab, .jss445 ul li .fas, .jss445 ul li .far, .jss445 ul li .fal, .jss445 ul li .material-icons {
                top: 7px;
                position: relative;
            }

        .jss446 ul li {
            color: #FFF;
            border-color: rgba(255, 255, 255,0.3);
        }

            .jss446 ul li b, .jss446 ul li svg, .jss446 ul li .fab, .jss446 ul li .fas, .jss446 ul li .far, .jss446 ul li .fal, .jss446 ul li .material-icons {
                color: #FFF;
                font-weight: 700;
            }

        .jss447 {
            margin-top: 30px;
        }

        .jss448 {
            color: #FFF;
            background: linear-gradient(60deg,#ab47bc,#7b1fa2);
        }

            .jss448 h1 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss449 {
            color: #FFF;
            background: linear-gradient(60deg,#26c6da,#0097a7);
        }

            .jss449 h1 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss450 {
            color: #FFF;
            background: linear-gradient(60deg,#66bb6a,#388e3c);
        }

            .jss450 h1 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss451 {
            color: #FFF;
            background: linear-gradient(60deg,#ffa726,#f57c00);
        }

            .jss451 h1 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss452 {
            color: #FFF;
            background: linear-gradient(60deg,#ef5350,#d32f2f);
        }

            .jss452 h1 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss453 {
            color: #FFF;
            background: linear-gradient(60deg,#ec407a,#c2185b);
        }

            .jss453 h1 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss454 p {
            margin-top: 0px;
            padding-top: 0px;
        }

        .jss455 {
            transform: translate3d(0, 0, 0);
            transition: all 300ms linear;
        }

        .jss456 {
            padding: 0.75rem 1.25rem;
            z-index: 3 !important;
            background: transparent;
            border-bottom: none;
            margin-bottom: 0;
        }

            .jss456.jss457, .jss456.jss458, .jss456.jss459, .jss456.jss460, .jss456.jss462, .jss456.jss461, .jss456.jss464, .jss456.jss465, .jss456.jss466, .jss456.jss467, .jss456.jss468, .jss456.jss469, .jss456.jss470 {
                color: #FFF;
                margin: 0 15px;
                padding: 0;
                position: relative;
            }

            .jss456:first-child {
                border-radius: calc(.25rem - 1px) calc(.25rem - 1px) 0 0;
            }

            .jss456.jss461 svg {
                width: 36px;
                height: 36px;
                margin: 10px 10px 4px;
                font-size: 36px;
                text-align: center;
                line-height: 56px;
            }

            .jss456.jss461 .fab, .jss456.jss461 .fas, .jss456.jss461 .far, .jss456.jss461 .fal, .jss456.jss461 .material-icons {
                width: 56px;
                height: 56px;
                overflow: unset;
                font-size: 36px;
                text-align: center;
                line-height: 56px;
                margin-bottom: 1px;
            }

            .jss456.jss461.jss462 {
                text-align: right;
            }

            .jss456.jss458 {
                margin-top: -30px;
                margin-left: 15px;
                margin-right: 15px;
                border-radius: 6px;
            }

            .jss456.jss463 {
                display: inline-block;
            }

            .jss456.jss464:not(.jss462):not(.jss458):not(.jss463), .jss456.jss465:not(.jss462):not(.jss458):not(.jss463), .jss456.jss466:not(.jss462):not(.jss458):not(.jss463), .jss456.jss467:not(.jss462):not(.jss458):not(.jss463), .jss456.jss468:not(.jss462):not(.jss458):not(.jss463), .jss456.jss469:not(.jss462):not(.jss458):not(.jss463), .jss456.jss470:not(.jss462):not(.jss458):not(.jss463) {
                padding: 15px;
                margin-top: -20px;
                border-radius: 3px;
            }

        .jss457 {
            margin-left: 0px;
            margin-right: 0px;
        }

            .jss457.jss458 {
                margin: 0 !important;
            }

        .jss458 {
            padding: 0;
            z-index: 1;
            position: relative;
        }

            .jss458 img {
                width: 100%;
                box-shadow: 0 5px 15px -8px rgba(0, 0, 0, 0.24), 0 8px 10px -5px rgba(0, 0, 0, 0.2);
                border-radius: 6px;
                pointer-events: none;
            }

            .jss458 a {
                display: block;
            }

        .jss459 {
            margin: 0 15px;
            margin-top: -20px;
        }

        .jss460 {
            width: 100%;
            padding: 20px 0;
            margin-top: -40px;
            margin-left: 20px;
            margin-right: 20px;
            margin-bottom: 15px;
        }

        .jss461 .jss462 {
            text-align: right;
        }

        .jss461 h1, .jss461 h2, .jss461 h3, .jss461 h4, .jss461 h5, .jss461 h6 {
            margin: 0 !important;
        }

        .jss462.jss464, .jss462.jss465, .jss462.jss466, .jss462.jss467, .jss462.jss468, .jss462.jss469, .jss462.jss470 {
            background: transparent;
            box-shadow: none;
        }

        .jss462 .fab, .jss462 .fas, .jss462 .far, .jss462 .fal, .jss462 .material-icons {
            width: 33px;
            height: 33px;
            text-align: center;
            line-height: 33px;
        }

        .jss462 svg {
            width: 24px;
            height: 24px;
            margin: 5px 4px 0px;
            text-align: center;
            line-height: 33px;
        }

        .jss464 {
            color: #FFF;
        }

            .jss464:not(.jss463):not(.jss462) {
                background: linear-gradient(60deg, #ffa726, #fb8c00);
                box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(255, 152, 0,.4);
            }

        .jss465 {
            color: #FFF;
        }

            .jss465:not(.jss463):not(.jss462) {
                background: linear-gradient(60deg, #66bb6a, #43a047);
                box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(76, 175, 80,.4);
            }

        .jss466 {
            color: #FFF;
        }

            .jss466:not(.jss463):not(.jss462) {
                background: linear-gradient(60deg, #ef5350, #e53935);
                box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(244, 67, 54,.4);
            }

        .jss467 {
            color: #FFF;
        }

            .jss467:not(.jss463):not(.jss462) {
                background: linear-gradient(60deg, #26c6da, #00acc1);
                box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(0, 172, 193,.4);
            }

        .jss468 {
            color: #FFF;
        }

            .jss468:not(.jss463):not(.jss462) {
                background: linear-gradient(60deg, #ab47bc, #8e24aa);
                box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(156, 39, 176,.4);
            }

        .jss469 {
            color: #FFF;
        }

            .jss469:not(.jss463):not(.jss462) {
                background: linear-gradient(60deg, #ec407a, #d81b60);
                box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(233, 30, 99,.4);
            }

        .jss470 {
            color: #FFF;
        }

            .jss470:not(.jss463):not(.jss462) {
                background: linear-gradient(60deg, #263238, #212121);
                box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(33, 33, 33,.4);
            }

        .jss475 {
            flex: 1 1 auto;
            padding: 0.9375rem 20px;
            position: relative;
            -webkit-box-flex: 1;
        }

        .jss476 {
            margin: 0 auto;
            z-index: 2;
            position: relative;
            max-width: 440px;
            min-height: 280px;
            padding-top: 40px;
            padding-bottom: 40px;
        }

        .jss477 {
            padding-left: 5px;
            padding-right: 5px;
        }

        .jss478 {
            padding-left: 15px;
            padding-right: 15px;
        }

            .jss478 form {
                margin: 0;
            }

        .jss479 {
            margin: 0px !important;
            padding: 15px !important;
        }

        .jss480 {
            padding: 0px 30px 0px 30px;
        }

        .jss481 {
            border-radius: 6px;
        }

            .jss481 h1 small, .jss481 h2 small, .jss481 h3 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss482 {
            margin-top: 15px;
        }

        .jss483 {
            padding: 0px !important;
        }

        .jss484 {
            padding: 14px;
        }

            .jss484:hover {
                background-color: unset;
            }

        .jss485 {
            padding: 16px;
        }

            .jss485:hover {
                background-color: unset;
            }

        .jss486 {
            margin-left: -14px;
        }

        .jss487 {
            display: block;
            position: relative;
            margin-top: 10px;
            margin-bottom: 10px;
        }

        .jss488 {
            display: block;
            position: relative;
            margin-top: 0;
            margin-bottom: 0;
        }

            .jss488:first-child {
                margin-top: 10px;
            }

            .jss488:not(:first-child) {
                margin-top: -14px;
            }

        .jss489 {
            color: #9c27b0 !important;
        }

        .jss490 {
            width: 20px;
            border: 1px solid rgba(0, 0, 0, .54);
            height: 20px;
            border-radius: 3px;
        }

        .jss491 {
            width: 0px;
            border: 1px solid rgba(0, 0, 0, .54);
            height: 0px;
            padding: 9px;
            border-radius: 3px;
        }

        .jss492 .jss490, .jss492 .jss491, .jss492 .jss499, .jss492 .jss500 {
            color: #000;
            opacity: 0.26;
            border-color: #000;
        }

        .jss493 {
            color: #AAAAAA;
            cursor: pointer;
            display: inline-flex;
            font-size: 14px;
            transition: 0.3s ease all;
            font-weight: 400;
            line-height: 1.428571429;
            padding-left: 0;
            letter-spacing: unset;
        }

        .jss494 {
            color: rgba(0, 0, 0, 0.26);
            cursor: pointer;
            display: inline-flex;
            font-size: 14px;
            font-weight: 400;
            line-height: 1.428571429;
            padding-top: 39px;
            margin-right: 0;
        }

        @media (min-width: 992px) {
            .jss494 {
                float: right;
            }
        }

        .jss495 {
            padding-top: 22px;
        }

        .jss496 {
            color: rgba(0, 0, 0, 0.26);
            cursor: pointer;
            display: inline-flex;
            font-size: 14px;
            font-weight: 400;
            line-height: 1.428571429;
            padding-top: 22px;
            margin-right: 0;
        }

        .jss497 {
            color: #f44336;
        }

        .jss498 {
            color: #9c27b0 !important;
        }

        .jss499 {
            width: 16px;
            border: 1px solid #9c27b0;
            height: 16px;
            border-radius: 50%;
        }

        .jss500 {
            width: 0px;
            border: 1px solid rgba(0, 0, 0, .54);
            height: 0px;
            padding: 7px;
            border-radius: 50%;
        }

        .jss501 {
            margin-top: 8px;
        }

        .jss502 {
            color: #999;
            width: 116px;
            height: 116px;
            margin: 0 auto 20px;
            padding: 0;
        }

            .jss502 > span:first-child {
                color: inherit;
                text-align: center;
                transition: all 0.2s;
                border-color: #ccc;
                border-style: solid;
                border-width: 4px;
                border-radius: 50%;
                vertical-align: middle;
            }

            .jss502:hover {
                color: #e91e63;
            }

                .jss502:hover > span:first-child {
                    border-color: #e91e63;
                }

        .jss503 {
            color: #e91e63;
        }

            .jss503 > span:first-child {
                border-color: #e91e63;
            }

        .jss504 {
            font-size: 40px;
            line-height: 111px;
        }

        .jss505 {
            color: #9c27b0 !important;
        }

        .jss506 {
            color: #FFF !important;
            border: 1px solid rgba(0, 0, 0, .54);
            box-shadow: 0 1px 3px 1px rgba(0, 0, 0, 0.4);
        }

        .jss507 {
            transform: translateX(0px) !important;
            border-color: #9c27b0;
        }

        .jss508 {
            width: 30px;
            height: 15px;
            opacity: 0.7 !important;
            border-radius: 15px;
            background-color: rgb(80, 80, 80);
        }

        .jss509 + .jss508 {
            background-color: rgba(156, 39, 176, 1) !important;
        }

        .jss509 .jss506 {
            border-color: #9c27b0;
        }

        .jss510 {
            margin-bottom: 0;
        }

        .jss511 {
            position: relative;
            border-bottom: 1px solid #DDD;
        }

        .jss512 {
            border: none;
            padding: 12px 8px !important;
            vertical-align: middle;
        }

        .jss513 {
            border: none;
            padding: 0;
            font-size: 14px;
            font-family: "Roboto", "Helvetica", "Arial", sans-serif;
            font-weight: 300;
            line-height: 1.42857143;
            vertical-align: middle;
        }

        .jss514 {
            width: 27px;
            height: 27px;
            padding: 0;
        }

        .jss515 {
            width: 17px;
            height: 17px;
        }

        .jss516 {
            color: #9c27b0;
            box-shadow: none;
            background-color: transparent;
        }

        .jss517 {
            color: #f44336;
            box-shadow: none;
            background-color: transparent;
        }

        .jss518 {
            color: #FFF;
            border: none;
            opacity: 1 !important;
            padding: 10px 15px;
            font-size: 12px;
            max-width: 200px;
            min-width: 130px;
            word-wrap: normal;
            background: rgba(85, 85, 85,0.9);
            box-shadow: 0 8px 10px 1px rgba(0, 0, 0, 0.14), 0 3px 14px 2px rgba(0, 0, 0, 0.12), 0 5px 5px -3px rgba(0, 0, 0, 0.2);
            font-style: normal;
            line-break: auto;
            text-align: center;
            word-break: normal;
            font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
            font-weight: 400;
            line-height: 1.7em;
            text-shadow: none;
            white-space: normal;
            word-spacing: normal;
            border-radius: 3px;
            letter-spacing: normal;
            text-transform: none;
        }

        .jss523 {
            width: calc(100% + 30px);
            margin: 0 -15px;
        }

        .jss524 {
            padding: 0 15px !important;
        }

        .jss525 {
            width: calc(100% + 30px);
            margin: 0 -15px;
        }

        .jss526 {
            padding: 0 15px !important;
        }

        .jss527 {
            color: rgba(0, 0, 0, 0.87);
            width: 100%;
            border: 0;
            display: flex;
            position: relative;
            font-size: .875rem;
            min-width: 0;
            word-wrap: break-word;
            background: #FFF;
            box-shadow: 0 1px 4px 0 rgba(0, 0, 0, 0.14);
            margin-top: 30px;
            border-radius: 6px;
            margin-bottom: 30px;
            flex-direction: column;
        }

        .jss528 {
            background: transparent;
            box-shadow: none;
        }

        .jss529 {
            margin-top: 30px;
            text-align: center;
        }

        .jss530 {
            margin-top: 60px;
        }

        .jss531 {
            box-shadow: 0 16px 38px -12px rgba(0, 0, 0, 0.56), 0 4px 25px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 0, 0, 0.2);
        }

        .jss532 {
            text-align: center;
            background-size: cover;
            background-position: center center;
        }

            .jss532:after {
                top: 0;
                left: 0;
                width: 100%;
                height: 100%;
                content: "";
                display: block;
                z-index: 1;
                position: absolute;
                border-radius: 6px;
                background-color: rgba(0, 0, 0, 0.56);
            }

            .jss532 small {
                color: rgba(255, 255, 255, 0.7) !important;
            }

        .jss533 {
            text-align: center;
        }

            .jss533:after {
                background-color: rgba(0, 0, 0, 0.7) !important;
            }

            .jss533 ul {
                margin: 10px auto;
                padding: 0;
                max-width: 240px;
                list-style: none;
            }

                .jss533 ul li {
                    color: #999;
                    padding: 12px 0px;
                    text-align: center;
                    border-bottom: 1px solid rgba(153, 153, 153,0.3);
                }

                    .jss533 ul li:last-child {
                        border: 0;
                    }

                    .jss533 ul li b {
                        color: #3C4858;
                    }

            .jss533 h1 {
                margin-top: 30px;
            }

                .jss533 h1 small {
                    height: 0;
                    display: inline-flex;
                    font-size: 18px;
                }

                    .jss533 h1 small:first-child {
                        top: -17px;
                        position: relative;
                        font-size: 26px;
                    }

            .jss533 ul li svg, .jss533 ul li .fab, .jss533 ul li .fas, .jss533 ul li .far, .jss533 ul li .fal, .jss533 ul li .material-icons {
                top: 7px;
                position: relative;
            }

        .jss534 ul li {
            color: #FFF;
            border-color: rgba(255, 255, 255,0.3);
        }

            .jss534 ul li b, .jss534 ul li svg, .jss534 ul li .fab, .jss534 ul li .fas, .jss534 ul li .far, .jss534 ul li .fal, .jss534 ul li .material-icons {
                color: #FFF;
                font-weight: 700;
            }

        .jss535 {
            margin-top: 30px;
        }

        .jss536 {
            color: #FFF;
            background: linear-gradient(60deg,#ab47bc,#7b1fa2);
        }

            .jss536 h1 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss537 {
            color: #FFF;
            background: linear-gradient(60deg,#26c6da,#0097a7);
        }

            .jss537 h1 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss538 {
            color: #FFF;
            background: linear-gradient(60deg,#66bb6a,#388e3c);
        }

            .jss538 h1 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss539 {
            color: #FFF;
            background: linear-gradient(60deg,#ffa726,#f57c00);
        }

            .jss539 h1 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss540 {
            color: #FFF;
            background: linear-gradient(60deg,#ef5350,#d32f2f);
        }

            .jss540 h1 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss541 {
            color: #FFF;
            background: linear-gradient(60deg,#ec407a,#c2185b);
        }

            .jss541 h1 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss542 p {
            margin-top: 0px;
            padding-top: 0px;
        }

        .jss543 {
            transform: translate3d(0, 0, 0);
            transition: all 300ms linear;
        }

        .jss544 {
            flex: 1 1 auto;
            padding: 0.9375rem 20px;
            position: relative;
            -webkit-box-flex: 1;
        }

        .jss545 {
            margin: 0 auto;
            z-index: 2;
            position: relative;
            max-width: 440px;
            min-height: 280px;
            padding-top: 40px;
            padding-bottom: 40px;
        }

        .jss546 {
            padding-left: 5px;
            padding-right: 5px;
        }

        .jss547 {
            padding-left: 15px;
            padding-right: 15px;
        }

            .jss547 form {
                margin: 0;
            }

        .jss548 {
            margin: 0px !important;
            padding: 15px !important;
        }

        .jss549 {
            padding: 0px 30px 0px 30px;
        }

        .jss550 {
            border-radius: 6px;
        }

            .jss550 h1 small, .jss550 h2 small, .jss550 h3 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss551 {
            margin-top: 15px;
        }

        .jss552 {
            padding: 0px !important;
        }

        .jss553 {
            color: #FFF;
            border: none;
            cursor: pointer;
            margin: .3125rem 1px;
            padding: 12px 30px;
            position: relative;
            font-size: 12px;
            min-width: auto;
            box-shadow: 0 2px 2px 0 rgba(153, 153, 153, 0.14), 0 3px 1px -2px rgba(153, 153, 153, 0.2), 0 1px 5px 0 rgba(153, 153, 153, 0.12);
            min-height: auto;
            text-align: center;
            transition: box-shadow 0.2s cubic-bezier(0.4, 0, 1, 1), background-color 0.2s cubic-bezier(0.4, 0, 0.2, 1);
            font-weight: 400;
            line-height: 1.42857143;
            white-space: nowrap;
            will-change: box-shadow, transform;
            touch-action: manipulation;
            border-radius: 3px;
            letter-spacing: 0;
            text-transform: uppercase;
            vertical-align: middle;
            background-color: #999;
        }

            .jss553:hover, .jss553:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(153, 153, 153, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(153, 153, 153, 0.2);
                background-color: #999;
            }

            .jss553 .fab, .jss553 .fas, .jss553 .far, .jss553 .fal, .jss553 .material-icons {
                top: 0;
                display: inline-block;
                position: relative;
                font-size: 1.1rem;
                margin-top: -1em;
                margin-right: 4px;
                margin-bottom: -1em;
                vertical-align: middle;
            }

            .jss553 svg {
                top: 0;
                width: 18px;
                height: 18px;
                display: inline-block;
                position: relative;
                margin-right: 4px;
                vertical-align: middle;
            }

            .jss553.jss581 .fab, .jss553.jss581 .fas, .jss553.jss581 .far, .jss553.jss581 .fal, .jss553.jss581 .material-icons {
                top: 0px;
                left: 0px;
                width: 100%;
                height: 100%;
                position: absolute;
                font-size: 20px;
                transform: none;
                margin-top: 0px;
                line-height: 41px;
            }

        .jss554 {
            width: 100%;
        }

        .jss555 {
            box-shadow: 0 2px 2px 0 rgba(156, 39, 176, 0.14), 0 3px 1px -2px rgba(156, 39, 176, 0.2), 0 1px 5px 0 rgba(156, 39, 176, 0.12);
            background-color: #9c27b0;
        }

            .jss555:hover, .jss555:focus {
                box-shadow: 0 14px 26px -12px rgba(156, 39, 176, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(156, 39, 176, 0.2);
                background-color: #9c27b0;
            }

        .jss556 {
            box-shadow: 0 2px 2px 0 rgba(0, 172, 193, 0.14), 0 3px 1px -2px rgba(0, 172, 193, 0.2), 0 1px 5px 0 rgba(0, 172, 193, 0.12);
            background-color: #00acc1;
        }

            .jss556:hover, .jss556:focus {
                box-shadow: 0 14px 26px -12px rgba(0, 172, 193, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 172, 193, 0.2);
                background-color: #00acc1;
            }

        .jss557 {
            box-shadow: 0 2px 2px 0 rgba(76, 175, 80, 0.14), 0 3px 1px -2px rgba(76, 175, 80, 0.2), 0 1px 5px 0 rgba(76, 175, 80, 0.12);
            background-color: #4caf50;
        }

            .jss557:hover, .jss557:focus {
                box-shadow: 0 14px 26px -12px rgba(76, 175, 80, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(76, 175, 80, 0.2);
                background-color: #4caf50;
            }

        .jss558 {
            box-shadow: 0 2px 2px 0 rgba(255, 152, 0, 0.14), 0 3px 1px -2px rgba(255, 152, 0, 0.2), 0 1px 5px 0 rgba(255, 152, 0, 0.12);
            background-color: #ff9800;
        }

            .jss558:hover, .jss558:focus {
                box-shadow: 0 14px 26px -12px rgba(255, 152, 0, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(255, 152, 0, 0.2);
                background-color: #ff9800;
            }

        .jss559 {
            box-shadow: 0 2px 2px 0 rgba(244, 67, 54, 0.14), 0 3px 1px -2px rgba(244, 67, 54, 0.2), 0 1px 5px 0 rgba(244, 67, 54, 0.12);
            background-color: #f44336;
        }

            .jss559:hover, .jss559:focus {
                box-shadow: 0 14px 26px -12px rgba(244, 67, 54, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(244, 67, 54, 0.2);
                background-color: #f44336;
            }

        .jss560 {
            box-shadow: 0 2px 2px 0 rgba(233, 30, 99, 0.14), 0 3px 1px -2px rgba(233, 30, 99, 0.2), 0 1px 5px 0 rgba(233, 30, 99, 0.12);
            background-color: #e91e63;
        }

            .jss560:hover, .jss560:focus {
                box-shadow: 0 14px 26px -12px rgba(233, 30, 99, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(233, 30, 99, 0.2);
                background-color: #e91e63;
            }

        .jss561, .jss561:focus, .jss561:hover {
            color: #999;
            background-color: #FFF;
        }

        .jss562 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(85, 172, 238, 0.14), 0 3px 1px -2px rgba(85, 172, 238, 0.2), 0 1px 5px 0 rgba(85, 172, 238, 0.12);
            background-color: #55acee;
        }

            .jss562:hover, .jss562:focus, .jss562:visited {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(85, 172, 238, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(85, 172, 238, 0.2);
                background-color: #55acee;
            }

        .jss563 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(59, 89, 152, 0.14), 0 3px 1px -2px rgba(59, 89, 152, 0.2), 0 1px 5px 0 rgba(59, 89, 152, 0.12);
            background-color: #3b5998;
        }

            .jss563:hover, .jss563:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(59, 89, 152, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(59, 89, 152, 0.2);
                background-color: #3b5998;
            }

        .jss564 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(221, 75, 57, 0.14), 0 3px 1px -2px rgba(221, 75, 57, 0.2), 0 1px 5px 0 rgba(221, 75, 57, 0.12);
            background-color: #dd4b39;
        }

            .jss564:hover, .jss564:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(221, 75, 57, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(221, 75, 57, 0.2);
                background-color: #dd4b39;
            }

        .jss565 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(9, 118, 180, 0.14), 0 3px 1px -2px rgba(9, 118, 180, 0.2), 0 1px 5px 0 rgba(9, 118, 180, 0.12);
            background-color: #0976b4;
        }

            .jss565:hover, .jss565:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(9, 118, 180, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(9, 118, 180, 0.2);
                background-color: #0976b4;
            }

        .jss566 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(204, 33, 39, 0.14), 0 3px 1px -2px rgba(204, 33, 39, 0.2), 0 1px 5px 0 rgba(204, 33, 39, 0.12);
            background-color: #cc2127;
        }

            .jss566:hover, .jss566:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(204, 33, 39, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(204, 33, 39, 0.2);
                background-color: #cc2127;
            }

        .jss567 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(229, 45, 39, 0.14), 0 3px 1px -2px rgba(229, 45, 39, 0.2), 0 1px 5px 0 rgba(229, 45, 39, 0.12);
            background-color: #e52d27;
        }

            .jss567:hover, .jss567:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(229, 45, 39, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(229, 45, 39, 0.2);
                background-color: #e52d27;
            }

        .jss568 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(53, 70, 92, 0.14), 0 3px 1px -2px rgba(53, 70, 92, 0.2), 0 1px 5px 0 rgba(53, 70, 92, 0.12);
            background-color: #35465c;
        }

            .jss568:hover, .jss568:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(53, 70, 92, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(53, 70, 92, 0.2);
                background-color: #35465c;
            }

        .jss569 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(85, 85, 85, 0.14), 0 3px 1px -2px rgba(85, 85, 85, 0.2), 0 1px 5px 0 rgba(85, 85, 85, 0.12);
            background-color: #333;
        }

            .jss569:hover, .jss569:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(85, 85, 85, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(85, 85, 85, 0.2);
                background-color: #333;
            }

        .jss570 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(23, 105, 255, 0.14), 0 3px 1px -2px rgba(23, 105, 255, 0.2), 0 1px 5px 0 rgba(23, 105, 255, 0.12);
            background-color: #1769ff;
        }

            .jss570:hover, .jss570:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(23, 105, 255, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(23, 105, 255, 0.2);
                background-color: #1769ff;
            }

        .jss571 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(234, 76, 137, 0.14), 0 3px 1px -2px rgba(234, 76, 137, 0.2), 0 1px 5px 0 rgba(234, 76, 137, 0.12);
            background-color: #ea4c89;
        }

            .jss571:hover, .jss571:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(234, 76, 137, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(234, 76, 137, 0.2);
                background-color: #ea4c89;
            }

        .jss572 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(255, 69, 0, 0.14), 0 3px 1px -2px rgba(255, 69, 0, 0.2), 0 1px 5px 0 rgba(255, 69, 0, 0.12);
            background-color: #ff4500;
        }

            .jss572:hover, .jss572:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(255, 69, 0, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(255, 69, 0, 0.2);
                background-color: #ff4500;
            }

        .jss573, .jss573:focus, .jss573:hover {
            color: #FFF;
            background: transparent;
            box-shadow: none;
        }

            .jss573.jss572, .jss573.jss572:focus, .jss573.jss572:hover, .jss573.jss572:visited {
                color: #ff4500;
            }

            .jss573.jss571, .jss573.jss571:focus, .jss573.jss571:hover, .jss573.jss571:visited {
                color: #ea4c89;
            }

            .jss573.jss570, .jss573.jss570:focus, .jss573.jss570:hover, .jss573.jss570:visited {
                color: #1769ff;
            }

            .jss573.jss569, .jss573.jss569:focus, .jss573.jss569:hover, .jss573.jss569:visited {
                color: #333;
            }

            .jss573.jss568, .jss573.jss568:focus, .jss573.jss568:hover, .jss573.jss568:visited {
                color: #35465c;
            }

            .jss573.jss567, .jss573.jss567:focus, .jss573.jss567:hover, .jss573.jss567:visited {
                color: #e52d27;
            }

            .jss573.jss566, .jss573.jss566:focus, .jss573.jss566:hover, .jss573.jss566:visited {
                color: #cc2127;
            }

            .jss573.jss565, .jss573.jss565:focus, .jss573.jss565:hover, .jss573.jss565:visited {
                color: #0976b4;
            }

            .jss573.jss564, .jss573.jss564:focus, .jss573.jss564:hover, .jss573.jss564:visited {
                color: #dd4b39;
            }

            .jss573.jss563, .jss573.jss563:focus, .jss573.jss563:hover, .jss573.jss563:visited {
                color: #3b5998;
            }

            .jss573.jss562, .jss573.jss562:focus, .jss573.jss562:hover, .jss573.jss562:visited {
                color: #55acee;
            }

            .jss573.jss559, .jss573.jss559:focus, .jss573.jss559:hover, .jss573.jss559:visited {
                color: #f44336;
            }

            .jss573.jss560, .jss573.jss560:focus, .jss573.jss560:hover, .jss573.jss560:visited {
                color: #e91e63;
            }

            .jss573.jss558, .jss573.jss558:focus, .jss573.jss558:hover, .jss573.jss558:visited {
                color: #ff9800;
            }

            .jss573.jss557, .jss573.jss557:focus, .jss573.jss557:hover, .jss573.jss557:visited {
                color: #4caf50;
            }

            .jss573.jss556, .jss573.jss556:focus, .jss573.jss556:hover, .jss573.jss556:visited {
                color: #00acc1;
            }

            .jss573.jss555, .jss573.jss555:focus, .jss573.jss555:hover, .jss573.jss555:visited {
                color: #9c27b0;
            }

        .jss574, .jss574:focus, .jss574:hover {
            color: inherit;
            background: transparent;
            box-shadow: none;
        }

        .jss575 {
            opacity: 0.65;
            pointer-events: none;
        }

        .jss576 {
            padding: 1.125rem 2.25rem;
            font-size: 0.875rem;
            line-height: 1.333333;
            border-radius: 0.2rem;
        }

            .jss576.jss581 .fab, .jss576.jss581 .fas, .jss576.jss581 .far, .jss576.jss581 .fal, .jss576.jss581 svg, .jss576.jss581 .material-icons {
                margin-top: -4px;
            }

        .jss577 {
            padding: 0.40625rem 1.25rem;
            font-size: 0.6875rem;
            line-height: 1.5;
            border-radius: 0.2rem;
        }

            .jss577.jss581 .fab, .jss577.jss581 .fas, .jss577.jss581 .far, .jss577.jss581 .fal, .jss577.jss581 svg, .jss577.jss581 .material-icons {
                margin-top: 1px;
            }

        .jss578 {
            border-radius: 30px;
        }

        .jss579 {
            width: 100% !important;
        }

        .jss580, .jss580:hover, .jss580:focus {
            color: #999;
            box-shadow: none;
            background-color: transparent;
        }

        .jss581 {
            width: 41px;
            height: 41px;
            font-size: 20px;
            min-width: 41px;
            padding-left: 12px;
            padding-right: 12px;
        }

            .jss581 .fab, .jss581 .fas, .jss581 .far, .jss581 .fal, .jss581 svg, .jss581 .material-icons {
                margin-right: 0px;
            }

            .jss581.jss576 {
                width: 57px;
                height: 57px;
                min-width: 57px;
                line-height: 56px;
            }

            .jss581.jss577 {
                width: 30px;
                height: 30px;
                min-width: 30px;
            }

                .jss581.jss577 .fab, .jss581.jss577 .fas, .jss581.jss577 .far, .jss581.jss577 .fal, .jss581.jss577 .material-icons {
                    font-size: 17px;
                    line-height: 29px;
                }

                .jss581.jss577 svg {
                    width: 17px;
                    height: 17px;
                }

            .jss581.jss576 .fab, .jss581.jss576 .fas, .jss581.jss576 .far, .jss581.jss576 .fal, .jss581.jss576 .material-icons {
                font-size: 32px;
                line-height: 56px;
            }

            .jss581.jss576 svg {
                width: 32px;
                height: 32px;
            }

        .jss582 {
            padding: 0 15px !important;
        }

        .jss583 {
            color: rgba(0, 0, 0, 0.87);
            width: 100%;
            border: 0;
            display: flex;
            position: relative;
            font-size: .875rem;
            min-width: 0;
            word-wrap: break-word;
            background: #FFF;
            box-shadow: 0 1px 4px 0 rgba(0, 0, 0, 0.14);
            margin-top: 30px;
            border-radius: 6px;
            margin-bottom: 30px;
            flex-direction: column;
        }

        .jss584 {
            background: transparent;
            box-shadow: none;
        }

        .jss585 {
            margin-top: 30px;
            text-align: center;
        }

        .jss586 {
            margin-top: 60px;
        }

        .jss587 {
            box-shadow: 0 16px 38px -12px rgba(0, 0, 0, 0.56), 0 4px 25px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 0, 0, 0.2);
        }

        .jss588 {
            text-align: center;
            background-size: cover;
            background-position: center center;
        }

            .jss588:after {
                top: 0;
                left: 0;
                width: 100%;
                height: 100%;
                content: "";
                display: block;
                z-index: 1;
                position: absolute;
                border-radius: 6px;
                background-color: rgba(0, 0, 0, 0.56);
            }

            .jss588 small {
                color: rgba(255, 255, 255, 0.7) !important;
            }

        .jss589 {
            text-align: center;
        }

            .jss589:after {
                background-color: rgba(0, 0, 0, 0.7) !important;
            }

            .jss589 ul {
                margin: 10px auto;
                padding: 0;
                max-width: 240px;
                list-style: none;
            }

                .jss589 ul li {
                    color: #999;
                    padding: 12px 0px;
                    text-align: center;
                    border-bottom: 1px solid rgba(153, 153, 153,0.3);
                }

                    .jss589 ul li:last-child {
                        border: 0;
                    }

                    .jss589 ul li b {
                        color: #3C4858;
                    }

            .jss589 h1 {
                margin-top: 30px;
            }

                .jss589 h1 small {
                    height: 0;
                    display: inline-flex;
                    font-size: 18px;
                }

                    .jss589 h1 small:first-child {
                        top: -17px;
                        position: relative;
                        font-size: 26px;
                    }

            .jss589 ul li svg, .jss589 ul li .fab, .jss589 ul li .fas, .jss589 ul li .far, .jss589 ul li .fal, .jss589 ul li .material-icons {
                top: 7px;
                position: relative;
            }

        .jss590 ul li {
            color: #FFF;
            border-color: rgba(255, 255, 255,0.3);
        }

            .jss590 ul li b, .jss590 ul li svg, .jss590 ul li .fab, .jss590 ul li .fas, .jss590 ul li .far, .jss590 ul li .fal, .jss590 ul li .material-icons {
                color: #FFF;
                font-weight: 700;
            }

        .jss591 {
            margin-top: 30px;
        }

        .jss592 {
            color: #FFF;
            background: linear-gradient(60deg,#ab47bc,#7b1fa2);
        }

            .jss592 h1 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss593 {
            color: #FFF;
            background: linear-gradient(60deg,#26c6da,#0097a7);
        }

            .jss593 h1 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss594 {
            color: #FFF;
            background: linear-gradient(60deg,#66bb6a,#388e3c);
        }

            .jss594 h1 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss595 {
            color: #FFF;
            background: linear-gradient(60deg,#ffa726,#f57c00);
        }

            .jss595 h1 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss596 {
            color: #FFF;
            background: linear-gradient(60deg,#ef5350,#d32f2f);
        }

            .jss596 h1 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss597 {
            color: #FFF;
            background: linear-gradient(60deg,#ec407a,#c2185b);
        }

            .jss597 h1 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss598 p {
            margin-top: 0px;
            padding-top: 0px;
        }

        .jss599 {
            transform: translate3d(0, 0, 0);
            transition: all 300ms linear;
        }

        .jss600 {
            flex: 1 1 auto;
            padding: 0.9375rem 20px;
            position: relative;
            -webkit-box-flex: 1;
        }

        .jss601 {
            margin: 0 auto;
            z-index: 2;
            position: relative;
            max-width: 440px;
            min-height: 280px;
            padding-top: 40px;
            padding-bottom: 40px;
        }

        .jss602 {
            padding-left: 5px;
            padding-right: 5px;
        }

        .jss603 {
            padding-left: 15px;
            padding-right: 15px;
        }

            .jss603 form {
                margin: 0;
            }

        .jss604 {
            margin: 0px !important;
            padding: 15px !important;
        }

        .jss605 {
            padding: 0px 30px 0px 30px;
        }

        .jss606 {
            border-radius: 6px;
        }

            .jss606 h1 small, .jss606 h2 small, .jss606 h3 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss607 {
            margin-top: 15px;
        }

        .jss608 {
            padding: 0px !important;
        }

        .jss609 {
            color: #FFF;
            border: none;
            cursor: pointer;
            margin: .3125rem 1px;
            padding: 12px 30px;
            position: relative;
            font-size: 12px;
            min-width: auto;
            box-shadow: 0 2px 2px 0 rgba(153, 153, 153, 0.14), 0 3px 1px -2px rgba(153, 153, 153, 0.2), 0 1px 5px 0 rgba(153, 153, 153, 0.12);
            min-height: auto;
            text-align: center;
            transition: box-shadow 0.2s cubic-bezier(0.4, 0, 1, 1), background-color 0.2s cubic-bezier(0.4, 0, 0.2, 1);
            font-weight: 400;
            line-height: 1.42857143;
            white-space: nowrap;
            will-change: box-shadow, transform;
            touch-action: manipulation;
            border-radius: 3px;
            letter-spacing: 0;
            text-transform: uppercase;
            vertical-align: middle;
            background-color: #999;
        }

            .jss609:hover, .jss609:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(153, 153, 153, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(153, 153, 153, 0.2);
                background-color: #999;
            }

            .jss609 .fab, .jss609 .fas, .jss609 .far, .jss609 .fal, .jss609 .material-icons {
                top: 0;
                display: inline-block;
                position: relative;
                font-size: 1.1rem;
                margin-top: -1em;
                margin-right: 4px;
                margin-bottom: -1em;
                vertical-align: middle;
            }

            .jss609 svg {
                top: 0;
                width: 18px;
                height: 18px;
                display: inline-block;
                position: relative;
                margin-right: 4px;
                vertical-align: middle;
            }

            .jss609.jss637 .fab, .jss609.jss637 .fas, .jss609.jss637 .far, .jss609.jss637 .fal, .jss609.jss637 .material-icons {
                top: 0px;
                left: 0px;
                width: 100%;
                height: 100%;
                position: absolute;
                font-size: 20px;
                transform: none;
                margin-top: 0px;
                line-height: 41px;
            }

        .jss610 {
            width: 100%;
        }

        .jss611 {
            box-shadow: 0 2px 2px 0 rgba(156, 39, 176, 0.14), 0 3px 1px -2px rgba(156, 39, 176, 0.2), 0 1px 5px 0 rgba(156, 39, 176, 0.12);
            background-color: #9c27b0;
        }

            .jss611:hover, .jss611:focus {
                box-shadow: 0 14px 26px -12px rgba(156, 39, 176, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(156, 39, 176, 0.2);
                background-color: #9c27b0;
            }

        .jss612 {
            box-shadow: 0 2px 2px 0 rgba(0, 172, 193, 0.14), 0 3px 1px -2px rgba(0, 172, 193, 0.2), 0 1px 5px 0 rgba(0, 172, 193, 0.12);
            background-color: #00acc1;
        }

            .jss612:hover, .jss612:focus {
                box-shadow: 0 14px 26px -12px rgba(0, 172, 193, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 172, 193, 0.2);
                background-color: #00acc1;
            }

        .jss613 {
            box-shadow: 0 2px 2px 0 rgba(76, 175, 80, 0.14), 0 3px 1px -2px rgba(76, 175, 80, 0.2), 0 1px 5px 0 rgba(76, 175, 80, 0.12);
            background-color: #4caf50;
        }

            .jss613:hover, .jss613:focus {
                box-shadow: 0 14px 26px -12px rgba(76, 175, 80, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(76, 175, 80, 0.2);
                background-color: #4caf50;
            }

        .jss614 {
            box-shadow: 0 2px 2px 0 rgba(255, 152, 0, 0.14), 0 3px 1px -2px rgba(255, 152, 0, 0.2), 0 1px 5px 0 rgba(255, 152, 0, 0.12);
            background-color: #ff9800;
        }

            .jss614:hover, .jss614:focus {
                box-shadow: 0 14px 26px -12px rgba(255, 152, 0, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(255, 152, 0, 0.2);
                background-color: #ff9800;
            }

        .jss615 {
            box-shadow: 0 2px 2px 0 rgba(244, 67, 54, 0.14), 0 3px 1px -2px rgba(244, 67, 54, 0.2), 0 1px 5px 0 rgba(244, 67, 54, 0.12);
            background-color: #f44336;
        }

            .jss615:hover, .jss615:focus {
                box-shadow: 0 14px 26px -12px rgba(244, 67, 54, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(244, 67, 54, 0.2);
                background-color: #f44336;
            }

        .jss616 {
            box-shadow: 0 2px 2px 0 rgba(233, 30, 99, 0.14), 0 3px 1px -2px rgba(233, 30, 99, 0.2), 0 1px 5px 0 rgba(233, 30, 99, 0.12);
            background-color: #e91e63;
        }

            .jss616:hover, .jss616:focus {
                box-shadow: 0 14px 26px -12px rgba(233, 30, 99, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(233, 30, 99, 0.2);
                background-color: #e91e63;
            }

        .jss617, .jss617:focus, .jss617:hover {
            color: #999;
            background-color: #FFF;
        }

        .jss618 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(85, 172, 238, 0.14), 0 3px 1px -2px rgba(85, 172, 238, 0.2), 0 1px 5px 0 rgba(85, 172, 238, 0.12);
            background-color: #55acee;
        }

            .jss618:hover, .jss618:focus, .jss618:visited {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(85, 172, 238, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(85, 172, 238, 0.2);
                background-color: #55acee;
            }

        .jss619 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(59, 89, 152, 0.14), 0 3px 1px -2px rgba(59, 89, 152, 0.2), 0 1px 5px 0 rgba(59, 89, 152, 0.12);
            background-color: #3b5998;
        }

            .jss619:hover, .jss619:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(59, 89, 152, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(59, 89, 152, 0.2);
                background-color: #3b5998;
            }

        .jss620 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(221, 75, 57, 0.14), 0 3px 1px -2px rgba(221, 75, 57, 0.2), 0 1px 5px 0 rgba(221, 75, 57, 0.12);
            background-color: #dd4b39;
        }

            .jss620:hover, .jss620:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(221, 75, 57, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(221, 75, 57, 0.2);
                background-color: #dd4b39;
            }

        .jss621 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(9, 118, 180, 0.14), 0 3px 1px -2px rgba(9, 118, 180, 0.2), 0 1px 5px 0 rgba(9, 118, 180, 0.12);
            background-color: #0976b4;
        }

            .jss621:hover, .jss621:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(9, 118, 180, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(9, 118, 180, 0.2);
                background-color: #0976b4;
            }

        .jss622 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(204, 33, 39, 0.14), 0 3px 1px -2px rgba(204, 33, 39, 0.2), 0 1px 5px 0 rgba(204, 33, 39, 0.12);
            background-color: #cc2127;
        }

            .jss622:hover, .jss622:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(204, 33, 39, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(204, 33, 39, 0.2);
                background-color: #cc2127;
            }

        .jss623 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(229, 45, 39, 0.14), 0 3px 1px -2px rgba(229, 45, 39, 0.2), 0 1px 5px 0 rgba(229, 45, 39, 0.12);
            background-color: #e52d27;
        }

            .jss623:hover, .jss623:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(229, 45, 39, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(229, 45, 39, 0.2);
                background-color: #e52d27;
            }

        .jss624 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(53, 70, 92, 0.14), 0 3px 1px -2px rgba(53, 70, 92, 0.2), 0 1px 5px 0 rgba(53, 70, 92, 0.12);
            background-color: #35465c;
        }

            .jss624:hover, .jss624:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(53, 70, 92, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(53, 70, 92, 0.2);
                background-color: #35465c;
            }

        .jss625 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(85, 85, 85, 0.14), 0 3px 1px -2px rgba(85, 85, 85, 0.2), 0 1px 5px 0 rgba(85, 85, 85, 0.12);
            background-color: #333;
        }

            .jss625:hover, .jss625:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(85, 85, 85, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(85, 85, 85, 0.2);
                background-color: #333;
            }

        .jss626 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(23, 105, 255, 0.14), 0 3px 1px -2px rgba(23, 105, 255, 0.2), 0 1px 5px 0 rgba(23, 105, 255, 0.12);
            background-color: #1769ff;
        }

            .jss626:hover, .jss626:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(23, 105, 255, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(23, 105, 255, 0.2);
                background-color: #1769ff;
            }

        .jss627 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(234, 76, 137, 0.14), 0 3px 1px -2px rgba(234, 76, 137, 0.2), 0 1px 5px 0 rgba(234, 76, 137, 0.12);
            background-color: #ea4c89;
        }

            .jss627:hover, .jss627:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(234, 76, 137, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(234, 76, 137, 0.2);
                background-color: #ea4c89;
            }

        .jss628 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(255, 69, 0, 0.14), 0 3px 1px -2px rgba(255, 69, 0, 0.2), 0 1px 5px 0 rgba(255, 69, 0, 0.12);
            background-color: #ff4500;
        }

            .jss628:hover, .jss628:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(255, 69, 0, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(255, 69, 0, 0.2);
                background-color: #ff4500;
            }

        .jss629, .jss629:focus, .jss629:hover {
            color: #FFF;
            background: transparent;
            box-shadow: none;
        }

            .jss629.jss628, .jss629.jss628:focus, .jss629.jss628:hover, .jss629.jss628:visited {
                color: #ff4500;
            }

            .jss629.jss627, .jss629.jss627:focus, .jss629.jss627:hover, .jss629.jss627:visited {
                color: #ea4c89;
            }

            .jss629.jss626, .jss629.jss626:focus, .jss629.jss626:hover, .jss629.jss626:visited {
                color: #1769ff;
            }

            .jss629.jss625, .jss629.jss625:focus, .jss629.jss625:hover, .jss629.jss625:visited {
                color: #333;
            }

            .jss629.jss624, .jss629.jss624:focus, .jss629.jss624:hover, .jss629.jss624:visited {
                color: #35465c;
            }

            .jss629.jss623, .jss629.jss623:focus, .jss629.jss623:hover, .jss629.jss623:visited {
                color: #e52d27;
            }

            .jss629.jss622, .jss629.jss622:focus, .jss629.jss622:hover, .jss629.jss622:visited {
                color: #cc2127;
            }

            .jss629.jss621, .jss629.jss621:focus, .jss629.jss621:hover, .jss629.jss621:visited {
                color: #0976b4;
            }

            .jss629.jss620, .jss629.jss620:focus, .jss629.jss620:hover, .jss629.jss620:visited {
                color: #dd4b39;
            }

            .jss629.jss619, .jss629.jss619:focus, .jss629.jss619:hover, .jss629.jss619:visited {
                color: #3b5998;
            }

            .jss629.jss618, .jss629.jss618:focus, .jss629.jss618:hover, .jss629.jss618:visited {
                color: #55acee;
            }

            .jss629.jss615, .jss629.jss615:focus, .jss629.jss615:hover, .jss629.jss615:visited {
                color: #f44336;
            }

            .jss629.jss616, .jss629.jss616:focus, .jss629.jss616:hover, .jss629.jss616:visited {
                color: #e91e63;
            }

            .jss629.jss614, .jss629.jss614:focus, .jss629.jss614:hover, .jss629.jss614:visited {
                color: #ff9800;
            }

            .jss629.jss613, .jss629.jss613:focus, .jss629.jss613:hover, .jss629.jss613:visited {
                color: #4caf50;
            }

            .jss629.jss612, .jss629.jss612:focus, .jss629.jss612:hover, .jss629.jss612:visited {
                color: #00acc1;
            }

            .jss629.jss611, .jss629.jss611:focus, .jss629.jss611:hover, .jss629.jss611:visited {
                color: #9c27b0;
            }

        .jss630, .jss630:focus, .jss630:hover {
            color: inherit;
            background: transparent;
            box-shadow: none;
        }

        .jss631 {
            opacity: 0.65;
            pointer-events: none;
        }

        .jss632 {
            padding: 1.125rem 2.25rem;
            font-size: 0.875rem;
            line-height: 1.333333;
            border-radius: 0.2rem;
        }

            .jss632.jss637 .fab, .jss632.jss637 .fas, .jss632.jss637 .far, .jss632.jss637 .fal, .jss632.jss637 svg, .jss632.jss637 .material-icons {
                margin-top: -4px;
            }

        .jss633 {
            padding: 0.40625rem 1.25rem;
            font-size: 0.6875rem;
            line-height: 1.5;
            border-radius: 0.2rem;
        }

            .jss633.jss637 .fab, .jss633.jss637 .fas, .jss633.jss637 .far, .jss633.jss637 .fal, .jss633.jss637 svg, .jss633.jss637 .material-icons {
                margin-top: 1px;
            }

        .jss634 {
            border-radius: 30px;
        }

        .jss635 {
            width: 100% !important;
        }

        .jss636, .jss636:hover, .jss636:focus {
            color: #999;
            box-shadow: none;
            background-color: transparent;
        }

        .jss637 {
            width: 41px;
            height: 41px;
            font-size: 20px;
            min-width: 41px;
            padding-left: 12px;
            padding-right: 12px;
        }

            .jss637 .fab, .jss637 .fas, .jss637 .far, .jss637 .fal, .jss637 svg, .jss637 .material-icons {
                margin-right: 0px;
            }

            .jss637.jss632 {
                width: 57px;
                height: 57px;
                min-width: 57px;
                line-height: 56px;
            }

            .jss637.jss633 {
                width: 30px;
                height: 30px;
                min-width: 30px;
            }

                .jss637.jss633 .fab, .jss637.jss633 .fas, .jss637.jss633 .far, .jss637.jss633 .fal, .jss637.jss633 .material-icons {
                    font-size: 17px;
                    line-height: 29px;
                }

                .jss637.jss633 svg {
                    width: 17px;
                    height: 17px;
                }

            .jss637.jss632 .fab, .jss637.jss632 .fas, .jss637.jss632 .far, .jss637.jss632 .fal, .jss637.jss632 .material-icons {
                font-size: 32px;
                line-height: 56px;
            }

            .jss637.jss632 svg {
                width: 32px;
                height: 32px;
            }

        .jss638 {
            padding: 0 15px !important;
        }

        .jss639 {
            color: rgba(0, 0, 0, 0.87);
            width: 100%;
            border: 0;
            display: flex;
            position: relative;
            font-size: .875rem;
            min-width: 0;
            word-wrap: break-word;
            background: #FFF;
            box-shadow: 0 1px 4px 0 rgba(0, 0, 0, 0.14);
            margin-top: 30px;
            border-radius: 6px;
            margin-bottom: 30px;
            flex-direction: column;
        }

        .jss640 {
            background: transparent;
            box-shadow: none;
        }

        .jss641 {
            margin-top: 30px;
            text-align: center;
        }

        .jss642 {
            margin-top: 60px;
        }

        .jss643 {
            box-shadow: 0 16px 38px -12px rgba(0, 0, 0, 0.56), 0 4px 25px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 0, 0, 0.2);
        }

        .jss644 {
            text-align: center;
            background-size: cover;
            background-position: center center;
        }

            .jss644:after {
                top: 0;
                left: 0;
                width: 100%;
                height: 100%;
                content: "";
                display: block;
                z-index: 1;
                position: absolute;
                border-radius: 6px;
                background-color: rgba(0, 0, 0, 0.56);
            }

            .jss644 small {
                color: rgba(255, 255, 255, 0.7) !important;
            }

        .jss645 {
            text-align: center;
        }

            .jss645:after {
                background-color: rgba(0, 0, 0, 0.7) !important;
            }

            .jss645 ul {
                margin: 10px auto;
                padding: 0;
                max-width: 240px;
                list-style: none;
            }

                .jss645 ul li {
                    color: #999;
                    padding: 12px 0px;
                    text-align: center;
                    border-bottom: 1px solid rgba(153, 153, 153,0.3);
                }

                    .jss645 ul li:last-child {
                        border: 0;
                    }

                    .jss645 ul li b {
                        color: #3C4858;
                    }

            .jss645 h1 {
                margin-top: 30px;
            }

                .jss645 h1 small {
                    height: 0;
                    display: inline-flex;
                    font-size: 18px;
                }

                    .jss645 h1 small:first-child {
                        top: -17px;
                        position: relative;
                        font-size: 26px;
                    }

            .jss645 ul li svg, .jss645 ul li .fab, .jss645 ul li .fas, .jss645 ul li .far, .jss645 ul li .fal, .jss645 ul li .material-icons {
                top: 7px;
                position: relative;
            }

        .jss646 ul li {
            color: #FFF;
            border-color: rgba(255, 255, 255,0.3);
        }

            .jss646 ul li b, .jss646 ul li svg, .jss646 ul li .fab, .jss646 ul li .fas, .jss646 ul li .far, .jss646 ul li .fal, .jss646 ul li .material-icons {
                color: #FFF;
                font-weight: 700;
            }

        .jss647 {
            margin-top: 30px;
        }

        .jss648 {
            color: #FFF;
            background: linear-gradient(60deg,#ab47bc,#7b1fa2);
        }

            .jss648 h1 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss649 {
            color: #FFF;
            background: linear-gradient(60deg,#26c6da,#0097a7);
        }

            .jss649 h1 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss650 {
            color: #FFF;
            background: linear-gradient(60deg,#66bb6a,#388e3c);
        }

            .jss650 h1 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss651 {
            color: #FFF;
            background: linear-gradient(60deg,#ffa726,#f57c00);
        }

            .jss651 h1 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss652 {
            color: #FFF;
            background: linear-gradient(60deg,#ef5350,#d32f2f);
        }

            .jss652 h1 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss653 {
            color: #FFF;
            background: linear-gradient(60deg,#ec407a,#c2185b);
        }

            .jss653 h1 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss654 p {
            margin-top: 0px;
            padding-top: 0px;
        }

        .jss655 {
            transform: translate3d(0, 0, 0);
            transition: all 300ms linear;
        }

        .jss656 {
            flex: 1 1 auto;
            padding: 0.9375rem 20px;
            position: relative;
            -webkit-box-flex: 1;
        }

        .jss657 {
            margin: 0 auto;
            z-index: 2;
            position: relative;
            max-width: 440px;
            min-height: 280px;
            padding-top: 40px;
            padding-bottom: 40px;
        }

        .jss658 {
            padding-left: 5px;
            padding-right: 5px;
        }

        .jss659 {
            padding-left: 15px;
            padding-right: 15px;
        }

            .jss659 form {
                margin: 0;
            }

        .jss660 {
            margin: 0px !important;
            padding: 15px !important;
        }

        .jss661 {
            padding: 0px 30px 0px 30px;
        }

        .jss662 {
            border-radius: 6px;
        }

            .jss662 h1 small, .jss662 h2 small, .jss662 h3 small {
                color: rgba(255, 255, 255, 0.8);
            }

        .jss663 {
            margin-top: 15px;
        }

        .jss664 {
            padding: 0px !important;
        }

        .jss665 {
            border: 0;
            margin: 0 15px 10px;
            display: flex;
            padding: 0;
            align-items: center;
            padding-top: 10px;
            border-radius: 0;
            justify-content: space-between;
            background-color: transparent;
        }

        .jss666 {
            margin-top: -15px;
        }

        .jss667 {
            padding-left: 5px;
            padding-right: 5px;
            background-color: transparent;
        }

        .jss668 {
            z-index: 2;
        }

        .jss669 {
            display: block;
        }

        .jss670 {
            border-top: 1px solid#eee;
            margin-top: 20px;
        }

            .jss670 svg {
                top: 4px;
                width: 16px;
                height: 16px;
                position: relative;
                margin-left: 3px;
                margin-right: 3px;
            }

            .jss670 .fab, .jss670 .fas, .jss670 .far, .jss670 .fal, .jss670 .material-icons {
                top: 4px;
                position: relative;
                font-size: 16px;
                line-height: 16px;
                margin-left: 3px;
                margin-right: 3px;
            }

        .jss671 {
            border-top: 1px solid#eee;
        }

        .jss672.jss673 img, .jss672.jss675 img {
            width: 100%;
            height: auto;
        }

        .jss673 {
            margin: -50px auto 0;
            padding: 0;
            overflow: hidden;
            max-width: 130px;
            box-shadow: 0 16px 38px -12px rgba(0, 0, 0, 0.56), 0 4px 25px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 0, 0, 0.2);
            max-height: 130px;
            border-radius: 50%;
        }

            .jss673.jss674 {
                margin-top: 0;
            }

        .jss675 {
            margin: -50px auto 0;
            padding: 0;
            overflow: hidden;
            max-width: 100px;
            box-shadow: 0 16px 38px -12px rgba(0, 0, 0, 0.56), 0 4px 25px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 0, 0, 0.2);
            max-height: 100px;
            border-radius: 50%;
        }

            .jss675.jss674 {
                margin-top: 0;
            }

        .jss676 {
            margin-top: 10px;
            margin-bottom: -50px;
        }

        .jss677 {
            padding: 0 15px !important;
        }

        .jss678 {
            padding: 20px 0 20px;
            position: relative;
            list-style: none;
            margin-top: 30px;
        }

        @media (max-width:959.95px) {
            .jss678:before {
                left: 5% !important;
            }
        }

        .jss678:before {
            top: 50px;
            left: 50%;
            width: 3px;
            bottom: 0;
            content: " ";
            position: absolute;
            margin-left: -1px;
            background-color: #E5E5E5;
        }

        .jss679 {
            padding: 0 0 20px;
            margin-top: 30px;
        }

            .jss679:before {
                left: 22px;
            }

        .jss680 {
            position: relative;
            margin-bottom: 20px;
        }

            .jss680:before, .jss680:after {
                content: " ";
                display: table;
            }

            .jss680:after {
                clear: both;
            }

        .jss681 {
            top: 16px;
            left: 50%;
            color: #FFF;
            width: 50px;
            height: 50px;
            z-index: 100;
            position: absolute;
            font-size: 1.4em;
            text-align: center;
            line-height: 51px;
            margin-left: -24px;
            border-top-left-radius: 50%;
            border-top-right-radius: 50%;
            border-bottom-left-radius: 50%;
            border-bottom-right-radius: 50%;
        }

        @media (max-width:959.95px) {
            .jss681 {
                left: 5% !important;
            }
        }

        .jss682 {
            left: 5%;
        }

        .jss683 {
            box-shadow: 0 4px 20px 0px rgba(0, 0, 0, 0.14), 0 7px 10px -5px rgba(0, 172, 193, 0.4);
            background-color: #00acc1;
        }

        .jss684 {
            box-shadow: 0 4px 20px 0px rgba(0, 0, 0, 0.14), 0 7px 10px -5px rgba(76, 175, 80, 0.4);
            background-color: #4caf50;
        }

        .jss685 {
            box-shadow: 0 4px 20px 0px rgba(0, 0, 0, 0.14), 0 7px 10px -5px rgba(244, 67, 54, 0.4);
            background-color: #f44336;
        }

        .jss686 {
            box-shadow: 0 4px 20px 0px rgba(0, 0, 0, 0.14), 0 7px 10px -5px rgba(255, 152, 0, 0.4);
            background-color: #ff9800;
        }

        .jss687 {
            box-shadow: 0 4px 20px 0px rgba(0, 0, 0, 0.14), 0 7px 10px -5px rgba(156, 39, 176, 0.4);
            background-color: #9c27b0;
        }

        .jss688 {
            width: 24px;
            height: 51px;
        }

        .jss689 {
            color: rgba(0, 0, 0, 0.87);
            float: left;
            width: 45%;
            padding: 20px;
            position: relative;
            background: #FFF;
            box-shadow: 0 1px 4px 0 rgba(0, 0, 0, 0.14);
            border-radius: 6px;
            margin-bottom: 20px;
        }

        @media (max-width:959.95px) {
            .jss689 {
                float: right !important;
                width: 86% !important;
            }

                .jss689:before {
                    left: -15px !important;
                    right: auto !important;
                    border-left-width: 0 !important;
                    border-right-width: 15px !important;
                }

                .jss689:after {
                    left: -14px !important;
                    right: auto !important;
                    border-left-width: 0 !important;
                    border-right-width: 14px !important;
                }
        }

        .jss689:before {
            top: 26px;
            right: -15px;
            content: " ";
            display: inline-block;
            position: absolute;
            border-top: 15px solid transparent;
            border-left: 15px solid #e4e4e4;
            border-right: 0 solid #e4e4e4;
            border-bottom: 15px solid transparent;
        }

        .jss689:after {
            top: 27px;
            right: -14px;
            content: " ";
            display: inline-block;
            position: absolute;
            border-top: 14px solid transparent;
            border-left: 14px solid #FFF;
            border-right: 0 solid #FFF;
            border-bottom: 14px solid transparent;
        }

        .jss690 {
            width: 60%;
        }

        @media (min-width:600px) {
            .jss691 {
                float: right;
                background-color: #FFF;
            }

                .jss691:before {
                    left: -15px;
                    right: auto;
                    border-left-width: 0;
                    border-right-width: 15px;
                }

                .jss691:after {
                    left: -14px;
                    right: auto;
                    border-left-width: 0;
                    border-right-width: 14px;
                }
        }

        .jss692 {
            margin-bottom: 15px;
        }

        .jss693 {
            font-size: 14px;
            line-height: 21px;
        }

        .jss694 {
            float: left;
            z-index: 1000;
            position: relative;
        }

        .jss695 {
            color: #333;
            margin: 10px 0px 0px;
            font-weight: 400;
        }

        .jss696 {
            margin-top: 10px;
            margin-bottom: 5px;
        }

        .jss697 {
            color: #FFF;
            display: inline-block;
            padding: 5px 12px;
            font-size: 10px;
            text-align: center;
            font-weight: 700;
            line-height: 1;
            border-radius: 12px;
            text-transform: uppercase;
            vertical-align: baseline;
        }

        .jss698 {
            background-color: #9c27b0;
        }

        .jss699 {
            background-color: #ff9800;
        }

        .jss700 {
            background-color: #f44336;
        }

        .jss701 {
            background-color: #4caf50;
        }

        .jss702 {
            background-color: #00acc1;
        }

        .jss703 {
            background-color: #e91e63;
        }

        .jss704 {
            background-color: #999;
        }

        .jss705 {
            color: #FFF;
            display: inline-block;
            padding: 5px 12px;
            font-size: 10px;
            text-align: center;
            font-weight: 700;
            line-height: 1;
            border-radius: 12px;
            text-transform: uppercase;
            vertical-align: baseline;
        }

        .jss706 {
            background-color: #9c27b0;
        }

        .jss707 {
            background-color: #ff9800;
        }

        .jss708 {
            background-color: #f44336;
        }

        .jss709 {
            background-color: #4caf50;
        }

        .jss710 {
            background-color: #00acc1;
        }

        .jss711 {
            background-color: #e91e63;
        }

        .jss712 {
            background-color: #999;
        }

        .jss713 {
            color: #FFF;
            display: inline-block;
            padding: 5px 12px;
            font-size: 10px;
            text-align: center;
            font-weight: 700;
            line-height: 1;
            border-radius: 12px;
            text-transform: uppercase;
            vertical-align: baseline;
        }

        .jss714 {
            background-color: #9c27b0;
        }

        .jss715 {
            background-color: #ff9800;
        }

        .jss716 {
            background-color: #f44336;
        }

        .jss717 {
            background-color: #4caf50;
        }

        .jss718 {
            background-color: #00acc1;
        }

        .jss719 {
            background-color: #e91e63;
        }

        .jss720 {
            background-color: #999;
        }

        .jss721 {
            display: none !important;
            pointer-events: none;
        }

        @media (max-width:959.95px) {
            .jss722 {
                top: unset !important;
                left: unset !important;
                position: static !important;
                transform: none !important;
                will-change: unset !important;
            }

                .jss722 > div {
                    padding: 0px !important;
                    box-shadow: none !important;
                    margin-top: 0px !important;
                    transition: none !important;
                    margin-left: 0rem;
                    margin-right: 0rem;
                    margin-bottom: 0px !important;
                    background-color: transparent !important;
                }

                    .jss722 > div ul li {
                        color: #FFF !important;
                        margin: 10px 15px 0 !important;
                        padding: 10px 15px !important;
                    }

                        .jss722 > div ul li:hover {
                            box-shadow: none;
                            background-color: hsla(0,0%,78%,.2);
                        }
        }

        .jss723 > div > button:first-child > span:first-child, .jss723 > div > a:first-child > span:first-child {
            width: 100%;
        }

        .jss724 > div > button, .jss724 > div > a {
            color: inherit !important;
            margin: 0px !important;
            padding: 10px 20px !important;
        }

            .jss724 > div > button > span:first-child, .jss724 > div > a > span:first-child {
                width: 100%;
                justify-content: flex-start;
            }

        .jss725 > button:first-child > span:first-child, .jss725 > a:first-child > span:first-child {
            display: inline-block;
        }

        .jss725 .jss740 {
            margin-left: 0px;
        }

        .jss726 {
            top: 100%;
            border: 0;
            margin: 2px 0 0;
            padding: 5px 0;
            z-index: 1000;
            font-size: 14px;
            min-width: 160px;
            box-shadow: 0 2px 5px 0 rgba(0, 0, 0, 0.26);
            list-style: none;
            text-align: left;
            border-radius: 3px;
            background-clip: padding-box;
            background-color: #FFF;
        }

        .jss727 {
            padding: 0;
        }

        .jss728 {
            z-index: 1200;
        }

        @media (max-width:959.95px) {
            .jss728 {
                color: black;
                float: none;
                width: auto;
                border: 0;
                z-index: 1640;
                position: static;
                box-shadow: none;
                margin-top: 0;
                background-color: transparent;
            }
        }

        .jss729 {
            clear: both;
            color: #333;
            height: 100%;
            margin: 0 5px;
            display: block;
            padding: 10px 20px;
            position: relative;
            font-size: 13px;
            min-height: unset;
            transition: all 150ms linear;
            font-family: "Roboto", "Helvetica", "Arial", sans-serif;
            font-weight: 400;
            line-height: 1.5em;
            white-space: nowrap;
            border-radius: 2px;
        }

        .jss730:hover {
            color: #FFF;
            box-shadow: 0 4px 20px 0px rgba(0, 0, 0, 0.14), 0 7px 10px -5px rgba(33, 33, 33, 0.4);
            background-color: #212121;
        }

        .jss731:hover {
            color: #FFF;
            box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(156, 39, 176,.4);
            background-color: #9c27b0;
        }

        .jss732:hover {
            color: #FFF;
            box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(0, 172, 193,.4);
            background-color: #00acc1;
        }

        .jss733:hover {
            color: #FFF;
            box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(76, 175, 80,.4);
            background-color: #4caf50;
        }

        .jss734:hover {
            color: #FFF;
            box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(255, 152, 0,.4);
            background-color: #ff9800;
        }

        .jss735:hover {
            color: #FFF;
            box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(244, 67, 54,.4);
            background-color: #f44336;
        }

        .jss736:hover {
            color: #FFF;
            box-shadow: 0 4px 20px 0 rgba(0, 0, 0,.14), 0 7px 10px -5px rgba(233, 30, 99,.4);
            background-color: #e91e63;
        }

        .jss737 {
            text-align: right;
        }

        .jss738 {
            height: 1px;
            margin: 5px 0;
            overflow: hidden;
            background-color: rgba(0, 0, 0, 0.12);
        }

        .jss739 {
            width: 20px;
            height: 20px;
        }

        .jss740 {
            width: 0;
            height: 0;
            display: inline-block;
            border-top: 4px solid;
            transition: all 150ms ease-in;
            border-left: 4px solid transparent;
            margin-left: 4px;
            border-right: 4px solid transparent;
            vertical-align: middle;
        }

        .jss741 {
            transform: rotate(180deg);
        }

        .jss742 {
            transform: rotate(180deg);
        }

        .jss743 {
            margin-right: 4px;
        }

        .jss744 {
            color: #777;
            display: block;
            padding: 0.1875rem 1.25rem;
            font-size: 0.75rem;
            margin-top: 10px;
            min-height: unset;
            font-weight: inherit;
            line-height: 1.428571;
            white-space: nowrap;
        }

            .jss744:hover, .jss744:focus {
                cursor: auto;
                background-color: transparent;
            }

        .jss745 {
            padding: 0;
        }

        .jss746 {
            color: #FFF;
            border: none;
            cursor: pointer;
            margin: .3125rem 1px;
            padding: 12px 30px;
            position: relative;
            font-size: 12px;
            min-width: auto;
            box-shadow: 0 2px 2px 0 rgba(153, 153, 153, 0.14), 0 3px 1px -2px rgba(153, 153, 153, 0.2), 0 1px 5px 0 rgba(153, 153, 153, 0.12);
            min-height: auto;
            text-align: center;
            transition: box-shadow 0.2s cubic-bezier(0.4, 0, 1, 1), background-color 0.2s cubic-bezier(0.4, 0, 0.2, 1);
            font-weight: 400;
            line-height: 1.42857143;
            white-space: nowrap;
            will-change: box-shadow, transform;
            touch-action: manipulation;
            border-radius: 3px;
            letter-spacing: 0;
            text-transform: uppercase;
            vertical-align: middle;
            background-color: #999;
        }

            .jss746:hover, .jss746:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(153, 153, 153, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(153, 153, 153, 0.2);
                background-color: #999;
            }

            .jss746 .fab, .jss746 .fas, .jss746 .far, .jss746 .fal, .jss746 .material-icons {
                top: 0;
                display: inline-block;
                position: relative;
                font-size: 1.1rem;
                margin-top: -1em;
                margin-right: 4px;
                margin-bottom: -1em;
                vertical-align: middle;
            }

            .jss746 svg {
                top: 0;
                width: 18px;
                height: 18px;
                display: inline-block;
                position: relative;
                margin-right: 4px;
                vertical-align: middle;
            }

            .jss746.jss774 .fab, .jss746.jss774 .fas, .jss746.jss774 .far, .jss746.jss774 .fal, .jss746.jss774 .material-icons {
                top: 0px;
                left: 0px;
                width: 100%;
                height: 100%;
                position: absolute;
                font-size: 20px;
                transform: none;
                margin-top: 0px;
                line-height: 41px;
            }

        .jss747 {
            width: 100%;
        }

        .jss748 {
            box-shadow: 0 2px 2px 0 rgba(156, 39, 176, 0.14), 0 3px 1px -2px rgba(156, 39, 176, 0.2), 0 1px 5px 0 rgba(156, 39, 176, 0.12);
            background-color: #9c27b0;
        }

            .jss748:hover, .jss748:focus {
                box-shadow: 0 14px 26px -12px rgba(156, 39, 176, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(156, 39, 176, 0.2);
                background-color: #9c27b0;
            }

        .jss749 {
            box-shadow: 0 2px 2px 0 rgba(0, 172, 193, 0.14), 0 3px 1px -2px rgba(0, 172, 193, 0.2), 0 1px 5px 0 rgba(0, 172, 193, 0.12);
            background-color: #00acc1;
        }

            .jss749:hover, .jss749:focus {
                box-shadow: 0 14px 26px -12px rgba(0, 172, 193, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 172, 193, 0.2);
                background-color: #00acc1;
            }

        .jss750 {
            box-shadow: 0 2px 2px 0 rgba(76, 175, 80, 0.14), 0 3px 1px -2px rgba(76, 175, 80, 0.2), 0 1px 5px 0 rgba(76, 175, 80, 0.12);
            background-color: #4caf50;
        }

            .jss750:hover, .jss750:focus {
                box-shadow: 0 14px 26px -12px rgba(76, 175, 80, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(76, 175, 80, 0.2);
                background-color: #4caf50;
            }

        .jss751 {
            box-shadow: 0 2px 2px 0 rgba(255, 152, 0, 0.14), 0 3px 1px -2px rgba(255, 152, 0, 0.2), 0 1px 5px 0 rgba(255, 152, 0, 0.12);
            background-color: #ff9800;
        }

            .jss751:hover, .jss751:focus {
                box-shadow: 0 14px 26px -12px rgba(255, 152, 0, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(255, 152, 0, 0.2);
                background-color: #ff9800;
            }

        .jss752 {
            box-shadow: 0 2px 2px 0 rgba(244, 67, 54, 0.14), 0 3px 1px -2px rgba(244, 67, 54, 0.2), 0 1px 5px 0 rgba(244, 67, 54, 0.12);
            background-color: #f44336;
        }

            .jss752:hover, .jss752:focus {
                box-shadow: 0 14px 26px -12px rgba(244, 67, 54, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(244, 67, 54, 0.2);
                background-color: #f44336;
            }

        .jss753 {
            box-shadow: 0 2px 2px 0 rgba(233, 30, 99, 0.14), 0 3px 1px -2px rgba(233, 30, 99, 0.2), 0 1px 5px 0 rgba(233, 30, 99, 0.12);
            background-color: #e91e63;
        }

            .jss753:hover, .jss753:focus {
                box-shadow: 0 14px 26px -12px rgba(233, 30, 99, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(233, 30, 99, 0.2);
                background-color: #e91e63;
            }

        .jss754, .jss754:focus, .jss754:hover {
            color: #999;
            background-color: #FFF;
        }

        .jss755 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(85, 172, 238, 0.14), 0 3px 1px -2px rgba(85, 172, 238, 0.2), 0 1px 5px 0 rgba(85, 172, 238, 0.12);
            background-color: #55acee;
        }

            .jss755:hover, .jss755:focus, .jss755:visited {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(85, 172, 238, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(85, 172, 238, 0.2);
                background-color: #55acee;
            }

        .jss756 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(59, 89, 152, 0.14), 0 3px 1px -2px rgba(59, 89, 152, 0.2), 0 1px 5px 0 rgba(59, 89, 152, 0.12);
            background-color: #3b5998;
        }

            .jss756:hover, .jss756:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(59, 89, 152, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(59, 89, 152, 0.2);
                background-color: #3b5998;
            }

        .jss757 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(221, 75, 57, 0.14), 0 3px 1px -2px rgba(221, 75, 57, 0.2), 0 1px 5px 0 rgba(221, 75, 57, 0.12);
            background-color: #dd4b39;
        }

            .jss757:hover, .jss757:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(221, 75, 57, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(221, 75, 57, 0.2);
                background-color: #dd4b39;
            }

        .jss758 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(9, 118, 180, 0.14), 0 3px 1px -2px rgba(9, 118, 180, 0.2), 0 1px 5px 0 rgba(9, 118, 180, 0.12);
            background-color: #0976b4;
        }

            .jss758:hover, .jss758:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(9, 118, 180, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(9, 118, 180, 0.2);
                background-color: #0976b4;
            }

        .jss759 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(204, 33, 39, 0.14), 0 3px 1px -2px rgba(204, 33, 39, 0.2), 0 1px 5px 0 rgba(204, 33, 39, 0.12);
            background-color: #cc2127;
        }

            .jss759:hover, .jss759:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(204, 33, 39, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(204, 33, 39, 0.2);
                background-color: #cc2127;
            }

        .jss760 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(229, 45, 39, 0.14), 0 3px 1px -2px rgba(229, 45, 39, 0.2), 0 1px 5px 0 rgba(229, 45, 39, 0.12);
            background-color: #e52d27;
        }

            .jss760:hover, .jss760:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(229, 45, 39, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(229, 45, 39, 0.2);
                background-color: #e52d27;
            }

        .jss761 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(53, 70, 92, 0.14), 0 3px 1px -2px rgba(53, 70, 92, 0.2), 0 1px 5px 0 rgba(53, 70, 92, 0.12);
            background-color: #35465c;
        }

            .jss761:hover, .jss761:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(53, 70, 92, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(53, 70, 92, 0.2);
                background-color: #35465c;
            }

        .jss762 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(85, 85, 85, 0.14), 0 3px 1px -2px rgba(85, 85, 85, 0.2), 0 1px 5px 0 rgba(85, 85, 85, 0.12);
            background-color: #333;
        }

            .jss762:hover, .jss762:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(85, 85, 85, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(85, 85, 85, 0.2);
                background-color: #333;
            }

        .jss763 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(23, 105, 255, 0.14), 0 3px 1px -2px rgba(23, 105, 255, 0.2), 0 1px 5px 0 rgba(23, 105, 255, 0.12);
            background-color: #1769ff;
        }

            .jss763:hover, .jss763:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(23, 105, 255, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(23, 105, 255, 0.2);
                background-color: #1769ff;
            }

        .jss764 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(234, 76, 137, 0.14), 0 3px 1px -2px rgba(234, 76, 137, 0.2), 0 1px 5px 0 rgba(234, 76, 137, 0.12);
            background-color: #ea4c89;
        }

            .jss764:hover, .jss764:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(234, 76, 137, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(234, 76, 137, 0.2);
                background-color: #ea4c89;
            }

        .jss765 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(255, 69, 0, 0.14), 0 3px 1px -2px rgba(255, 69, 0, 0.2), 0 1px 5px 0 rgba(255, 69, 0, 0.12);
            background-color: #ff4500;
        }

            .jss765:hover, .jss765:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(255, 69, 0, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(255, 69, 0, 0.2);
                background-color: #ff4500;
            }

        .jss766, .jss766:focus, .jss766:hover {
            color: #FFF;
            background: transparent;
            box-shadow: none;
        }

            .jss766.jss765, .jss766.jss765:focus, .jss766.jss765:hover, .jss766.jss765:visited {
                color: #ff4500;
            }

            .jss766.jss764, .jss766.jss764:focus, .jss766.jss764:hover, .jss766.jss764:visited {
                color: #ea4c89;
            }

            .jss766.jss763, .jss766.jss763:focus, .jss766.jss763:hover, .jss766.jss763:visited {
                color: #1769ff;
            }

            .jss766.jss762, .jss766.jss762:focus, .jss766.jss762:hover, .jss766.jss762:visited {
                color: #333;
            }

            .jss766.jss761, .jss766.jss761:focus, .jss766.jss761:hover, .jss766.jss761:visited {
                color: #35465c;
            }

            .jss766.jss760, .jss766.jss760:focus, .jss766.jss760:hover, .jss766.jss760:visited {
                color: #e52d27;
            }

            .jss766.jss759, .jss766.jss759:focus, .jss766.jss759:hover, .jss766.jss759:visited {
                color: #cc2127;
            }

            .jss766.jss758, .jss766.jss758:focus, .jss766.jss758:hover, .jss766.jss758:visited {
                color: #0976b4;
            }

            .jss766.jss757, .jss766.jss757:focus, .jss766.jss757:hover, .jss766.jss757:visited {
                color: #dd4b39;
            }

            .jss766.jss756, .jss766.jss756:focus, .jss766.jss756:hover, .jss766.jss756:visited {
                color: #3b5998;
            }

            .jss766.jss755, .jss766.jss755:focus, .jss766.jss755:hover, .jss766.jss755:visited {
                color: #55acee;
            }

            .jss766.jss752, .jss766.jss752:focus, .jss766.jss752:hover, .jss766.jss752:visited {
                color: #f44336;
            }

            .jss766.jss753, .jss766.jss753:focus, .jss766.jss753:hover, .jss766.jss753:visited {
                color: #e91e63;
            }

            .jss766.jss751, .jss766.jss751:focus, .jss766.jss751:hover, .jss766.jss751:visited {
                color: #ff9800;
            }

            .jss766.jss750, .jss766.jss750:focus, .jss766.jss750:hover, .jss766.jss750:visited {
                color: #4caf50;
            }

            .jss766.jss749, .jss766.jss749:focus, .jss766.jss749:hover, .jss766.jss749:visited {
                color: #00acc1;
            }

            .jss766.jss748, .jss766.jss748:focus, .jss766.jss748:hover, .jss766.jss748:visited {
                color: #9c27b0;
            }

        .jss767, .jss767:focus, .jss767:hover {
            color: inherit;
            background: transparent;
            box-shadow: none;
        }

        .jss768 {
            opacity: 0.65;
            pointer-events: none;
        }

        .jss769 {
            padding: 1.125rem 2.25rem;
            font-size: 0.875rem;
            line-height: 1.333333;
            border-radius: 0.2rem;
        }

            .jss769.jss774 .fab, .jss769.jss774 .fas, .jss769.jss774 .far, .jss769.jss774 .fal, .jss769.jss774 svg, .jss769.jss774 .material-icons {
                margin-top: -4px;
            }

        .jss770 {
            padding: 0.40625rem 1.25rem;
            font-size: 0.6875rem;
            line-height: 1.5;
            border-radius: 0.2rem;
        }

            .jss770.jss774 .fab, .jss770.jss774 .fas, .jss770.jss774 .far, .jss770.jss774 .fal, .jss770.jss774 svg, .jss770.jss774 .material-icons {
                margin-top: 1px;
            }

        .jss771 {
            border-radius: 30px;
        }

        .jss772 {
            width: 100% !important;
        }

        .jss773, .jss773:hover, .jss773:focus {
            color: #999;
            box-shadow: none;
            background-color: transparent;
        }

        .jss774 {
            width: 41px;
            height: 41px;
            font-size: 20px;
            min-width: 41px;
            padding-left: 12px;
            padding-right: 12px;
        }

            .jss774 .fab, .jss774 .fas, .jss774 .far, .jss774 .fal, .jss774 svg, .jss774 .material-icons {
                margin-right: 0px;
            }

            .jss774.jss769 {
                width: 57px;
                height: 57px;
                min-width: 57px;
                line-height: 56px;
            }

            .jss774.jss770 {
                width: 30px;
                height: 30px;
                min-width: 30px;
            }

                .jss774.jss770 .fab, .jss774.jss770 .fas, .jss774.jss770 .far, .jss774.jss770 .fal, .jss774.jss770 .material-icons {
                    font-size: 17px;
                    line-height: 29px;
                }

                .jss774.jss770 svg {
                    width: 17px;
                    height: 17px;
                }

            .jss774.jss769 .fab, .jss774.jss769 .fas, .jss774.jss769 .far, .jss774.jss769 .fal, .jss774.jss769 .material-icons {
                font-size: 32px;
                line-height: 56px;
            }

            .jss774.jss769 svg {
                width: 32px;
                height: 32px;
            }

        .jss776 {
            float: left !important;
            display: block;
        }

        .jss777 {
            float: right !important;
            margin: 0;
            padding: 15px;
            font-size: 14px;
        }

        .jss778 {
            bottom: 0;
            padding: 15px 0;
            z-index: 4;
            border-top: 1px solid #e7e7e7;
            font-family: "Roboto", "Helvetica", "Arial", sans-serif;
            font-weight: 300;
            line-height: 1.5em;
        }

        .jss779 {
            z-index: 3;
            position: relative;
            margin-left: auto;
            margin-right: auto;
            padding-left: 15px;
            padding-right: 15px;
        }

        @media (min-width: 768px) {
            .jss779 {
                width: 750px;
            }
        }

        @media (min-width: 992px) {
            .jss779 {
                width: 970px;
            }
        }

        @media (min-width: 1200px) {
            .jss779 {
                width: 1170px;
            }
        }

        .jss779:before, .jss779:after {
            content: " ";
            display: table;
        }

        .jss779:after {
            clear: both;
        }

        .jss780 {
            z-index: 3;
            position: relative;
            margin-left: auto;
            margin-right: auto;
            padding-left: 15px;
            padding-right: 15px;
        }

            .jss780:before, .jss780:after {
                content: " ";
                display: table;
            }

            .jss780:after {
                clear: both;
            }

        .jss781 {
            color: #9c27b0;
            text-decoration: none;
            background-color: transparent;
        }

        .jss782 {
            padding: 0;
            margin-top: 0;
            margin-bottom: 0;
        }

        .jss783 {
            width: auto;
            display: inline-block;
            padding: 0;
        }

        .jss784, .jss784:hover, .jss784:focus {
            color: #FFF;
        }

        .jss785 {
            padding: 14px;
        }

            .jss785:hover {
                background-color: unset;
            }

        .jss786 {
            padding: 16px;
        }

            .jss786:hover {
                background-color: unset;
            }

        .jss787 {
            margin-left: -14px;
        }

        .jss788 {
            display: block;
            position: relative;
            margin-top: 10px;
            margin-bottom: 10px;
        }

        .jss789 {
            display: block;
            position: relative;
            margin-top: 0;
            margin-bottom: 0;
        }

            .jss789:first-child {
                margin-top: 10px;
            }

            .jss789:not(:first-child) {
                margin-top: -14px;
            }

        .jss790 {
            color: #9c27b0 !important;
        }

        .jss791 {
            width: 20px;
            border: 1px solid rgba(0, 0, 0, .54);
            height: 20px;
            border-radius: 3px;
        }

        .jss792 {
            width: 0px;
            border: 1px solid rgba(0, 0, 0, .54);
            height: 0px;
            padding: 9px;
            border-radius: 3px;
        }

        .jss793 .jss791, .jss793 .jss792, .jss793 .jss800, .jss793 .jss801 {
            color: #000;
            opacity: 0.26;
            border-color: #000;
        }

        .jss794 {
            color: #AAAAAA;
            cursor: pointer;
            display: inline-flex;
            font-size: 14px;
            transition: 0.3s ease all;
            font-weight: 400;
            line-height: 1.428571429;
            padding-left: 0;
            letter-spacing: unset;
        }

        .jss795 {
            color: rgba(0, 0, 0, 0.26);
            cursor: pointer;
            display: inline-flex;
            font-size: 14px;
            font-weight: 400;
            line-height: 1.428571429;
            padding-top: 39px;
            margin-right: 0;
        }

        @media (min-width: 992px) {
            .jss795 {
                float: right;
            }
        }

        .jss796 {
            padding-top: 22px;
        }

        .jss797 {
            color: rgba(0, 0, 0, 0.26);
            cursor: pointer;
            display: inline-flex;
            font-size: 14px;
            font-weight: 400;
            line-height: 1.428571429;
            padding-top: 22px;
            margin-right: 0;
        }

        .jss798 {
            color: #f44336;
        }

        .jss799 {
            color: #9c27b0 !important;
        }

        .jss800 {
            width: 16px;
            border: 1px solid #9c27b0;
            height: 16px;
            border-radius: 50%;
        }

        .jss801 {
            width: 0px;
            border: 1px solid rgba(0, 0, 0, .54);
            height: 0px;
            padding: 7px;
            border-radius: 50%;
        }

        .jss802 {
            margin-top: 8px;
        }

        .jss803 {
            color: #999;
            width: 116px;
            height: 116px;
            margin: 0 auto 20px;
            padding: 0;
        }

            .jss803 > span:first-child {
                color: inherit;
                text-align: center;
                transition: all 0.2s;
                border-color: #ccc;
                border-style: solid;
                border-width: 4px;
                border-radius: 50%;
                vertical-align: middle;
            }

            .jss803:hover {
                color: #e91e63;
            }

                .jss803:hover > span:first-child {
                    border-color: #e91e63;
                }

        .jss804 {
            color: #e91e63;
        }

            .jss804 > span:first-child {
                border-color: #e91e63;
            }

        .jss805 {
            font-size: 40px;
            line-height: 111px;
        }

        .jss806 {
            color: #9c27b0 !important;
        }

        .jss807 {
            color: #FFF !important;
            border: 1px solid rgba(0, 0, 0, .54);
            box-shadow: 0 1px 3px 1px rgba(0, 0, 0, 0.4);
        }

        .jss808 {
            transform: translateX(0px) !important;
            border-color: #9c27b0;
        }

        .jss809 {
            width: 30px;
            height: 15px;
            opacity: 0.7 !important;
            border-radius: 15px;
            background-color: rgb(80, 80, 80);
        }

        .jss810 + .jss809 {
            background-color: rgba(156, 39, 176, 1) !important;
        }

        .jss810 .jss807 {
            border-color: #9c27b0;
        }

        .jss811 {
            color: #FFF;
            border: none;
            cursor: pointer;
            margin: .3125rem 1px;
            padding: 12px 30px;
            position: relative;
            font-size: 12px;
            min-width: auto;
            box-shadow: 0 2px 2px 0 rgba(153, 153, 153, 0.14), 0 3px 1px -2px rgba(153, 153, 153, 0.2), 0 1px 5px 0 rgba(153, 153, 153, 0.12);
            min-height: auto;
            text-align: center;
            transition: box-shadow 0.2s cubic-bezier(0.4, 0, 1, 1), background-color 0.2s cubic-bezier(0.4, 0, 0.2, 1);
            font-weight: 400;
            line-height: 1.42857143;
            white-space: nowrap;
            will-change: box-shadow, transform;
            touch-action: manipulation;
            border-radius: 3px;
            letter-spacing: 0;
            text-transform: uppercase;
            vertical-align: middle;
            background-color: #999;
        }

            .jss811:hover, .jss811:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(153, 153, 153, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(153, 153, 153, 0.2);
                background-color: #999;
            }

            .jss811 .fab, .jss811 .fas, .jss811 .far, .jss811 .fal, .jss811 .material-icons {
                top: 0;
                display: inline-block;
                position: relative;
                font-size: 1.1rem;
                margin-top: -1em;
                margin-right: 4px;
                margin-bottom: -1em;
                vertical-align: middle;
            }

            .jss811 svg {
                top: 0;
                width: 18px;
                height: 18px;
                display: inline-block;
                position: relative;
                margin-right: 4px;
                vertical-align: middle;
            }

            .jss811.jss839 .fab, .jss811.jss839 .fas, .jss811.jss839 .far, .jss811.jss839 .fal, .jss811.jss839 .material-icons {
                top: 0px;
                left: 0px;
                width: 100%;
                height: 100%;
                position: absolute;
                font-size: 20px;
                transform: none;
                margin-top: 0px;
                line-height: 41px;
            }

        .jss812 {
            width: 100%;
        }

        .jss813 {
            box-shadow: 0 2px 2px 0 rgba(156, 39, 176, 0.14), 0 3px 1px -2px rgba(156, 39, 176, 0.2), 0 1px 5px 0 rgba(156, 39, 176, 0.12);
            background-color: #9c27b0;
        }

            .jss813:hover, .jss813:focus {
                box-shadow: 0 14px 26px -12px rgba(156, 39, 176, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(156, 39, 176, 0.2);
                background-color: #9c27b0;
            }

        .jss814 {
            box-shadow: 0 2px 2px 0 rgba(0, 172, 193, 0.14), 0 3px 1px -2px rgba(0, 172, 193, 0.2), 0 1px 5px 0 rgba(0, 172, 193, 0.12);
            background-color: #00acc1;
        }

            .jss814:hover, .jss814:focus {
                box-shadow: 0 14px 26px -12px rgba(0, 172, 193, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 172, 193, 0.2);
                background-color: #00acc1;
            }

        .jss815 {
            box-shadow: 0 2px 2px 0 rgba(76, 175, 80, 0.14), 0 3px 1px -2px rgba(76, 175, 80, 0.2), 0 1px 5px 0 rgba(76, 175, 80, 0.12);
            background-color: #4caf50;
        }

            .jss815:hover, .jss815:focus {
                box-shadow: 0 14px 26px -12px rgba(76, 175, 80, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(76, 175, 80, 0.2);
                background-color: #4caf50;
            }

        .jss816 {
            box-shadow: 0 2px 2px 0 rgba(255, 152, 0, 0.14), 0 3px 1px -2px rgba(255, 152, 0, 0.2), 0 1px 5px 0 rgba(255, 152, 0, 0.12);
            background-color: #ff9800;
        }

            .jss816:hover, .jss816:focus {
                box-shadow: 0 14px 26px -12px rgba(255, 152, 0, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(255, 152, 0, 0.2);
                background-color: #ff9800;
            }

        .jss817 {
            box-shadow: 0 2px 2px 0 rgba(244, 67, 54, 0.14), 0 3px 1px -2px rgba(244, 67, 54, 0.2), 0 1px 5px 0 rgba(244, 67, 54, 0.12);
            background-color: #f44336;
        }

            .jss817:hover, .jss817:focus {
                box-shadow: 0 14px 26px -12px rgba(244, 67, 54, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(244, 67, 54, 0.2);
                background-color: #f44336;
            }

        .jss818 {
            box-shadow: 0 2px 2px 0 rgba(233, 30, 99, 0.14), 0 3px 1px -2px rgba(233, 30, 99, 0.2), 0 1px 5px 0 rgba(233, 30, 99, 0.12);
            background-color: #e91e63;
        }

            .jss818:hover, .jss818:focus {
                box-shadow: 0 14px 26px -12px rgba(233, 30, 99, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(233, 30, 99, 0.2);
                background-color: #e91e63;
            }

        .jss819, .jss819:focus, .jss819:hover {
            color: #999;
            background-color: #FFF;
        }

        .jss820 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(85, 172, 238, 0.14), 0 3px 1px -2px rgba(85, 172, 238, 0.2), 0 1px 5px 0 rgba(85, 172, 238, 0.12);
            background-color: #55acee;
        }

            .jss820:hover, .jss820:focus, .jss820:visited {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(85, 172, 238, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(85, 172, 238, 0.2);
                background-color: #55acee;
            }

        .jss821 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(59, 89, 152, 0.14), 0 3px 1px -2px rgba(59, 89, 152, 0.2), 0 1px 5px 0 rgba(59, 89, 152, 0.12);
            background-color: #3b5998;
        }

            .jss821:hover, .jss821:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(59, 89, 152, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(59, 89, 152, 0.2);
                background-color: #3b5998;
            }

        .jss822 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(221, 75, 57, 0.14), 0 3px 1px -2px rgba(221, 75, 57, 0.2), 0 1px 5px 0 rgba(221, 75, 57, 0.12);
            background-color: #dd4b39;
        }

            .jss822:hover, .jss822:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(221, 75, 57, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(221, 75, 57, 0.2);
                background-color: #dd4b39;
            }

        .jss823 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(9, 118, 180, 0.14), 0 3px 1px -2px rgba(9, 118, 180, 0.2), 0 1px 5px 0 rgba(9, 118, 180, 0.12);
            background-color: #0976b4;
        }

            .jss823:hover, .jss823:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(9, 118, 180, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(9, 118, 180, 0.2);
                background-color: #0976b4;
            }

        .jss824 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(204, 33, 39, 0.14), 0 3px 1px -2px rgba(204, 33, 39, 0.2), 0 1px 5px 0 rgba(204, 33, 39, 0.12);
            background-color: #cc2127;
        }

            .jss824:hover, .jss824:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(204, 33, 39, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(204, 33, 39, 0.2);
                background-color: #cc2127;
            }

        .jss825 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(229, 45, 39, 0.14), 0 3px 1px -2px rgba(229, 45, 39, 0.2), 0 1px 5px 0 rgba(229, 45, 39, 0.12);
            background-color: #e52d27;
        }

            .jss825:hover, .jss825:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(229, 45, 39, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(229, 45, 39, 0.2);
                background-color: #e52d27;
            }

        .jss826 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(53, 70, 92, 0.14), 0 3px 1px -2px rgba(53, 70, 92, 0.2), 0 1px 5px 0 rgba(53, 70, 92, 0.12);
            background-color: #35465c;
        }

            .jss826:hover, .jss826:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(53, 70, 92, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(53, 70, 92, 0.2);
                background-color: #35465c;
            }

        .jss827 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(85, 85, 85, 0.14), 0 3px 1px -2px rgba(85, 85, 85, 0.2), 0 1px 5px 0 rgba(85, 85, 85, 0.12);
            background-color: #333;
        }

            .jss827:hover, .jss827:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(85, 85, 85, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(85, 85, 85, 0.2);
                background-color: #333;
            }

        .jss828 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(23, 105, 255, 0.14), 0 3px 1px -2px rgba(23, 105, 255, 0.2), 0 1px 5px 0 rgba(23, 105, 255, 0.12);
            background-color: #1769ff;
        }

            .jss828:hover, .jss828:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(23, 105, 255, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(23, 105, 255, 0.2);
                background-color: #1769ff;
            }

        .jss829 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(234, 76, 137, 0.14), 0 3px 1px -2px rgba(234, 76, 137, 0.2), 0 1px 5px 0 rgba(234, 76, 137, 0.12);
            background-color: #ea4c89;
        }

            .jss829:hover, .jss829:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(234, 76, 137, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(234, 76, 137, 0.2);
                background-color: #ea4c89;
            }

        .jss830 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(255, 69, 0, 0.14), 0 3px 1px -2px rgba(255, 69, 0, 0.2), 0 1px 5px 0 rgba(255, 69, 0, 0.12);
            background-color: #ff4500;
        }

            .jss830:hover, .jss830:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(255, 69, 0, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(255, 69, 0, 0.2);
                background-color: #ff4500;
            }

        .jss831, .jss831:focus, .jss831:hover {
            color: #FFF;
            background: transparent;
            box-shadow: none;
        }

            .jss831.jss830, .jss831.jss830:focus, .jss831.jss830:hover, .jss831.jss830:visited {
                color: #ff4500;
            }

            .jss831.jss829, .jss831.jss829:focus, .jss831.jss829:hover, .jss831.jss829:visited {
                color: #ea4c89;
            }

            .jss831.jss828, .jss831.jss828:focus, .jss831.jss828:hover, .jss831.jss828:visited {
                color: #1769ff;
            }

            .jss831.jss827, .jss831.jss827:focus, .jss831.jss827:hover, .jss831.jss827:visited {
                color: #333;
            }

            .jss831.jss826, .jss831.jss826:focus, .jss831.jss826:hover, .jss831.jss826:visited {
                color: #35465c;
            }

            .jss831.jss825, .jss831.jss825:focus, .jss831.jss825:hover, .jss831.jss825:visited {
                color: #e52d27;
            }

            .jss831.jss824, .jss831.jss824:focus, .jss831.jss824:hover, .jss831.jss824:visited {
                color: #cc2127;
            }

            .jss831.jss823, .jss831.jss823:focus, .jss831.jss823:hover, .jss831.jss823:visited {
                color: #0976b4;
            }

            .jss831.jss822, .jss831.jss822:focus, .jss831.jss822:hover, .jss831.jss822:visited {
                color: #dd4b39;
            }

            .jss831.jss821, .jss831.jss821:focus, .jss831.jss821:hover, .jss831.jss821:visited {
                color: #3b5998;
            }

            .jss831.jss820, .jss831.jss820:focus, .jss831.jss820:hover, .jss831.jss820:visited {
                color: #55acee;
            }

            .jss831.jss817, .jss831.jss817:focus, .jss831.jss817:hover, .jss831.jss817:visited {
                color: #f44336;
            }

            .jss831.jss818, .jss831.jss818:focus, .jss831.jss818:hover, .jss831.jss818:visited {
                color: #e91e63;
            }

            .jss831.jss816, .jss831.jss816:focus, .jss831.jss816:hover, .jss831.jss816:visited {
                color: #ff9800;
            }

            .jss831.jss815, .jss831.jss815:focus, .jss831.jss815:hover, .jss831.jss815:visited {
                color: #4caf50;
            }

            .jss831.jss814, .jss831.jss814:focus, .jss831.jss814:hover, .jss831.jss814:visited {
                color: #00acc1;
            }

            .jss831.jss813, .jss831.jss813:focus, .jss831.jss813:hover, .jss831.jss813:visited {
                color: #9c27b0;
            }

        .jss832, .jss832:focus, .jss832:hover {
            color: inherit;
            background: transparent;
            box-shadow: none;
        }

        .jss833 {
            opacity: 0.65;
            pointer-events: none;
        }

        .jss834 {
            padding: 1.125rem 2.25rem;
            font-size: 0.875rem;
            line-height: 1.333333;
            border-radius: 0.2rem;
        }

            .jss834.jss839 .fab, .jss834.jss839 .fas, .jss834.jss839 .far, .jss834.jss839 .fal, .jss834.jss839 svg, .jss834.jss839 .material-icons {
                margin-top: -4px;
            }

        .jss835 {
            padding: 0.40625rem 1.25rem;
            font-size: 0.6875rem;
            line-height: 1.5;
            border-radius: 0.2rem;
        }

            .jss835.jss839 .fab, .jss835.jss839 .fas, .jss835.jss839 .far, .jss835.jss839 .fal, .jss835.jss839 svg, .jss835.jss839 .material-icons {
                margin-top: 1px;
            }

        .jss836 {
            border-radius: 30px;
        }

        .jss837 {
            width: 100% !important;
        }

        .jss838, .jss838:hover, .jss838:focus {
            color: #999;
            box-shadow: none;
            background-color: transparent;
        }

        .jss839 {
            width: 41px;
            height: 41px;
            font-size: 20px;
            min-width: 41px;
            padding-left: 12px;
            padding-right: 12px;
        }

            .jss839 .fab, .jss839 .fas, .jss839 .far, .jss839 .fal, .jss839 svg, .jss839 .material-icons {
                margin-right: 0px;
            }

            .jss839.jss834 {
                width: 57px;
                height: 57px;
                min-width: 57px;
                line-height: 56px;
            }

            .jss839.jss835 {
                width: 30px;
                height: 30px;
                min-width: 30px;
            }

                .jss839.jss835 .fab, .jss839.jss835 .fas, .jss839.jss835 .far, .jss839.jss835 .fal, .jss839.jss835 .material-icons {
                    font-size: 17px;
                    line-height: 29px;
                }

                .jss839.jss835 svg {
                    width: 17px;
                    height: 17px;
                }

            .jss839.jss834 .fab, .jss839.jss834 .fas, .jss839.jss834 .far, .jss839.jss834 .fal, .jss839.jss834 .material-icons {
                font-size: 32px;
                line-height: 56px;
            }

            .jss839.jss834 svg {
                width: 32px;
                height: 32px;
            }

        .jss840 {
            color: #FFF;
            border: none;
            cursor: pointer;
            margin: .3125rem 1px;
            padding: 12px 30px;
            position: relative;
            font-size: 12px;
            min-width: auto;
            box-shadow: 0 2px 2px 0 rgba(153, 153, 153, 0.14), 0 3px 1px -2px rgba(153, 153, 153, 0.2), 0 1px 5px 0 rgba(153, 153, 153, 0.12);
            min-height: auto;
            text-align: center;
            transition: box-shadow 0.2s cubic-bezier(0.4, 0, 1, 1), background-color 0.2s cubic-bezier(0.4, 0, 0.2, 1);
            font-weight: 400;
            line-height: 1.42857143;
            white-space: nowrap;
            will-change: box-shadow, transform;
            touch-action: manipulation;
            border-radius: 3px;
            letter-spacing: 0;
            text-transform: uppercase;
            vertical-align: middle;
            background-color: #999;
        }

            .jss840:hover, .jss840:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(153, 153, 153, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(153, 153, 153, 0.2);
                background-color: #999;
            }

            .jss840 .fab, .jss840 .fas, .jss840 .far, .jss840 .fal, .jss840 .material-icons {
                top: 0;
                display: inline-block;
                position: relative;
                font-size: 1.1rem;
                margin-top: -1em;
                margin-right: 4px;
                margin-bottom: -1em;
                vertical-align: middle;
            }

            .jss840 svg {
                top: 0;
                width: 18px;
                height: 18px;
                display: inline-block;
                position: relative;
                margin-right: 4px;
                vertical-align: middle;
            }

            .jss840.jss868 .fab, .jss840.jss868 .fas, .jss840.jss868 .far, .jss840.jss868 .fal, .jss840.jss868 .material-icons {
                top: 0px;
                left: 0px;
                width: 100%;
                height: 100%;
                position: absolute;
                font-size: 20px;
                transform: none;
                margin-top: 0px;
                line-height: 41px;
            }

        .jss841 {
            width: 100%;
        }

        .jss842 {
            box-shadow: 0 2px 2px 0 rgba(156, 39, 176, 0.14), 0 3px 1px -2px rgba(156, 39, 176, 0.2), 0 1px 5px 0 rgba(156, 39, 176, 0.12);
            background-color: #9c27b0;
        }

            .jss842:hover, .jss842:focus {
                box-shadow: 0 14px 26px -12px rgba(156, 39, 176, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(156, 39, 176, 0.2);
                background-color: #9c27b0;
            }

        .jss843 {
            box-shadow: 0 2px 2px 0 rgba(0, 172, 193, 0.14), 0 3px 1px -2px rgba(0, 172, 193, 0.2), 0 1px 5px 0 rgba(0, 172, 193, 0.12);
            background-color: #00acc1;
        }

            .jss843:hover, .jss843:focus {
                box-shadow: 0 14px 26px -12px rgba(0, 172, 193, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 172, 193, 0.2);
                background-color: #00acc1;
            }

        .jss844 {
            box-shadow: 0 2px 2px 0 rgba(76, 175, 80, 0.14), 0 3px 1px -2px rgba(76, 175, 80, 0.2), 0 1px 5px 0 rgba(76, 175, 80, 0.12);
            background-color: #4caf50;
        }

            .jss844:hover, .jss844:focus {
                box-shadow: 0 14px 26px -12px rgba(76, 175, 80, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(76, 175, 80, 0.2);
                background-color: #4caf50;
            }

        .jss845 {
            box-shadow: 0 2px 2px 0 rgba(255, 152, 0, 0.14), 0 3px 1px -2px rgba(255, 152, 0, 0.2), 0 1px 5px 0 rgba(255, 152, 0, 0.12);
            background-color: #ff9800;
        }

            .jss845:hover, .jss845:focus {
                box-shadow: 0 14px 26px -12px rgba(255, 152, 0, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(255, 152, 0, 0.2);
                background-color: #ff9800;
            }

        .jss846 {
            box-shadow: 0 2px 2px 0 rgba(244, 67, 54, 0.14), 0 3px 1px -2px rgba(244, 67, 54, 0.2), 0 1px 5px 0 rgba(244, 67, 54, 0.12);
            background-color: #f44336;
        }

            .jss846:hover, .jss846:focus {
                box-shadow: 0 14px 26px -12px rgba(244, 67, 54, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(244, 67, 54, 0.2);
                background-color: #f44336;
            }

        .jss847 {
            box-shadow: 0 2px 2px 0 rgba(233, 30, 99, 0.14), 0 3px 1px -2px rgba(233, 30, 99, 0.2), 0 1px 5px 0 rgba(233, 30, 99, 0.12);
            background-color: #e91e63;
        }

            .jss847:hover, .jss847:focus {
                box-shadow: 0 14px 26px -12px rgba(233, 30, 99, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(233, 30, 99, 0.2);
                background-color: #e91e63;
            }

        .jss848, .jss848:focus, .jss848:hover {
            color: #999;
            background-color: #FFF;
        }

        .jss849 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(85, 172, 238, 0.14), 0 3px 1px -2px rgba(85, 172, 238, 0.2), 0 1px 5px 0 rgba(85, 172, 238, 0.12);
            background-color: #55acee;
        }

            .jss849:hover, .jss849:focus, .jss849:visited {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(85, 172, 238, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(85, 172, 238, 0.2);
                background-color: #55acee;
            }

        .jss850 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(59, 89, 152, 0.14), 0 3px 1px -2px rgba(59, 89, 152, 0.2), 0 1px 5px 0 rgba(59, 89, 152, 0.12);
            background-color: #3b5998;
        }

            .jss850:hover, .jss850:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(59, 89, 152, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(59, 89, 152, 0.2);
                background-color: #3b5998;
            }

        .jss851 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(221, 75, 57, 0.14), 0 3px 1px -2px rgba(221, 75, 57, 0.2), 0 1px 5px 0 rgba(221, 75, 57, 0.12);
            background-color: #dd4b39;
        }

            .jss851:hover, .jss851:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(221, 75, 57, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(221, 75, 57, 0.2);
                background-color: #dd4b39;
            }

        .jss852 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(9, 118, 180, 0.14), 0 3px 1px -2px rgba(9, 118, 180, 0.2), 0 1px 5px 0 rgba(9, 118, 180, 0.12);
            background-color: #0976b4;
        }

            .jss852:hover, .jss852:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(9, 118, 180, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(9, 118, 180, 0.2);
                background-color: #0976b4;
            }

        .jss853 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(204, 33, 39, 0.14), 0 3px 1px -2px rgba(204, 33, 39, 0.2), 0 1px 5px 0 rgba(204, 33, 39, 0.12);
            background-color: #cc2127;
        }

            .jss853:hover, .jss853:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(204, 33, 39, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(204, 33, 39, 0.2);
                background-color: #cc2127;
            }

        .jss854 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(229, 45, 39, 0.14), 0 3px 1px -2px rgba(229, 45, 39, 0.2), 0 1px 5px 0 rgba(229, 45, 39, 0.12);
            background-color: #e52d27;
        }

            .jss854:hover, .jss854:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(229, 45, 39, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(229, 45, 39, 0.2);
                background-color: #e52d27;
            }

        .jss855 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(53, 70, 92, 0.14), 0 3px 1px -2px rgba(53, 70, 92, 0.2), 0 1px 5px 0 rgba(53, 70, 92, 0.12);
            background-color: #35465c;
        }

            .jss855:hover, .jss855:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(53, 70, 92, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(53, 70, 92, 0.2);
                background-color: #35465c;
            }

        .jss856 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(85, 85, 85, 0.14), 0 3px 1px -2px rgba(85, 85, 85, 0.2), 0 1px 5px 0 rgba(85, 85, 85, 0.12);
            background-color: #333;
        }

            .jss856:hover, .jss856:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(85, 85, 85, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(85, 85, 85, 0.2);
                background-color: #333;
            }

        .jss857 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(23, 105, 255, 0.14), 0 3px 1px -2px rgba(23, 105, 255, 0.2), 0 1px 5px 0 rgba(23, 105, 255, 0.12);
            background-color: #1769ff;
        }

            .jss857:hover, .jss857:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(23, 105, 255, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(23, 105, 255, 0.2);
                background-color: #1769ff;
            }

        .jss858 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(234, 76, 137, 0.14), 0 3px 1px -2px rgba(234, 76, 137, 0.2), 0 1px 5px 0 rgba(234, 76, 137, 0.12);
            background-color: #ea4c89;
        }

            .jss858:hover, .jss858:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(234, 76, 137, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(234, 76, 137, 0.2);
                background-color: #ea4c89;
            }

        .jss859 {
            color: #FFF;
            box-shadow: 0 2px 2px 0 rgba(255, 69, 0, 0.14), 0 3px 1px -2px rgba(255, 69, 0, 0.2), 0 1px 5px 0 rgba(255, 69, 0, 0.12);
            background-color: #ff4500;
        }

            .jss859:hover, .jss859:focus {
                color: #FFF;
                box-shadow: 0 14px 26px -12px rgba(255, 69, 0, 0.42), 0 4px 23px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(255, 69, 0, 0.2);
                background-color: #ff4500;
            }

        .jss860, .jss860:focus, .jss860:hover {
            color: #FFF;
            background: transparent;
            box-shadow: none;
        }

            .jss860.jss859, .jss860.jss859:focus, .jss860.jss859:hover, .jss860.jss859:visited {
                color: #ff4500;
            }

            .jss860.jss858, .jss860.jss858:focus, .jss860.jss858:hover, .jss860.jss858:visited {
                color: #ea4c89;
            }

            .jss860.jss857, .jss860.jss857:focus, .jss860.jss857:hover, .jss860.jss857:visited {
                color: #1769ff;
            }

            .jss860.jss856, .jss860.jss856:focus, .jss860.jss856:hover, .jss860.jss856:visited {
                color: #333;
            }

            .jss860.jss855, .jss860.jss855:focus, .jss860.jss855:hover, .jss860.jss855:visited {
                color: #35465c;
            }

            .jss860.jss854, .jss860.jss854:focus, .jss860.jss854:hover, .jss860.jss854:visited {
                color: #e52d27;
            }

            .jss860.jss853, .jss860.jss853:focus, .jss860.jss853:hover, .jss860.jss853:visited {
                color: #cc2127;
            }

            .jss860.jss852, .jss860.jss852:focus, .jss860.jss852:hover, .jss860.jss852:visited {
                color: #0976b4;
            }

            .jss860.jss851, .jss860.jss851:focus, .jss860.jss851:hover, .jss860.jss851:visited {
                color: #dd4b39;
            }

            .jss860.jss850, .jss860.jss850:focus, .jss860.jss850:hover, .jss860.jss850:visited {
                color: #3b5998;
            }

            .jss860.jss849, .jss860.jss849:focus, .jss860.jss849:hover, .jss860.jss849:visited {
                color: #55acee;
            }

            .jss860.jss846, .jss860.jss846:focus, .jss860.jss846:hover, .jss860.jss846:visited {
                color: #f44336;
            }

            .jss860.jss847, .jss860.jss847:focus, .jss860.jss847:hover, .jss860.jss847:visited {
                color: #e91e63;
            }

            .jss860.jss845, .jss860.jss845:focus, .jss860.jss845:hover, .jss860.jss845:visited {
                color: #ff9800;
            }

            .jss860.jss844, .jss860.jss844:focus, .jss860.jss844:hover, .jss860.jss844:visited {
                color: #4caf50;
            }

            .jss860.jss843, .jss860.jss843:focus, .jss860.jss843:hover, .jss860.jss843:visited {
                color: #00acc1;
            }

            .jss860.jss842, .jss860.jss842:focus, .jss860.jss842:hover, .jss860.jss842:visited {
                color: #9c27b0;
            }

        .jss861, .jss861:focus, .jss861:hover {
            color: inherit;
            background: transparent;
            box-shadow: none;
        }

        .jss862 {
            opacity: 0.65;
            pointer-events: none;
        }

        .jss863 {
            padding: 1.125rem 2.25rem;
            font-size: 0.875rem;
            line-height: 1.333333;
            border-radius: 0.2rem;
        }

            .jss863.jss868 .fab, .jss863.jss868 .fas, .jss863.jss868 .far, .jss863.jss868 .fal, .jss863.jss868 svg, .jss863.jss868 .material-icons {
                margin-top: -4px;
            }

        .jss864 {
            padding: 0.40625rem 1.25rem;
            font-size: 0.6875rem;
            line-height: 1.5;
            border-radius: 0.2rem;
        }

            .jss864.jss868 .fab, .jss864.jss868 .fas, .jss864.jss868 .far, .jss864.jss868 .fal, .jss864.jss868 svg, .jss864.jss868 .material-icons {
                margin-top: 1px;
            }

        .jss865 {
            border-radius: 30px;
        }

        .jss866 {
            width: 100% !important;
        }

        .jss867, .jss867:hover, .jss867:focus {
            color: #999;
            box-shadow: none;
            background-color: transparent;
        }

        .jss868 {
            width: 41px;
            height: 41px;
            font-size: 20px;
            min-width: 41px;
            padding-left: 12px;
            padding-right: 12px;
        }

            .jss868 .fab, .jss868 .fas, .jss868 .far, .jss868 .fal, .jss868 svg, .jss868 .material-icons {
                margin-right: 0px;
            }

            .jss868.jss863 {
                width: 57px;
                height: 57px;
                min-width: 57px;
                line-height: 56px;
            }

            .jss868.jss864 {
                width: 30px;
                height: 30px;
                min-width: 30px;
            }

                .jss868.jss864 .fab, .jss868.jss864 .fas, .jss868.jss864 .far, .jss868.jss864 .fal, .jss868.jss864 .material-icons {
                    font-size: 17px;
                    line-height: 29px;
                }

                .jss868.jss864 svg {
                    width: 17px;
                    height: 17px;
                }

            .jss868.jss863 .fab, .jss868.jss863 .fas, .jss868.jss863 .far, .jss868.jss863 .fal, .jss868.jss863 .material-icons {
                font-size: 32px;
                line-height: 56px;
            }

            .jss868.jss863 svg {
                width: 32px;
                height: 32px;
            }
    </style>


    <style>
        .loader_cls {
            z-index: 1000;
            background: #fcfefc;
            opacity: 1;
        }

        .hidden {
            display: none !important;
        }
    </style>

    <div class="bg-overlay loader_cls">
        <section class="fullscreen">
            <div class="container-fullwidth">
                <div class="row justify-content-center p-60">
                    <div class="col-md-12 text-center">
                        <img class="h-100 w-100" src="Images/loader.gif" id="imgLoader" />
                    </div>
                </div>
            </div>
        </section>
    </div>

    <div class="container-fluid py-4 hidden">
        <div class="row">
            <div class="col-md-12 text-center">
                <h6 class="mb-0">Team Members List</h6>
            </div>
        </div>

        <div class="col-lg-9 col-12 mx-auto">
            <div class=" card-body" id="div_team">
                <%--id="div_team"--%>
                
            </div>
        </div>
    </div>


    <script src="assets/js/jquery.js"></script>
    <script src="assets/js/plugins.js"></script>
    <script src="assets/js/prop/commondatastore.js"></script>

    <script>

        $(function () {
            $('.genealogy-tree ul').hide();
            $('.genealogy-tree>ul').show();
            $('.genealogy-tree ul.active').show();
            $('.genealogy-tree li').on('click', function (e) {

                var children = $(this).find('> ul');
                if (children.is(":visible")) children.hide('fast').removeClass('active');
                else children.show('fast').addClass('active');
                e.stopPropagation();
            });
        });

    </script>
    <script src="AppScripts/MgrDashboard.js"></script>
</asp:Content>