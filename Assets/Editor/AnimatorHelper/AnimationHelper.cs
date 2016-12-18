#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

public class AnimationHelper : EditorWindow {

	public GameObject target;
	public AnimationClip idleAnim;
	public AnimationClip walkAnim;
	public AnimationClip runAnim;

	[MenuItem ("Window/Animator Helper")]
	static void OpenWindow ()
	{

		//Get existing open window or if none, make a new one:
		GetWindow<AnimationHelper>();
	}

	void OnGUI()
	{
		target = EditorGUILayout.ObjectField("Target Object", target, typeof(GameObject), true) as GameObject;
		idleAnim = EditorGUILayout.ObjectField("Idle", idleAnim, typeof(AnimationClip), false) as AnimationClip;
		walkAnim = EditorGUILayout.ObjectField("Walk", walkAnim, typeof(AnimationClip), false) as AnimationClip;
		runAnim = EditorGUILayout.ObjectField("Run", idleAnim, typeof(AnimationClip), false) as AnimationClip;

		if (GUILayout.Button("Create"))
		{
			if (target == null)
			{
				Debug.LogError ("No target for animator controller set.");
				return;
			}

			Create();
		}
	}


	void Create ()
	{
		AnimatorController controller = AnimatorController.CreateAnimatorControllerAtPath("Assets/" + target.name + ".controller");

		// Adds a float parameter called Speed
		controller.AddParameter("Speed", AnimatorControllerParameterType.Float);

		//Add states
		AnimatorState idleState = controller.layers[0].stateMachine.AddState("Idle");
		idleState.motion = idleAnim;

		//Blend tree creation
		BlendTree blendTree;
		AnimatorState moveState = controller.CreateBlendTreeInController("Move", out blendTree);

		//BlendTree setup
		blendTree.blendType = BlendTreeType.Simple1D;
		blendTree.blendParameter = "Speed";
		blendTree.AddChild(walkAnim);
		blendTree.AddChild(runAnim);

		AnimatorStateTransition LeaveIdle = idleState.AddTransition(moveState);
		AnimatorStateTransition leaveMove = moveState.AddTransition(idleState);

		LeaveIdle.AddCondition(AnimatorConditionMode.Greater, 0.01f, "Speed");
		leaveMove.AddCondition(AnimatorConditionMode.Less, 0.01f, "Speed");

		target.GetComponent<Animator>().runtimeAnimatorController = controller;
	}
}

#endif 
