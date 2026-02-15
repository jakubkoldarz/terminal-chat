<script lang="ts" setup>
  import { nextTick, ref } from 'vue';
  import TerminalInput from './TerminalInput.vue';
  import Typewriter from './Typewriter.vue';
  import type { TerminalField } from '../types/TerminalField';

  const { fields } = defineProps<{
    fields: TerminalField[];
  }>();

  const emit = defineEmits<{
    submit: [data: Record<string, string>];
  }>();

  const currentStepIndex = ref(0);
  const inputRefs = ref<InstanceType<typeof TerminalInput>[]>([]);
  const formData = ref<Record<string, string>>({});
  const errorMessage = ref('');
  const currentKey = ref(0);

  async function nextStep() {
    if (errorMessage.value.length > 0) {
      await resetForm();
      return;
    }

    const currentField = fields[currentStepIndex.value];
    if (!currentField) return;

    const valueToValidate = formData.value[currentField?.name] || '';

    if (!validateValue(valueToValidate, currentField.validationPattern)) {
      errorMessage.value = currentField.errorMessage;
      return;
    }

    if (currentStepIndex.value < fields.length - 1) {
      await progressForm();
    } else {
      submit();
    }
  }

  function submit() {
    emit('submit', formData.value);
  }

  function validateValue(value: string, pattern: RegExp): boolean {
    return pattern.test(value);
  }

  async function progressForm() {
    currentStepIndex.value++;
    await nextTick();
    const currentInput = inputRefs.value[currentStepIndex.value];
    currentInput?.focus();
  }

  async function resetForm() {
    currentKey.value++;
    currentStepIndex.value = 0;
    formData.value = {};
    errorMessage.value = '';

    await nextTick();
    inputRefs.value[0]?.focus();
  }
</script>

<template>
  <div :key="currentKey">
    <div v-for="(field, index) in fields" :key="field.name">
      <div class="flex gap-2" v-if="index <= currentStepIndex">
        <Typewriter :text="`${field.name}:`"></Typewriter>
        <TerminalInput
          :is-password="field.isPassword"
          ref="inputRefs"
          v-model="formData[field.name]"
          :disabled="index < currentStepIndex"
          :readonly="index === currentStepIndex && errorMessage.length > 0"
          @submit="nextStep"
        ></TerminalInput>
      </div>
    </div>
    <div v-if="errorMessage">
      <Typewriter
        :text="`${errorMessage}\nPress ENTER to continue...`"
      ></Typewriter>
    </div>
  </div>
</template>
