<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitingApp.Master" AutoEventWireup="true" CodeBehind="Superadmin_Userprofile.aspx.cs" Inherits="Recruiting_API.Superadmin_Userprofile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="assets/css/Common.css" rel="stylesheet" />

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

    <main class="main-content max-height-vh-100 h-100">

        <div class="container-fluid my-3 py-3 hidden">
            <div class="row mb-5">
                <div class="col-lg-3">
                    <div class="card position-sticky top-1">
                        <ul class="nav flex-column bg-white border-radius-lg p-3">
                            <li class="nav-item pt-2">
                                <a class="nav-link text-body" data-scroll="" href="#div_Basicinfo">
                                    <div class="icon me-2">
                                        <svg class="text-dark mb-1" width="16px" height="16px" viewBox="0 0 40 44" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink">
                                            <title>document</title>
                                            <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                                <g transform="translate(-1870.000000, -591.000000)" fill="#FFFFFF" fill-rule="nonzero">
                                                    <g transform="translate(1716.000000, 291.000000)">
                                                        <g transform="translate(154.000000, 300.000000)">
                                                            <path class="color-background" d="M40,40 L36.3636364,40 L36.3636364,3.63636364 L5.45454545,3.63636364 L5.45454545,0 L38.1818182,0 C39.1854545,0 40,0.814545455 40,1.81818182 L40,40 Z" opacity="0.603585379"></path>
                                                            <path class="color-background" d="M30.9090909,7.27272727 L1.81818182,7.27272727 C0.814545455,7.27272727 0,8.08727273 0,9.09090909 L0,41.8181818 C0,42.8218182 0.814545455,43.6363636 1.81818182,43.6363636 L30.9090909,43.6363636 C31.9127273,43.6363636 32.7272727,42.8218182 32.7272727,41.8181818 L32.7272727,9.09090909 C32.7272727,8.08727273 31.9127273,7.27272727 30.9090909,7.27272727 Z M18.1818182,34.5454545 L7.27272727,34.5454545 L7.27272727,30.9090909 L18.1818182,30.9090909 L18.1818182,34.5454545 Z M25.4545455,27.2727273 L7.27272727,27.2727273 L7.27272727,23.6363636 L25.4545455,23.6363636 L25.4545455,27.2727273 Z M25.4545455,20 L7.27272727,20 L7.27272727,16.3636364 L25.4545455,16.3636364 L25.4545455,20 Z"></path>
                                                        </g>
                                                    </g>
                                                </g>
                                            </g>
                                        </svg>
                                    </div>
                                    <span class="text-sm">Basic Info</span>
                                </a>
                            </li>

                            <li class="nav-item pt-2">
                                <a class="nav-link text-body" data-scroll="" href="#div_Supportaccesss">
                                    <div class="icon me-2">
                                        <svg class="text-dark mb-1" width="16px" height="16px" viewBox="0 0 40 44" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink">
                                            <title>switches</title>
                                            <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                                <g transform="translate(-1870.000000, -440.000000)" fill="#FFFFFF" fill-rule="nonzero">
                                                    <g transform="translate(1716.000000, 291.000000)">
                                                        <g transform="translate(154.000000, 149.000000)">
                                                            <path class="color-background" d="M10,20 L30,20 C35.4545455,20 40,15.4545455 40,10 C40,4.54545455 35.4545455,0 30,0 L10,0 C4.54545455,0 0,4.54545455 0,10 C0,15.4545455 4.54545455,20 10,20 Z M10,3.63636364 C13.4545455,3.63636364 16.3636364,6.54545455 16.3636364,10 C16.3636364,13.4545455 13.4545455,16.3636364 10,16.3636364 C6.54545455,16.3636364 3.63636364,13.4545455 3.63636364,10 C3.63636364,6.54545455 6.54545455,3.63636364 10,3.63636364 Z" opacity="0.6"></path>
                                                            <path class="color-background" d="M30,23.6363636 L10,23.6363636 C4.54545455,23.6363636 0,28.1818182 0,33.6363636 C0,39.0909091 4.54545455,43.6363636 10,43.6363636 L30,43.6363636 C35.4545455,43.6363636 40,39.0909091 40,33.6363636 C40,28.1818182 35.4545455,23.6363636 30,23.6363636 Z M30,40 C26.5454545,40 23.6363636,37.0909091 23.6363636,33.6363636 C23.6363636,30.1818182 26.5454545,27.2727273 30,27.2727273 C33.4545455,27.2727273 36.3636364,30.1818182 36.3636364,33.6363636 C36.3636364,37.0909091 33.4545455,40 30,40 Z"></path>
                                                        </g>
                                                    </g>
                                                </g>
                                            </g>
                                        </svg>
                                    </div>
                                    <span class="text-sm">Support Accesss</span>
                                </a>
                            </li>
                            <li class="nav-item pt-2">
                                <a class="nav-link text-body" data-scroll="" href="#div_Accounts">
                                    <div class="icon me-2">
                                        <svg class="text-dark mb-1" width="16px" height="16px" viewBox="0 0 42 44" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink">
                                            <title>time-alarm</title>
                                            <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                                <g transform="translate(-2319.000000, -440.000000)" fill="#923DFA" fill-rule="nonzero">
                                                    <g transform="translate(1716.000000, 291.000000)">
                                                        <g transform="translate(603.000000, 149.000000)">
                                                            <path class="color-background" d="M18.8086957,4.70034783 C15.3814926,0.343541521 9.0713063,-0.410050841 4.7145,3.01715217 C0.357693695,6.44435519 -0.395898667,12.7545415 3.03130435,17.1113478 C5.53738466,10.3360568 11.6337901,5.54042955 18.8086957,4.70034783 L18.8086957,4.70034783 Z" opacity="0.6"></path>
                                                            <path class="color-background" d="M38.9686957,17.1113478 C42.3958987,12.7545415 41.6423063,6.44435519 37.2855,3.01715217 C32.9286937,-0.410050841 26.6185074,0.343541521 23.1913043,4.70034783 C30.3662099,5.54042955 36.4626153,10.3360568 38.9686957,17.1113478 Z" opacity="0.6"></path>
                                                            <path class="color-background" d="M34.3815652,34.7668696 C40.2057958,27.7073059 39.5440671,17.3375603 32.869743,11.0755718 C26.1954189,4.81358341 15.8045811,4.81358341 9.13025701,11.0755718 C2.45593289,17.3375603 1.79420418,27.7073059 7.61843478,34.7668696 L3.9753913,40.0506522 C3.58549114,40.5871271 3.51710058,41.2928217 3.79673036,41.8941824 C4.07636014,42.4955431 4.66004722,42.8980248 5.32153275,42.9456105 C5.98301828,42.9931963 6.61830436,42.6784048 6.98113043,42.1232609 L10.2744783,37.3434783 C16.5555112,42.3298213 25.4444888,42.3298213 31.7255217,37.3434783 L35.0188696,42.1196087 C35.6014207,42.9211577 36.7169135,43.1118605 37.53266,42.5493622 C38.3484064,41.9868639 38.5667083,40.8764423 38.0246087,40.047 L34.3815652,34.7668696 Z M30.1304348,25.5652174 L21,25.5652174 C20.49574,25.5652174 20.0869565,25.1564339 20.0869565,24.6521739 L20.0869565,15.5217391 C20.0869565,15.0174791 20.49574,14.6086957 21,14.6086957 C21.50426,14.6086957 21.9130435,15.0174791 21.9130435,15.5217391 L21.9130435,23.7391304 L30.1304348,23.7391304 C30.6346948,23.7391304 31.0434783,24.1479139 31.0434783,24.6521739 C31.0434783,25.1564339 30.6346948,25.5652174 30.1304348,25.5652174 Z"></path>
                                                        </g>
                                                    </g>
                                                </g>
                                            </g>
                                        </svg>
                                    </div>
                                    <span class="text-sm">Accounts</span>
                                </a>
                            </li>
                            <li class="nav-item pt-2">
                                <a class="nav-link text-body" data-scroll="" href="#div_Notifications">
                                    <div class="icon me-2">
                                        <svg class="text-dark mb-1" width="16px" height="16px" viewBox="0 0 44 43" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink">
                                            <title>megaphone</title>
                                            <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                                <g transform="translate(-2168.000000, -591.000000)" fill="#FFFFFF" fill-rule="nonzero">
                                                    <g transform="translate(1716.000000, 291.000000)">
                                                        <g transform="translate(452.000000, 300.000000)">
                                                            <path class="color-background" d="M35.7958333,0.273166667 C35.2558424,-0.0603712374 34.5817509,-0.0908856664 34.0138333,0.1925 L19.734,7.33333333 L9.16666667,7.33333333 C4.10405646,7.33333333 0,11.4373898 0,16.5 C0,21.5626102 4.10405646,25.6666667 9.16666667,25.6666667 L19.734,25.6666667 L34.0138333,32.8166667 C34.5837412,33.1014624 35.2606401,33.0699651 35.8016385,32.7334768 C36.3426368,32.3969885 36.6701539,31.8037627 36.6666942,31.1666667 L36.6666942,1.83333333 C36.6666942,1.19744715 36.3370375,0.607006911 35.7958333,0.273166667 Z"></path>
                                                            <path class="color-background" d="M38.5,11 L38.5,22 C41.5375661,22 44,19.5375661 44,16.5 C44,13.4624339 41.5375661,11 38.5,11 Z" opacity="0.601050967"></path>
                                                            <path class="color-background" d="M18.5936667,29.3333333 L10.6571667,29.3333333 L14.9361667,39.864 C15.7423448,41.6604248 17.8234451,42.4993948 19.6501416,41.764381 C21.4768381,41.0293672 22.3968823,38.982817 21.7341667,37.1286667 L18.5936667,29.3333333 Z" opacity="0.601050967"></path>
                                                        </g>
                                                    </g>
                                                </g>
                                            </g>
                                        </svg>
                                    </div>
                                    <span class="text-sm">Notifications</span>
                                </a>
                            </li>
                            <li class="nav-item pt-2">
                                <a class="nav-link text-body" data-scroll="" href="#div_Targetfixing">
                                    <div class="icon me-2">
                                        <svg class="text-dark mb-1" width="16px" height="16px" viewBox="0 0 40 40" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink">
                                            <title>settings</title>
                                            <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                                <g transform="translate(-2020.000000, -442.000000)" fill="#FFFFFF" fill-rule="nonzero">
                                                    <g transform="translate(1716.000000, 291.000000)">
                                                        <g transform="translate(304.000000, 151.000000)">
                                                            <polygon class="color-background" opacity="0.596981957" points="18.0883333 15.7316667 11.1783333 8.82166667 13.3333333 6.66666667 6.66666667 0 0 6.66666667 6.66666667 13.3333333 8.82166667 11.1783333 15.315 17.6716667"></polygon>
                                                            <path class="color-background" d="M31.5666667,23.2333333 C31.0516667,23.2933333 30.53,23.3333333 30,23.3333333 C29.4916667,23.3333333 28.9866667,23.3033333 28.48,23.245 L22.4116667,30.7433333 L29.9416667,38.2733333 C32.2433333,40.575 35.9733333,40.575 38.275,38.2733333 L38.275,38.2733333 C40.5766667,35.9716667 40.5766667,32.2416667 38.275,29.94 L31.5666667,23.2333333 Z" opacity="0.596981957"></path>
                                                            <path class="color-background" d="M33.785,11.285 L28.715,6.215 L34.0616667,0.868333333 C32.82,0.315 31.4483333,0 30,0 C24.4766667,0 20,4.47666667 20,10 C20,10.99 20.1483333,11.9433333 20.4166667,12.8466667 L2.435,27.3966667 C0.95,28.7083333 0.0633333333,30.595 0.00333333333,32.5733333 C-0.0583333333,34.5533333 0.71,36.4916667 2.11,37.89 C3.47,39.2516667 5.27833333,40 7.20166667,40 C9.26666667,40 11.2366667,39.1133333 12.6033333,37.565 L27.1533333,19.5833333 C28.0566667,19.8516667 29.01,20 30,20 C35.5233333,20 40,15.5233333 40,10 C40,8.55166667 39.685,7.18 39.1316667,5.93666667 L33.785,11.285 Z"></path>
                                                        </g>
                                                    </g>
                                                </g>
                                            </g>
                                        </svg>
                                    </div>
                                    <span class="text-sm">Target Fixing</span>
                                </a>
                            </li>

                            <li class="nav-item pt-2">
                                <a class="nav-link text-body" data-scroll="" href="#div_Changepassword">
                                    <div class="icon me-2">
                                        <svg class="text-dark mb-1" width="16px" height="16px" viewBox="0 0 42 42" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink">
                                            <title>box-3d-50</title>
                                            <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                                <g transform="translate(-2319.000000, -291.000000)" fill="#FFFFFF" fill-rule="nonzero">
                                                    <g transform="translate(1716.000000, 291.000000)">
                                                        <g transform="translate(603.000000, 0.000000)">
                                                            <path class="color-background" d="M22.7597136,19.3090182 L38.8987031,11.2395234 C39.3926816,10.9925342 39.592906,10.3918611 39.3459167,9.89788265 C39.249157,9.70436312 39.0922432,9.5474453 38.8987261,9.45068056 L20.2741875,0.1378125 L20.2741875,0.1378125 C19.905375,-0.04725 19.469625,-0.04725 19.0995,0.1378125 L3.1011696,8.13815822 C2.60720568,8.38517662 2.40701679,8.98586148 2.6540352,9.4798254 C2.75080129,9.67332903 2.90771305,9.83023153 3.10122239,9.9269862 L21.8652864,19.3090182 C22.1468139,19.4497819 22.4781861,19.4497819 22.7597136,19.3090182 Z"></path>
                                                            <path class="color-background" d="M23.625,22.429159 L23.625,39.8805372 C23.625,40.4328219 24.0727153,40.8805372 24.625,40.8805372 C24.7802551,40.8805372 24.9333778,40.8443874 25.0722402,40.7749511 L41.2741875,32.673375 L41.2741875,32.673375 C41.719125,32.4515625 42,31.9974375 42,31.5 L42,14.241659 C42,13.6893742 41.5522847,13.241659 41,13.241659 C40.8447549,13.241659 40.6916418,13.2778041 40.5527864,13.3472318 L24.1777864,21.5347318 C23.8390024,21.7041238 23.625,22.0503869 23.625,22.429159 Z" opacity="0.7"></path>
                                                            <path class="color-background" d="M20.4472136,21.5347318 L1.4472136,12.0347318 C0.953235098,11.7877425 0.352562058,11.9879669 0.105572809,12.4819454 C0.0361450918,12.6208008 6.47121774e-16,12.7739139 0,12.929159 L0,30.1875 L0,30.1875 C0,30.6849375 0.280875,31.1390625 0.7258125,31.3621875 L19.5528096,40.7750766 C20.0467945,41.0220531 20.6474623,40.8218132 20.8944388,40.3278283 C20.963859,40.1889789 21,40.0358742 21,39.8806379 L21,22.429159 C21,22.0503869 20.7859976,21.7041238 20.4472136,21.5347318 Z" opacity="0.7"></path>
                                                        </g>
                                                    </g>
                                                </g>
                                            </g>
                                        </svg>
                                    </div>
                                    <span class="text-sm">Change Password</span>
                                </a>
                            </li>

                            <li class="nav-item pt-2">
                                <a class="nav-link text-body" data-scroll="" href="#div_Deleteaccount">
                                    <div class="icon me-2">
                                        <svg class="text-dark mb-1" width="16px" height="16px" viewBox="0 0 45 40" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink">
                                            <title>shop </title>
                                            <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                                <g transform="translate(-1716.000000, -439.000000)" fill="#FFFFFF" fill-rule="nonzero">
                                                    <g transform="translate(1716.000000, 291.000000)">
                                                        <g transform="translate(0.000000, 148.000000)">
                                                            <path class="color-background" d="M46.7199583,10.7414583 L40.8449583,0.949791667 C40.4909749,0.360605034 39.8540131,0 39.1666667,0 L7.83333333,0 C7.1459869,0 6.50902508,0.360605034 6.15504167,0.949791667 L0.280041667,10.7414583 C0.0969176761,11.0460037 -1.23209662e-05,11.3946378 -1.23209662e-05,11.75 C-0.00758042603,16.0663731 3.48367543,19.5725301 7.80004167,19.5833333 L7.81570833,19.5833333 C9.75003686,19.5882688 11.6168794,18.8726691 13.0522917,17.5760417 C16.0171492,20.2556967 20.5292675,20.2556967 23.494125,17.5760417 C26.4604562,20.2616016 30.9794188,20.2616016 33.94575,17.5760417 C36.2421905,19.6477597 39.5441143,20.1708521 42.3684437,18.9103691 C45.1927731,17.649886 47.0084685,14.8428276 47.0000295,11.75 C47.0000295,11.3946378 46.9030823,11.0460037 46.7199583,10.7414583 Z" opacity="0.598981585"></path>
                                                            <path class="color-foreground" d="M39.198,22.4912623 C37.3776246,22.4928106 35.5817531,22.0149171 33.951625,21.0951667 L33.92225,21.1107282 C31.1430221,22.6838032 27.9255001,22.9318916 24.9844167,21.7998837 C24.4750389,21.605469 23.9777983,21.3722567 23.4960833,21.1018359 L23.4745417,21.1129513 C20.6961809,22.6871153 17.4786145,22.9344611 14.5386667,21.7998837 C14.029926,21.6054643 13.533337,21.3722507 13.0522917,21.1018359 C11.4250962,22.0190609 9.63246555,22.4947009 7.81570833,22.4912623 C7.16510551,22.4842162 6.51607673,22.4173045 5.875,22.2911849 L5.875,44.7220845 C5.875,45.9498589 6.7517757,46.9451667 7.83333333,46.9451667 L19.5833333,46.9451667 L19.5833333,33.6066734 L27.4166667,33.6066734 L27.4166667,46.9451667 L39.1666667,46.9451667 C40.2482243,46.9451667 41.125,45.9498589 41.125,44.7220845 L41.125,22.2822926 C40.4887822,22.4116582 39.8442868,22.4815492 39.198,22.4912623 Z"></path>
                                                        </g>
                                                    </g>
                                                </g>
                                            </g>
                                        </svg>
                                    </div>
                                    <span class="text-sm">Delete Account</span>
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="col-lg-9 mt-lg-0 mt-4">

                    <!-- Card Profile -->
                    <div class="card card-body" id="profile">
                        <div class="row justify-content-center align-items-center">
                            <div class="col-sm-auto col-4">
                                <div class="avatar avatar-xl position-relative">
                                    <img src="../../../assets/img/team-1.jpg" alt="bruce" class="w-100 border-radius-lg shadow-sm">
                                </div>
                                <input type="hidden" id="hdnUserid" />
                            </div>

                            <div class="col-sm-auto ms-sm-auto mt-sm-0 mt-3 d-flex">
                            </div>
                        </div>
                    </div>

                    <!-- Card Basic Info -->
                    <div class="card mt-4" id="div_Basicinfo">
                        <div class="card-header">
                            <h5>Basic Info</h5>
                        </div>
                        <div class="card-body pt-0">
                            <div class="row">
                                <div class="col-6">
                                    <label class="form-label">First Name</label>
                                    <div class="input-group">
                                        <input id="txtFirstName" class="form-control" type="text" placeholder="First Name" required="required">
                                    </div>
                                </div>
                                <div class="col-6">
                                    <label class="form-label">Last Name</label>
                                    <div class="input-group">
                                        <input id="txtLastName" class="form-control" type="text" placeholder="Last Name" required="required">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <label class="form-label mt-4">Gender</label>
                                    <select class="form-control form-controlnew" id="drpGender">
                                    </select>
                                </div>
                                <div class="col-md-6">
                                    <label class="form-label mt-4">Birth Date</label>
                                    <%--<input id="txtDob" class="form-control" type="text" placeholder="Date Of Birth" required="required">--%>
                                    <input class="form-control datepicker" id="txtDob" placeholder="Date Of Birth" type="text" onchange="getDateInfo();">
                                    <input type="hidden" id="hdnstartdate" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6">
                                    <label class="form-label mt-4">Email</label>
                                    <div class="input-group">
                                        <input id="txtemail" class="form-control" type="text" placeholder="example@email.com" autocomplete="off" onblur="ValidateEmail('txtemail');">
                                    </div>
                                </div>
                                <div class="col-6">
                                    <label class="form-label mt-4">Alternate Email</label>
                                    <div class="input-group">
                                        <input id="txtalternateemail" class="form-control" type="email" placeholder="example@email.com">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6">
                                    <label class="form-label mt-4">Location</label>
                                    <div class="input-group">
                                        <input id="txtLocation" class="form-control" type="text" placeholder="Location">
                                    </div>
                                </div>
                                <div class="col-6">
                                    <label class="form-label mt-4">Phone Number</label>
                                    <div class="input-group">
                                        <input id="txtPhoneno" name="phone" class="form-control" type="text" placeholder="+40 735 631 620" onkeypress="return numValidation(this);">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 align-self-center">
                                    <label class="form-label mt-4">Language</label>
                                    <select class="form-control form-controlnew" name="choices-language" id="drpLanguage">
                                    </select>
                                </div>
                                <div class="col-md-6">
                                    <label class="form-label mt-4">Designation</label>
                                    <select class="form-control form-controlnew" name="choices-language" id="drpDesignation">
                                    </select>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-6">
                                    <label class="form-label mt-4">Role</label>
                                    <div class="input-group">
                                        <select class="form-control form-controlnew" name="choices-language" id="drpRole" onchange="getManagerData();">
                                        </select>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <label class="form-label mt-4">Level</label>
                                    <div class="input-group">
                                        <select class="form-control form-controlnew" name="choices-language" id="drpLevel">
                                        </select>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-6">
                                    <label class="form-label mt-4">Reporting Manager</label>
                                    <div class="input-group">
                                        <select class="form-control form-controlnew" name="choices-language" id="drpReportingManager" disabled="disabled">
                                        </select>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <label class="form-label mt-4">Reporting TL</label>
                                    <div class="input-group">
                                        <select class="form-control form-controlnew" name="choices-language" id="drpReportingTL" disabled="disabled">
                                        </select>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>

                    <!-- Card Change Password -->
                    <div class="card mt-4" id="div_Supportaccesss">
                        <div class="card-header d-flex">
                            <h5 class="mb-0">Support Accesss</h5>
                            <span class="badge badge-success ms-auto">Enabled</span>
                        </div>
                        <div class="card-body">
                            <div class="d-flex">
                                <p class="my-auto">Region</p>
                                <p class="text-secondary text-sm ms-auto my-auto me-3"><span id="lblRegion"></span></p>
                                <button class="btn btn-sm btn-outline-dark mb-0" type="button" id="btnRegionadd" data-bs-toggle="modal" data-bs-target="#addregion">Add</button>
                                <button class="btn btn-sm btn-outline-dark mb-0" type="button" id="btnRegionupdate" style="display: none;">Update</button>

                                <input type="hidden" id="hdnRegion" />
                            </div>
                            <hr class="horizontal dark">
                            <div class="d-flex">
                                <p class="my-auto">Monster</p>
                                <p class="text-secondary text-sm ms-auto my-auto me-3"><span id="lblMonster"></span></p>
                                <button class="btn btn-sm btn-outline-dark mb-0" type="button" id="btnMonsteradd" data-bs-toggle="modal" data-bs-target="#addmonster">Add</button>
                                <button class="btn btn-sm btn-outline-dark mb-0" type="button" id="btnMonsterupdate" style="display: none;">update</button>
                            </div>
                            <hr class="horizontal dark">
                            <div class="d-flex">
                                <p class="my-auto">Textnow</p>
                                <p class="text-secondary text-sm ms-auto my-auto me-3"><span id="lblTextnow"></span></p>
                                <button class="btn btn-sm btn-outline-dark mb-0" type="button" id="btnTextnowadd" data-bs-toggle="modal" data-bs-target="#addtextnow">Add</button>
                                <button class="btn btn-sm btn-outline-dark mb-0" type="button" id="btnTextnowupdate" style="display: none;">Update</button>
                            </div>
                        </div>
                    </div>

                    <!-- Card Accounts -->
                    <div class="card mt-4" id="div_Accounts">
                        <div class="card-header">
                            <h5>Accounts</h5>
                            <p class="text-sm">Here you can setup and manage your integration settings.</p>
                        </div>

                        <div class="card-body pt-0">
                            <div class="d-flex">
                                <img class="width-48-px" src="../../../assets/img/small-logos/dashboard.png" alt="logo_slack">
                                <div class="my-auto ms-3">
                                    <div class="h-100">
                                        <h5 class="mb-0">Personalize dashboard</h5>
                                    </div>
                                </div>
                                <p class="text-sm text-secondary ms-auto me-3 my-auto"><span id="lblDashboarlable">Enabled</span></p>
                                <div class="form-check form-switch my-auto">
                                    <input class="form-check-input" checked type="checkbox" id="chkDashboard">
                                </div>

                            </div>
                            <div class="ps-5 pt-3 ms-3">
                                <p class="mb-0 text-sm">You haven't added your Slack yet or you aren't authorized. Please add our Slack Bot to your account by clicking on <a href="javascript">here</a>. When you've added the bot, send your verification code that you have received.</p>

                                <div class="d-sm-flex bg-gray-100 border-radius-lg p-2 my-4">
                                    <p class="text-sm font-weight-bold my-auto ps-sm-2">Team Lead Dashboard</p>
                                    <h6 class="text-sm ms-auto me-3 my-auto"><span id="lblRegionname">US&#160;access</span></h6>
                                </div>


                            </div>
                            <hr class="horizontal dark mt-5">
                            <div class="d-flex">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-8">
                                            <div class="d-flex">
                                                <img class="width-48-px" src="../../../assets/img/small-logos/jobs.png" alt="logo_spotify">
                                                <div class="my-auto ms-3">
                                                    <div class="h-100">
                                                        <h5 class="mb-0">Jobs</h5>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="d-flex">
                                                <p class="text-sm text-secondary ms-auto me-3 my-auto"><span id="lblJobslabel">Enabled</span></p>
                                                <div class="form-check form-switch my-auto">
                                                    <input class="form-check-input" type="checkbox" id="chkJobs">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="d-flex mt-4">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-8">
                                            <div class="d-flex">
                                                <div class="my-auto ms-3">
                                                    <div class="h-100">
                                                        <h6 class="mb-0">Creation</h6>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="d-flex">
                                                <p class="text-sm text-secondary ms-auto me-3 my-auto"><span id="lblCreationlabel">Enabled</span></p>
                                                <div class="form-check form-switch my-auto">
                                                    <input class="form-check-input" type="checkbox" id="chkJobscreation">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="d-flex mt-4">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="d-flex">
                                                <div class="my-auto ms-3">
                                                    <div class="h-100">
                                                        <h6 class="mb-0">Edit</h6>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="d-flex">
                                                <p class="text-sm text-secondary ms-auto me-3 my-auto text-right"><span id="lblEditalljobs">All jobs</span></p>
                                                <div class="form-check form-switch my-auto">
                                                    <input class="form-check-input" type="checkbox" id="chkEditalljobs">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="d-flex">
                                                <p class="text-sm text-secondary ms-auto me-3 my-auto"><span id="lblEditselfcreated">Self Created</span></p>
                                                <div class="form-check form-switch my-auto">
                                                    <input class="form-check-input" type="checkbox" id="chkEditselfcreated">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="d-flex mt-4">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="d-flex">
                                                <div class="my-auto ms-3">
                                                    <div class="h-100">
                                                        <h6 class="mb-0">View</h6>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="d-flex">
                                                <p class="text-sm text-secondary ms-auto me-3 my-auto text-right"><span id="lblViewalljobs">All jobs</span></p>
                                                <div class="form-check form-switch my-auto">
                                                    <input class="form-check-input" type="checkbox" id="chkViewalljobs">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="d-flex">
                                                <p class="text-sm text-secondary ms-auto me-3 my-auto"><span id="lblViewpersonalized">Personalized</span></p>
                                                <div class="form-check form-switch my-auto">
                                                    <input class="form-check-input" type="checkbox" id="chkViewpersonalized">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="d-flex mt-4">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="d-flex">
                                                <div class="my-auto ms-3">
                                                    <div class="h-100">
                                                        <h6 class="mb-0">Feedback</h6>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="d-flex">
                                                <p class="text-sm text-secondary ms-auto me-3 my-auto text-right"><span id="lblFeedbackalljobs">All jobs</span></p>
                                                <div class="form-check form-switch my-auto">
                                                    <input class="form-check-input" type="checkbox" id="chkFeedbackalljobs">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="d-flex">
                                                <p class="text-sm text-secondary ms-auto me-3 my-auto"><span id="lblFeedbackpersonalized">Personalized</span></p>
                                                <div class="form-check form-switch my-auto">
                                                    <input class="form-check-input" type="checkbox" id="chkFeedbackpersonalized">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <hr class="horizontal dark mt-5">
                            <div class="d-flex">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-8">
                                            <div class="d-flex">
                                                <img class="width-48-px" src="../../../assets/img/small-logos/Candidate.png" alt="logo_spotify">
                                                <div class="my-auto ms-3">
                                                    <div class="h-100">
                                                        <h5 class="mb-0">Candidate</h5>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                        </div>
                                        <div class="col-md-2">
                                            <div class="d-flex">
                                                <p class="text-sm text-secondary ms-auto me-3 my-auto"><span id="lblCandidatelable">Enabled</span></p>
                                                <div class="form-check form-switch my-auto">
                                                    <input class="form-check-input" type="checkbox" id="chkCandidate">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="d-flex mt-4">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-8">
                                            <div class="d-flex">
                                                <div class="my-auto ms-3">
                                                    <div class="h-100">
                                                        <h6 class="mb-0">Creation</h6>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="d-flex">
                                                <p class="text-sm text-secondary ms-auto me-3 my-auto"><span id="lblCreation">Enabled</span></p>
                                                <div class="form-check form-switch my-auto">
                                                    <input class="form-check-input" type="checkbox" id="chkCandidatecreation">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="d-flex mt-4">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="d-flex">
                                                <div class="my-auto ms-3">
                                                    <div class="h-100">
                                                        <h6 class="mb-0">Edit</h6>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="d-flex">
                                                <p class="text-sm text-secondary ms-auto me-3 my-auto text-right"><span id="lblEditdatabase">Database</span></p>
                                                <div class="form-check form-switch my-auto">
                                                    <input class="form-check-input" type="checkbox" id="chkEditdatabase">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="d-flex">
                                                <p class="text-sm text-secondary ms-auto me-3 my-auto"><span id="lblSelfcreated">Self Created</span></p>
                                                <div class="form-check form-switch my-auto">
                                                    <input class="form-check-input" type="checkbox" id="chkSelfcreated">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="d-flex mt-4">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="d-flex">
                                                <div class="my-auto ms-3">
                                                    <div class="h-100">
                                                        <h6 class="mb-0">View</h6>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="d-flex">
                                                <p class="text-sm text-secondary ms-auto me-3 my-auto text-right"><span id="lblViewdatabase">Database</span></p>
                                                <div class="form-check form-switch my-auto">
                                                    <input class="form-check-input" type="checkbox" id="chkViewdatabase">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="d-flex">
                                                <p class="text-sm text-secondary ms-auto me-3 my-auto"><span id="lblPersonalized">Personalized</span></p>
                                                <div class="form-check form-switch my-auto">
                                                    <input class="form-check-input" type="checkbox" id="chkPersonalized">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>



                            <hr class="horizontal dark mt-5">
                            <div class="d-flex">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-8">
                                            <div class="d-flex">
                                                <img class="width-48-px" src="../../../assets/img/small-logos/vendor.png" alt="logo_spotify">
                                                <div class="my-auto ms-3">
                                                    <div class="h-100">
                                                        <h5 class="mb-0">Vendor</h5>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="d-flex">
                                                <p class="text-sm text-secondary ms-auto me-3 my-auto"><span id="lblVendorenabled">Enabled</span></p>
                                                <div class="form-check form-switch my-auto">
                                                    <input class="form-check-input" type="checkbox" id="chkVendorenabled">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="d-flex mt-4">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-8">
                                            <div class="d-flex">
                                                <div class="my-auto ms-3">
                                                    <div class="h-100">
                                                        <h6 class="mb-0">Creation</h6>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="d-flex">
                                                <p class="text-sm text-secondary ms-auto me-3 my-auto"><span id="lblCreationenabled">Enabled</span></p>
                                                <div class="form-check form-switch my-auto">
                                                    <input class="form-check-input" type="checkbox" id="chkCreationenabled">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="d-flex mt-4">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="d-flex">
                                                <div class="my-auto ms-3">
                                                    <div class="h-100">
                                                        <h6 class="mb-0">Edit</h6>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="d-flex">
                                                <p class="text-sm text-secondary ms-auto me-3 my-auto text-right"><span id="lblVendoreditdatabase"></span>Database</p>
                                                <div class="form-check form-switch my-auto">
                                                    <input class="form-check-input" type="checkbox" id="chkVendoreditdatabase">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="d-flex">
                                                <p class="text-sm text-secondary ms-auto me-3 my-auto"><span id="lblVendorselfcreated">Self Created</span></p>
                                                <div class="form-check form-switch my-auto">
                                                    <input class="form-check-input" type="checkbox" id="chkVendorselfcreated">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="d-flex mt-4">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="d-flex">
                                                <div class="my-auto ms-3">
                                                    <div class="h-100">
                                                        <h6 class="mb-0">View</h6>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="d-flex">
                                                <p class="text-sm text-secondary ms-auto me-3 my-auto text-right"><span id="lblVendordatabase">Database</span></p>
                                                <div class="form-check form-switch my-auto">
                                                    <input class="form-check-input" type="checkbox" id="chkVendordatabase">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="d-flex">
                                                <p class="text-sm text-secondary ms-auto me-3 my-auto"><span id="lblVendorpersonalized">Personalized</span></p>
                                                <div class="form-check form-switch my-auto">
                                                    <input class="form-check-input" type="checkbox" id="chkVendorpersonalized">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <hr class="horizontal dark mt-4">
                            <div class="d-flex">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-8">
                                            <div class="d-flex">
                                                <img class="width-48-px" src="../../../assets/img/small-logos/report.png" alt="logo_spotify">
                                                <div class="my-auto ms-3">
                                                    <div class="h-100">
                                                        <h5 class="mb-0">Report</h5>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                            <div class="d-flex">
                                                <p class="text-sm text-secondary ms-auto me-3 my-auto"><span id="lblReportdisable">Disable</span></p>
                                                <div class="form-check form-switch my-auto">
                                                    <input class="form-check-input" type="checkbox" id="chkReportdisable">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- Card Notifications -->
                    <div class="card mt-4" id="div_Notifications" style="display: none">
                        <div class="card-header">
                            <h5>Notifications</h5>
                            <p class="text-sm">Choose how you receive notifications. These notification settings apply to the things you’re watching.</p>
                        </div>
                        <div class="card-body pt-0">
                            <div class="table-responsive">
                                <table class="table mb-0">
                                    <thead>
                                        <tr>
                                            <th class="ps-1" colspan="4">
                                                <p class="mb-0">Activity</p>
                                            </th>
                                            <th class="text-center">
                                                <p class="mb-0">Email</p>
                                            </th>
                                            <th class="text-center">
                                                <p class="mb-0">Push</p>
                                            </th>
                                            <th class="text-center">
                                                <p class="mb-0">SMS</p>
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td class="ps-1" colspan="4">
                                                <div class="my-auto">
                                                    <span class="text-dark d-block text-sm">Assign job</span>
                                                    <span class="text-xs font-weight-normal">Notify when management assign a job</span>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="form-check form-switch mb-0 d-flex align-items-center justify-content-center">
                                                    <input class="form-check-input" type="checkbox" id="chkAssignjobemail">
                                                </div>
                                            </td>
                                            <td>
                                                <div class="form-check form-switch mb-0 d-flex align-items-center justify-content-center">
                                                    <input class="form-check-input" type="checkbox" id="chkAssignjobpush">
                                                </div>
                                            </td>
                                            <td>
                                                <div class="form-check form-switch mb-0 d-flex align-items-center justify-content-center">
                                                    <input class="form-check-input" type="checkbox" id="chkAssignjobsms">
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="ps-1" colspan="4">
                                                <div class="my-auto">
                                                    <span class="text-dark d-block text-sm">Feedback</span>
                                                    <span class="text-xs font-weight-normal">Notify when management given feedback for submission.</span>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="form-check form-switch mb-0 d-flex align-items-center justify-content-center">
                                                    <input class="form-check-input" type="checkbox" id="chkFeedbackemail">
                                                </div>
                                            </td>
                                            <td>
                                                <div class="form-check form-switch mb-0 d-flex align-items-center justify-content-center">
                                                    <input class="form-check-input" type="checkbox" id="chkFeedbackpush">
                                                </div>
                                            </td>
                                            <td>
                                                <div class="form-check form-switch mb-0 d-flex align-items-center justify-content-center">
                                                    <input class="form-check-input" type="checkbox" id="chkFeedbacksms">
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="ps-1" colspan="4">
                                                <div class="my-auto">
                                                    <span class="text-dark d-block text-sm">Interview</span>
                                                    <span class="text-xs font-weight-normal">Notify when candidate have interview.</span>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="form-check form-switch mb-0 d-flex align-items-center justify-content-center">
                                                    <input class="form-check-input" type="checkbox" id="chkInterviewemail">
                                                </div>
                                            </td>
                                            <td>
                                                <div class="form-check form-switch mb-0 d-flex align-items-center justify-content-center">
                                                    <input class="form-check-input" type="checkbox" id="chkInterviewpush">
                                                </div>
                                            </td>
                                            <td>
                                                <div class="form-check form-switch mb-0 d-flex align-items-center justify-content-center">
                                                    <input class="form-check-input" type="checkbox" id="chkInterviewsms">
                                                </div>
                                            </td>
                                        </tr>

                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>

                    <!-- Card Sessions -->
                    <div class="card mt-4" id="div_Targetfixing">
                        <div class="card-header pb-3">
                            <h5>Target Fixing</h5>
                            <p class="text-sm">This is a list of target that have worked into your account. Remove those that you do not recognize.</p>
                        </div>

                        <div class="card-body pt-0">
                            <div class="d-flex align-items-center">
                                <div class="col-md-12">
                                    <table class="table align-items-center mb-0">
                                        <thead>
                                            <tr>
                                                <th></th>
                                                <th class="text-uppercase text-xxs font-weight-bolder opacity-7 ps-2" style="color: black;">Submission</th>
                                                <th class="text-uppercase text-xxs font-weight-bolder opacity-7 ps-2" id="th_target" style="color: black; display: none;">Vendor</th>
                                                <th class="text-uppercase text-xxs font-weight-bolder opacity-7 ps-2" style="color: black;">Submission to TL</th>
                                                <th class="text-uppercase text-xxs font-weight-bolder opacity-7 ps-2" style="color: black;">Submission to BP</th>
                                                <th class="text-uppercase text-xxs font-weight-bolder opacity-7 ps-2" style="color: black;">Closure</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr class="divControl">
                                                <td class="align-middle">
                                                    <label class="">Daily</label>
                                                </td>
                                                <td class="align-middle">
                                                    <input class="form-control" type="text" id="txtcandidatedaily" placeholder="Candidate" onkeypress="return numValidation(this);" />
                                                </td>
                                                <td class="align-middle" style="display: none;" id="td_daily">
                                                    <input class="form-control" type="text" id="txtvendordaily" placeholder="Vendor" onkeypress="return numValidation(this);" />
                                                </td>
                                                <td class="align-middle">
                                                    <input class="form-control" type="text" id="txttldaily" placeholder="TL" onkeypress="return numValidation(this);" />
                                                </td>
                                                <td class="align-middle">
                                                    <input class="form-control" type="text" id="txtbpdaily" placeholder="BP" onkeypress="return numValidation(this);" />
                                                </td>
                                                <td class="align-middle">
                                                    <input class="form-control" type="text" id="txtclosuredaily" placeholder="Closure" onkeypress="return numValidation(this);" />
                                                </td>
                                            </tr>

                                            <tr class="divControl">
                                                <td class="align-middle">
                                                    <label class="">Weekly</label>
                                                </td>
                                                <td class="align-middle">
                                                    <input class="form-control" type="text" id="txtcandidateweekly" placeholder="Candidate" onkeypress="return numValidation(this);" />
                                                </td>
                                                <td class="align-middle" style="display: none;" id="td_week">
                                                    <input class="form-control" type="text" id="txtvendorweekly" placeholder="Vendor" onkeypress="return numValidation(this);" />
                                                </td>
                                                <td class="align-middle">
                                                    <input class="form-control" type="text" id="txttlweekly" placeholder="TL" onkeypress="return numValidation(this);" />
                                                </td>
                                                <td class="align-middle">
                                                    <input class="form-control" type="text" id="txtbpweekly" placeholder="BP" onkeypress="return numValidation(this);" />
                                                </td>
                                                <td class="align-middle">
                                                    <input class="form-control" type="text" id="txtclosureweekly" placeholder="Closure" onkeypress="return numValidation(this);" />
                                                </td>
                                            </tr>

                                            <tr class="divControl">
                                                <td class="align-middle">
                                                    <label class="">Monthly</label>
                                                </td>
                                                <td class="align-middle">
                                                    <input class="form-control" type="text" id="txtcandidatemonthly" placeholder="Candidate" onkeypress="return numValidation(this);" />
                                                </td>
                                                <td class="align-middle" style="display: none;" id="td_month">
                                                    <input class="form-control" type="text" id="txtvendormonthly" placeholder="Vendor" onkeypress="return numValidation(this);" />
                                                </td>
                                                <td class="align-middle">
                                                    <input class="form-control" type="text" id="txttlmonthly" placeholder="TL" onkeypress="return numValidation(this);" />
                                                </td>
                                                <td class="align-middle">
                                                    <input class="form-control" type="text" id="txtbpmonthly" placeholder="BP" onkeypress="return numValidation(this);" />
                                                </td>
                                                <td class="align-middle">
                                                    <input class="form-control" type="text" id="txtclosuremonthly" placeholder="Closure" onkeypress="return numValidation(this);" />
                                                </td>
                                            </tr>

                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>

                        <%--<div class="card-body pt-0">
                            <div class="d-flex align-items-center">
                                <div class="text-center w-5">
                                    <i class="ni ni-single-02 text-lg opacity-6"></i>
                                </div>
                                <div class="my-auto col-md-12">
                                    <div class="row">
                                        <div class="col-md-3 ps-4">
                                            <p class="text-sm mb-1">
                                                Candidate adding
                                            </p>
                                            <p class="mb-0 text-xs">
                                                Target per day
                                            </p>
                                        </div>
                                        <div class="col-md-3">
                                            <input id="txtCandidateadding" class="form-control" type="text" placeholder="Candidating Adding" required="required">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <hr class="horizontal dark">
                            <div class="d-flex align-items-center">
                                <div class="text-center w-5">
                                    <i class="ni ni-paper-diploma text-lg opacity-6"></i>
                                </div>
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <p class="my-auto ms-3">Vendor creation </p>
                                        </div>
                                        <div class="col-md-3">
                                            <input id="txtVendorcreation" class="form-control" type="text" placeholder="Vendor Creation" required="required">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <hr class="horizontal dark">
                            <div class="d-flex align-items-center">
                                <div class="text-center w-5">
                                    <i class="ni ni-user-run text-lg opacity-6"></i>
                                </div>
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <p class="my-auto ms-3">Submission</p>
                                        </div>
                                        <div class="col-md-3">
                                            <input id="txtSubmission" class="form-control" type="text" placeholder="Submittion" required="required">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <hr class="horizontal dark">
                            <div class="d-flex align-items-center">
                                <div class="text-center w-5">
                                    <i class="ni ni-user-run text-lg opacity-6"></i>
                                </div>
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <p class="my-auto ms-3">TL Approval</p>
                                        </div>
                                        <div class="col-md-3">
                                            <input id="txtTLApproval" class="form-control" type="text" placeholder="Submittion" required="required">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <hr class="horizontal dark">
                            <div class="d-flex align-items-center">
                                <div class="text-center w-5">
                                    <i class="ni ni-user-run text-lg opacity-6"></i>
                                </div>
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <p class="my-auto ms-3">BP Approval</p>
                                        </div>
                                        <div class="col-md-3">
                                            <input id="txtBPApproval" class="form-control" type="text" placeholder="Submittion" required="required">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <hr class="horizontal dark">
                            <div class="d-flex align-items-center">
                                <div class="text-center w-5">
                                    <i class="ni ni-user-run text-lg opacity-6"></i>
                                </div>
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <p class="my-auto ms-3">EC Approval</p>
                                        </div>
                                        <div class="col-md-3">
                                            <input id="txtECApproval" class="form-control" type="text" placeholder="Submittion" required="required">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>--%>
                    </div>

                    <!-- Card Change Password -->
                    <div class="card mt-4" id="div_Changepassword" style="display: none">
                        <div class="card-header">
                            <h5>Change Password</h5>
                        </div>
                        <div class="card-body pt-0">
                            <label class="form-label">Current password</label>
                            <div class="form-group">
                                <input class="form-control" type="password" placeholder="Current password" id="txtCurrentpassword">
                            </div>
                            <label class="form-label">New password</label>
                            <div class="form-group">
                                <input class="form-control" type="password" placeholder="New password" id="txtNewpassword">
                            </div>
                            <label class="form-label">Confirm new password</label>
                            <div class="form-group">
                                <input class="form-control" type="password" placeholder="Confirm password" id="txtConfirmnewpassword">
                            </div>
                            <h5 class="mt-5">Password requirements</h5>
                            <p class="text-muted mb-2">
                                Please follow this guide for a strong password:
                            </p>
                            <ul class="text-muted ps-4 mb-0 float-start">
                                <li>
                                    <span class="text-sm">One special characters</span>
                                </li>
                                <li>
                                    <span class="text-sm">Min 6 characters</span>
                                </li>
                                <li>
                                    <span class="text-sm">One number (2 are recommended)</span>
                                </li>
                                <li>
                                    <span class="text-sm">Change it often</span>
                                </li>
                            </ul>
                            <button class="btn bg-gradient-dark btn-sm float-end mt-6 mb-0" id="btnUpdatepassword">Update password</button>
                        </div>
                    </div>

                    <!-- Card Delete Account -->
                    <div class="card mt-4" id="div_Deleteaccount" style="display: none">
                        <div class="card-header">
                            <h5>Delete Account</h5>
                            <p class="text-sm mb-0">Once you delete your account, there is no going back. Please be certain.</p>
                        </div>
                        <div class="card-body d-sm-flex pt-0">
                            <div class="d-flex align-items-center mb-sm-0 mb-4">
                                <div>
                                    <div class="form-check form-switch mb-0">
                                        <input class="form-check-input" type="checkbox" id="chkDelectaccount">
                                    </div>
                                </div>
                                <div class="ms-2">
                                    <span class="text-dark font-weight-bold d-block text-sm">Confirm</span>
                                    <span class="text-xs d-block">I want to delete my account.</span>
                                </div>
                            </div>
                            <button class="btn btn-outline-secondary mb-0 ms-auto btn-resize" type="button" id="btnDeactivate">Deactivate</button>
                            <button class="btn bg-gradient-danger mb-0 ms-2 btn-resize" type="button" id="btnDeleteaccount">Delete Account</button>
                        </div>
                    </div>

                    <div class="col-md-12 mt-3">
                        <div class="row">
                            <div class="col-md-6">
                                <button type="button" name="button" class="btn bg-gradient-secondary btn-resize" onclick="window.location.href='Superadmin_UserList.aspx'">Back</button>
                            </div>
                            <div class="col-lg-6 text-right d-flex flex-column justify-content-center">
                                <button id="btnSave" type="button" class="btn bg-gradient-primary mb-0 ms-lg-auto me-lg-0 me-auto mt-lg-0 mt-2 btn-resize" onclick="saveUserprofile()">Save</button>
                            </div>
                        </div>
                    </div>

                </div>
            </div>


            <%--Pop up--%>

            <div class="ms-auto my-auto mt-lg-0 mt-4">
                <div class="ms-auto my-auto">
                    <div class="modal fade" id="addregion" tabindex="-1" aria-hidden="true" style="display: none;">
                        <div class="modal-dialog mt-lg-10">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title">Region</h5>
                                </div>
                                <div class="col-md-12 p-3">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>Choose Region</label>
                                            <select class="form-control" name="choices-sizes" id="drpRegion">
                                                <option value="-1">--Select Region--</option>
                                                <option value="2001">USA</option>
                                                <option value="2000">India</option>
                                                <option value="2002">Global</option>
                                            </select>
                                        </div>

                                    </div>
                                </div>
                                <div class="modal-footer mt-2">
                                    <button type="button" class="btn bg-gradient-primary btn-sm" id="btnRegSave" onclick="saveRegion();">Save</button>
                                    <button type="button" id="btnRegClose" class="btn bg-gradient-secondary btn-sm" data-bs-dismiss="modal">Close</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="ms-auto my-auto mt-lg-0 mt-4">
                <div class="ms-auto my-auto">
                    <div class="modal fade" id="addmonster" tabindex="-1" aria-hidden="true" style="display: none;">
                        <div class="modal-dialog mt-lg-10">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title">Monster</h5>
                                </div>
                                <div class="col-md-12 p-3">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <label>Monster Username</label>
                                            <input class="form-control" type="text" id="txtMonsteruserid" placeholder="Monster User name" />
                                        </div>
                                        <div class="col-md-6">
                                            <label>Monster Password</label>
                                            <input class="form-control" type="password" id="txtMonsterpwd" placeholder="Monster Password" />
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer mt-2">
                                    <button type="button" class="btn bg-gradient-primary btn-sm" id="btnMonSave" onclick="saveMonster();">Save</button>
                                    <button type="button" id="btnMonClose" class="btn bg-gradient-secondary btn-sm" data-bs-dismiss="modal">Close</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="ms-auto my-auto mt-lg-0 mt-4">
                <div class="ms-auto my-auto">
                    <div class="modal fade" id="addtextnow" tabindex="-1" aria-hidden="true" style="display: none;">
                        <div class="modal-dialog mt-lg-10">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title">Text Now Number</h5>
                                </div>
                                <div class="col-md-12 p-3">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>Text Now Number</label>
                                            <input class="form-control" type="text" id="txtTextnownumber" placeholder="Text now Number" />
                                        </div>

                                    </div>
                                </div>
                                <div class="modal-footer mt-2">
                                    <button type="button" class="btn bg-gradient-primary btn-sm" id="btnTexSave" onclick="saveTextnow();">Save</button>
                                    <button type="button" id="btnTexClose" class="btn bg-gradient-secondary btn-sm" data-bs-dismiss="modal">Close</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="ms-auto my-auto mt-lg-0 mt-4">
            <div class="ms-auto my-auto">
                <div class="modal fade" id="msgpopup" tabindex="-1" aria-hidden="true" style="display: none;">
                    <div class="modal-dialog" style="max-width: 300px !important; margin-top: 15rem !important;">
                        <div class="modal-content">

                            <div class="col-md-12 mt-3 text-center">
                                <p class="mb-0 h6"><span id="div-message">Are You Want to delete This</span></p>
                            </div>

                            <div class=" pt-0" style="border-top: none; padding: 0px 20px 10px 20px; display: none;" id="div_Confirm">
                                <center>
                                    <button type="button" class="btn bg-gradient-primary mb-0 btn-resize text-left" id="btnYes" onclick="">Yes</button>
                                    <button type="button" id="btnNo" class="btn bg-gradient-secondary mb-0 btn-resize">No</button>
                                </center>
                            </div>
                            <div class=" pt-0" style="border-top: none; padding: 0px 20px 10px 20px; display: none;" id="div_Success">
                                <center>
                                    <button type="button" class="btn bg-gradient-primary mb-0 btn-resize text-left" id="btnOk" onclick="window.location.href='Superadmin_UserList.aspx'">OK</button>
                                </center>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
    <script src="assets/js/jquery.js"></script>
    <script src="assets/js/plugins/flatpickr.min.js"></script>
    <script src="assets/js/plugins.js"></script>
    <script src="assets/js/prop/commondatastore.js"></script>
    <script src="AppScripts/Userprofile.js"></script>
    <script>


        function saveRegion() {

            if (Validateregion() == true) {
                $("#lblRegion").text($('select#drpRegion option:selected').text());
                $("#lblRegionname").text($('select#drpRegion option:selected').text() + " access");
                $('#hdnRegion').val($('select#drpRegion option:selected').val());
                getTargetData();
                $("#addregion").modal('hide');
            }
        }


        function saveMonster() {
            if (Validatemonster() == true) {
                $("#lblMonster").text($("#txtMonsteruserid").val() + "|" + $("#txtMonsterpwd").val());
                $("#addmonster").modal('hide');
            }
        }

        function saveTextnow() {
            if (Validatetextnownumber() == true) {
                $("#lblTextnow").text($("#txtTextnownumber").val());
                $("#addtextnow").modal('hide');
            }
        }



    </script>

    <script type="text/javascript">

        if (document.querySelector('.datepicker')) {
            flatpickr('.datepicker', {
                dateFormat: "Y-m-d"
            }); // flatpickr
        }

    </script>

</asp:Content>

