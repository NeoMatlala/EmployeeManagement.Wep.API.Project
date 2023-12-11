<template>
    <nav class="bg-blue-700 text-white rounded-l-lg w-1/4">
        <div class="max-w-screen-xl flex flex-col mx-auto">
            <NuxtLink to="/" class="flex items-center space-x-3 p-5 rtl:space-x-reverse">
                <svg xmlns="http://www.w3.org/2000/svg" fill="currentColor" class="bi w-8 h-8 bi-eye-fill" viewBox="0 0 16 16">
                <path d="M10.5 8a2.5 2.5 0 1 1-5 0 2.5 2.5 0 0 1 5 0"/>
                <path d="M0 8s3-5.5 8-5.5S16 8 16 8s-3 5.5-8 5.5S0 8 0 8m8 3.5a3.5 3.5 0 1 0 0-7 3.5 3.5 0 0 0 0 7"/>
                </svg>
                <span class="self-center text-2xl font-medium whitespace-nowrap">manage</span>
            </NuxtLink>
            <button data-collapse-toggle="navbar-default" type="button" class="inline-flex items-center p-2 w-10 h-10 justify-center text-sm text-gray-500 rounded-lg md:hidden hover:bg-gray-100 focus:outline-none focus:ring-2 focus:ring-gray-200" aria-controls="navbar-default" aria-expanded="false">
                <span class="sr-only">Open main menu</span>
                <svg class="w-5 h-5" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 17 14">
                    <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M1 1h15M1 7h15M1 13h15"/>
                </svg>
            </button>
            <hr class="mx-2">
            <div class="hidden mt-10 px-1 w-full md:block md:w-auto" id="navbar-default">
                <ul class="font-medium flex flex-col gap-y-5 text-lg">
                    <li class="py-2 px-4 rounded-sm" :class="{ 'bg-white text-blue-700': $route.path === '/' }">
                        <NuxtLink to="/" class="block  rounded md:bg-transparent md:hover:underline md:p-0" aria-current="page" >Home</NuxtLink>
                    </li>
                    <li class="py-2 px-4 rounded-sm" :class="{ 'bg-white text-blue-700': $route.path.startsWith('/employees') }">
                        <NuxtLink to="/employees" class="block rounded hover:bg-gray-100 md:hover:bg-transparent md:border-0 md:hover:underline md:p-0" >Employees</NuxtLink>
                    </li>
                    <li class="py-2 px-4 rounded-sm" :class="{ 'bg-white text-blue-700': $route.path.startsWith('/departments') }">
                        <NuxtLink to="/departments" class="block rounded hover:bg-gray-100 md:hover:bg-transparent md:border-0 md:hover:underline md:p-0" >Departments</NuxtLink>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
</template>