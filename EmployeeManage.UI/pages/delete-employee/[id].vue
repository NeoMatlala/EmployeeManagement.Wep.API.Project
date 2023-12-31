<template>
    <div>
        <h1 class="font-medium text-3xl text-slate-800 mb-16">Delete Employee</h1>

        <form class="mt-16" @submit.prevent="handleDelete">
            <div class="grid gap-10 mb-6 md:grid-cols-2">
                <div>
                    <label for="first_name" class="block mb-2 text-sm font-medium text-gray-900">Name</label>
                    <input disabled type="text" id="first_name" :value="employee.name" class="bg-gray-200 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5">
                </div>
                <div>
                    <label for="last_name" class="block mb-2 text-sm font-medium text-gray-900">Surname</label>
                    <input disabled type="text" id="last_name" :value="employee.surname" class="bg-gray-200 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5">
                </div>
                <div>
                    <label for="company" class="block mb-2 text-sm font-medium text-gray-900">ID Number</label>
                    <input disabled type="text" id="company" :value="employee.idNumber" class="bg-gray-200 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5">
                </div>  
                <div>
                    <label for="company" class="block mb-2 text-sm font-medium text-gray-900">Job Title</label>
                    <input disabled type="text" id="company" :value="employee.jobTitle" class="bg-gray-200 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5">
                </div>  
                <div>
                    <label for="company" class="block mb-2 text-sm font-medium text-gray-900">Department Name</label>
                    <input disabled type="text" id="company" :value="employee.departmentName" class="bg-gray-200 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5">
                </div>  
            </div>
            <div class="flex justify-end items-center">
                <a id="button" class="text-white hover:cursor-pointer bg-red-700 hover:bg-red-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Delete department</a>
                <NuxtLink to="/employees" data-modal-hide="default-modal" type="button" class="ms-3 text-gray-500 bg-gray-50 hover:bg-gray-100 focus:ring-4 focus:outline-none focus:ring-blue-300 rounded-lg border border-gray-200 text-sm font-medium px-5 py-2.5 hover:text-gray-900 focus:z-10">Cancel</NuxtLink>
            </div>
            
            <!-- delete modal -->
            <div id="popup-modal" tabindex="-1" class="hidden overflow-y-auto overflow-x-hidden fixed top-0 right-0 left-0 z-50 justify-center items-center w-full md:inset-0 h-[calc(100%-1rem)] max-h-full">
                <div class="relative p-4 w-full max-w-md max-h-full">
                    <div class="relative bg-white rounded-lg shadow">
                        <div class="p-4 md:p-5 text-center">
                            <svg class="mx-auto mb-4 text-gray-400 w-12 h-12" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 20 20">
                                <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M10 11V6m0 8h.01M19 10a9 9 0 1 1-18 0 9 9 0 0 1 18 0Z"/>
                            </svg>
                            <h3 class="mb-5 text-lg font-normal text-gray-5000">Are you sure you want to delete <br>{{employee.name}} {{employee.surname}} ?</h3>
                            <button type="submit" class="text-white bg-red-600 hover:bg-red-800 focus:ring-4 focus:outline-none focus:ring-red-300 font-medium rounded-lg text-sm inline-flex items-center px-5 py-2.5 text-center me-2">
                                Yes, I'm sure
                            </button>
                            <button id="closeButton" type="button" class="text-gray-500 bg-white hover:bg-gray-100 focus:ring-4 focus:outline-none focus:ring-gray-200 rounded-lg border border-gray-200 text-sm font-medium px-5 py-2.5 hover:text-gray-900 focus:z-10">No, cancel</button>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>
</template>

<script>
import axios from 'axios'
import { ref } from 'vue';
import { useRoute } from 'vue-router';
import { onMounted } from 'vue'
import { Modal } from 'flowbite'

export default{
    data() {
        return {
            employee: {}
        }
    },
    setup(){
        const id = ref(useRoute().params.id);
        const config = useRuntimeConfig()

        onMounted(() => {
            const $buttonElement = document.querySelector('#button');
            const $modalElement = document.querySelector('#popup-modal');
            const $closeButton = document.querySelector('#closeButton');
            const modalOptions = {
                backdropClasses: 'bg-gray-900 bg-opacity-50 fixed inset-0 z-40'
            }
            if ($modalElement) {
                const modal = new Modal($modalElement, modalOptions);
                $buttonElement.addEventListener('click', () => modal.toggle());
                $closeButton.addEventListener('click', () => modal.hide());
            }
        })

        return {
            id,
            baseApi: config.public.apiBase
        };
    },
    created() {
        this.fetchEmployee()
    },
    methods: {
        async fetchEmployee() {
            try {
                var response = await axios.get(`${this.baseApi}/api/Employee/${this.id}`)
                //console.log(response.data)
                this.employee = response.data
            } catch (error) {
                console.log("Error getting employee: ", error.message)
            }
        },
        async handleDelete() {
            const $modalElement = document.querySelector('#popup-modal');
            const $closeButton = document.querySelector('#closeButton');
            const modalOptions = {
                backdropClasses: 'bg-gray-900 bg-opacity-50 fixed inset-0 z-40'
            }

            try {
                var response = await axios.delete(`${this.baseApi}/api/Employee/${this.id}`)
                console.log(response.data)

                if ($modalElement) {
                    const modal = new Modal($modalElement, modalOptions);
                    $closeButton.addEventListener('click', () => modal.hide());
                }

                this.$router.replace('/employees');
            } catch (error) {
                console.log("Error deleting employee: ", error.message)
            }
        }
    }
}
</script>