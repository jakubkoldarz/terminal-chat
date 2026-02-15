<script setup lang="ts">
  import { ref } from 'vue';
  import TerminalForm from './components/TerminalForm.vue';
  import Typewriter from './components/Typewriter.vue';
  import type { TerminalField } from './types/TerminalField';

  const isLoading = ref(false);
  const hasChosenOption = ref(false);

  const choiceFields: TerminalField[] = [
    {
      name: 'choice',
      validationPattern: /^(login|register)$/,
      errorMessage: 'Please enter a valid option (login, register).',
    },
  ];

  const authFields: TerminalField[] = [
    {
      name: 'login',
      validationPattern: /^[a-zA-Z0-9]{6,}$/,
      errorMessage:
        'Login must be at least 6 characters long and contain only letters and numbers.',
    },
    {
      name: 'password',
      validationPattern: /^[a-zA-Z0-9]{8,}$/,
      errorMessage: 'Password must be at least 8 characters long',
      isPassword: true,
    },
  ];

  function handleFormSubmit(data: Record<string, string>) {
    // const password = data.password;
    // const login = data.login;
    isLoading.value = true;
  }
</script>

<template>
  <div
    class="bg-terminal-dark min-h-screen w-full p-12 text-terminal-green font-terminal text-2xl"
  >
    <Typewriter
      text="Initial version of the terminal chat application. Backend is running on ASP.NET Core, while frontend is built with Vue.js."
    >
    </Typewriter>
    <hr class="mb-8" />
    <TerminalForm
      :fields="choiceFields"
      @submit="handleFormSubmit"
    ></TerminalForm>
    <TerminalForm
      v-if="hasChosenOption"
      :fields="authFields"
      @submit="handleFormSubmit"
    ></TerminalForm>
    <Typewriter v-if="isLoading" text="Loading..."> </Typewriter>
  </div>
</template>
